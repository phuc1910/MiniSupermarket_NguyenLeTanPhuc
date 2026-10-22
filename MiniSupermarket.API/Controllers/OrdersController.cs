/*
 * Ho ten sinh vien: Nguyen Le Tan Phuc
 * Ma sinh vien: 2124110108
 * Mo ta: API Thanh toan POS da bang duoc bao ve boi SqlTransaction (ACID)
 *        Route khop voi FormPOS: POST api/orders/checkout
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Tiêm IConfiguration để đọc chuỗi kết nối từ appsettings.json
        public OrdersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // =========================================================================
        // POST: api/orders/checkout
        // Tạo hóa đơn, lưu chi tiết, trừ tồn kho, cộng điểm - tất cả trong 1 Transaction
        // Chỉ Admin và Cashier được bán hàng (Warehouse không có màn hình POS)
        // =========================================================================
        [HttpPost("checkout")]
        [Authorize(Roles = "Admin,Cashier")]
        public IActionResult Checkout([FromBody] CheckoutRequestDto request)
        {
            // 1. Kiểm tra tính hợp lệ của yêu cầu
            if (request.Items == null || request.Items.Count == 0)
            {
                return BadRequest(new { message = "Giỏ hàng rỗng, không thể thanh toán!" });
            }

            if (string.IsNullOrWhiteSpace(request.CashierUsername))
            {
                return BadRequest(new { message = "Thiếu thông tin tài khoản thu ngân lập hóa đơn!" });
            }

            // Số lượng âm sẽ làm TĂNG tồn kho thay vì trừ -> phải chặn từ đầu
            if (request.Items.Any(i => i.Quantity <= 0))
            {
                return BadRequest(new { message = "Số lượng của mỗi mặt hàng phải lớn hơn 0!" });
            }

            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 2. BẮT ĐẦU TRANSACTION: từ đây mọi lệnh phải gắn transaction
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // ---------------------------------------------------------------
                    // Tra khách hàng theo số điện thoại (không có / không thấy = vãng lai)
                    // ---------------------------------------------------------------
                    int? customerId = null;
                    string customerName = "Khách vãng lai";

                    if (!string.IsNullOrWhiteSpace(request.CustomerPhone))
                    {
                        string findSql = "SELECT CustomerId, CustomerName FROM Customers WHERE PhoneNumber = @Phone";

                        using (SqlCommand cmdFind = new SqlCommand(findSql, connection, transaction))
                        {
                            cmdFind.Parameters.AddWithValue("@Phone", request.CustomerPhone.Trim());

                            using (SqlDataReader reader = cmdFind.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    customerId = Convert.ToInt32(reader["CustomerId"]);
                                    customerName = reader["CustomerName"].ToString() ?? customerName;
                                }
                            }
                        }
                    }

                    // Tính tổng tiền, tổng số lượng, điểm thưởng (10.000đ = 1 điểm, chỉ khi có khách)
                    decimal finalAmount = request.Items.Sum(i => i.Quantity * i.UnitPrice);
                    int totalItems = request.Items.Sum(i => i.Quantity);
                    int rewardPoints = customerId.HasValue ? (int)(finalAmount / 10000) : 0;

                    // Mã hóa đơn: HD-YYYYMMDD-XXXXXXXX (8 ký tự ngẫu nhiên vì OrderCode có Unique Index,
                    // 4 ký tự dễ trùng khi bán nhiều hóa đơn trong ngày)
                    string orderCode = $"HD-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";

                    // ---------------------------------------------------------------
                    // BƯỚC 1: Tạo hóa đơn tổng, lấy OrderId vừa sinh bằng OUTPUT INSERTED
                    // ---------------------------------------------------------------
                    string insertOrderSql = @"
                        INSERT INTO Orders (OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints)
                        OUTPUT INSERTED.OrderId
                        VALUES (@OrderCode, GETDATE(), @CashierUsername, @CustomerId, @TotalItems, @FinalAmount, @RewardPoints)";

                    int orderId;
                    using (SqlCommand cmdOrder = new SqlCommand(insertOrderSql, connection, transaction))
                    {
                        cmdOrder.Parameters.AddWithValue("@OrderCode", orderCode);
                        cmdOrder.Parameters.AddWithValue("@CashierUsername", request.CashierUsername.Trim());
                        // Khách vãng lai phải truyền DBNull.Value (không được truyền null của C#)
                        cmdOrder.Parameters.AddWithValue("@CustomerId", (object?)customerId ?? DBNull.Value);
                        cmdOrder.Parameters.AddWithValue("@TotalItems", totalItems);
                        cmdOrder.Parameters.AddWithValue("@FinalAmount", finalAmount);
                        cmdOrder.Parameters.AddWithValue("@RewardPoints", rewardPoints);

                        orderId = Convert.ToInt32(cmdOrder.ExecuteScalar());
                    }

                    // ---------------------------------------------------------------
                    // BƯỚC 2 + 3: Với từng món: kiểm tra giá/tồn kho -> lưu chi tiết -> trừ kho
                    // ---------------------------------------------------------------
                    foreach (var item in request.Items)
                    {
                        string productName;
                        decimal dbPrice;
                        int currentStock;

                        // UPDLOCK khóa dòng sản phẩm đến hết Transaction, tránh 2 quầy POS
                        // cùng đọc thấy "còn hàng" rồi cùng trừ kho làm tồn bị âm
                        string checkSql = @"SELECT ProductName, Price, StockQuantity
                                            FROM Products WITH (UPDLOCK, ROWLOCK)
                                            WHERE ProductId = @ProductId";

                        using (SqlCommand cmdCheck = new SqlCommand(checkSql, connection, transaction))
                        {
                            cmdCheck.Parameters.AddWithValue("@ProductId", item.ProductId);

                            using (SqlDataReader reader = cmdCheck.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    throw new InvalidOperationException($"Không tìm thấy sản phẩm có ID: {item.ProductId}");
                                }

                                productName = reader["ProductName"].ToString() ?? string.Empty;
                                dbPrice = Convert.ToDecimal(reader["Price"]);
                                currentStock = Convert.ToInt32(reader["StockQuantity"]);
                            }
                        }

                        // Không tin giá do client gửi lên: lệch giá so với CSDL thì hủy giao dịch
                        if (item.UnitPrice != dbPrice)
                        {
                            throw new InvalidOperationException(
                                $"Đơn giá của '{productName}' không khớp CSDL! " +
                                $"(Giá hiện tại: {dbPrice:N0}, giá gửi lên: {item.UnitPrice:N0})");
                        }

                        // ĐIỂM KIỂM SOÁT LOGIC: mua vượt tồn kho -> ném lỗi -> nhảy xuống catch -> Rollback
                        if (currentStock < item.Quantity)
                        {
                            throw new InvalidOperationException(
                                $"Sản phẩm '{productName}' (ID: {item.ProductId}) không đủ tồn kho! " +
                                $"(Tồn kho thực tế: {currentStock}, Số lượng yêu cầu mua: {item.Quantity})");
                        }

                        // Lưu dòng chi tiết hóa đơn
                        string insertDetailSql = @"
                            INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice, LineTotal)
                            VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice, @LineTotal)";

                        using (SqlCommand cmdDetail = new SqlCommand(insertDetailSql, connection, transaction))
                        {
                            cmdDetail.Parameters.AddWithValue("@OrderId", orderId);
                            cmdDetail.Parameters.AddWithValue("@ProductId", item.ProductId);
                            cmdDetail.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmdDetail.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                            cmdDetail.Parameters.AddWithValue("@LineTotal", item.Quantity * item.UnitPrice);
                            cmdDetail.ExecuteNonQuery();
                        }

                        // Trừ tồn kho
                        string updateStockSql = @"UPDATE Products
                                                  SET StockQuantity = StockQuantity - @Qty
                                                  WHERE ProductId = @ProductId";

                        using (SqlCommand cmdStock = new SqlCommand(updateStockSql, connection, transaction))
                        {
                            cmdStock.Parameters.AddWithValue("@Qty", item.Quantity);
                            cmdStock.Parameters.AddWithValue("@ProductId", item.ProductId);
                            cmdStock.ExecuteNonQuery();
                        }
                    }

                    // ---------------------------------------------------------------
                    // BƯỚC 4: Cộng điểm tích lũy (chỉ khi xác định được khách hàng)
                    // ---------------------------------------------------------------
                    if (rewardPoints > 0 && customerId.HasValue)
                    {
                        string updatePointsSql = @"UPDATE Customers
                                                   SET RewardPoints = RewardPoints + @Points
                                                   WHERE CustomerId = @CustomerId";

                        using (SqlCommand cmdPoints = new SqlCommand(updatePointsSql, connection, transaction))
                        {
                            cmdPoints.Parameters.AddWithValue("@Points", rewardPoints);
                            cmdPoints.Parameters.AddWithValue("@CustomerId", customerId.Value);
                            cmdPoints.ExecuteNonQuery();
                        }
                    }

                    // BƯỚC 5: Mọi thứ thành công -> XÁC NHẬN LƯU VĨNH VIỄN
                    transaction.Commit();

                    return Ok(new
                    {
                        success = true,
                        message = "Thanh toán hóa đơn POS thành công!",
                        orderId = orderId,
                        orderCode = orderCode,
                        customerName = customerName,
                        totalItems = totalItems,
                        finalAmount = finalAmount,
                        rewardPointsAdded = rewardPoints
                    });
                }
                catch (Exception ex)
                {
                    // BƯỚC 6: Có bất kỳ lỗi nào -> HOÀN TÁC TOÀN BỘ
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi nghiêm trọng khi thực thi Rollback: " + rollbackEx.Message
                        });
                    }

                    return BadRequest(new
                    {
                        success = false,
                        message = "Giao dịch thanh toán bị hủy và đã được Rollback an toàn!",
                        errorDetail = ex.Message
                    });
                }
            }
        }

        // =========================================================================
        // DELETE: api/orders/cancel/{orderId}
        // BÀI TẬP MỞ RỘNG: Hủy hóa đơn, hoàn trả tồn kho, thu hồi điểm thưởng
        // Chỉ Admin được hủy hóa đơn
        // =========================================================================
        [HttpDelete("cancel/{orderId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult CancelOrder(int orderId)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1. Kiểm tra hóa đơn tồn tại, lấy khách hàng và điểm thưởng đã tặng
                    int? customerId = null;
                    int pointsToDeduct = 0;

                    using (SqlCommand cmdGet = new SqlCommand(
                        "SELECT CustomerId, RewardPoints FROM Orders WHERE OrderId = @OrderId", connection, transaction))
                    {
                        cmdGet.Parameters.AddWithValue("@OrderId", orderId);

                        using (SqlDataReader reader = cmdGet.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                throw new InvalidOperationException($"Không tìm thấy hóa đơn ID = {orderId} để hủy!");
                            }

                            // Hóa đơn của khách vãng lai có CustomerId = NULL
                            if (reader["CustomerId"] != DBNull.Value)
                            {
                                customerId = Convert.ToInt32(reader["CustomerId"]);
                            }
                            pointsToDeduct = Convert.ToInt32(reader["RewardPoints"]);
                        }
                    }

                    // 2. Đọc hết chi tiết vào danh sách RAM TRƯỚC khi cập nhật
                    //    (không chạy lệnh khác khi reader còn mở)
                    var itemsToRestore = new List<(int ProductId, int Quantity)>();

                    using (SqlCommand cmdDetails = new SqlCommand(
                        "SELECT ProductId, Quantity FROM OrderDetails WHERE OrderId = @OrderId", connection, transaction))
                    {
                        cmdDetails.Parameters.AddWithValue("@OrderId", orderId);

                        using (SqlDataReader reader = cmdDetails.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemsToRestore.Add((
                                    Convert.ToInt32(reader["ProductId"]),
                                    Convert.ToInt32(reader["Quantity"])));
                            }
                        }
                    }

                    // 3. Cộng trả tồn kho
                    foreach (var item in itemsToRestore)
                    {
                        using (SqlCommand cmdRestore = new SqlCommand(
                            "UPDATE Products SET StockQuantity = StockQuantity + @Qty WHERE ProductId = @ProductId",
                            connection, transaction))
                        {
                            cmdRestore.Parameters.AddWithValue("@Qty", item.Quantity);
                            cmdRestore.Parameters.AddWithValue("@ProductId", item.ProductId);
                            cmdRestore.ExecuteNonQuery();
                        }
                    }

                    // 4. Thu hồi điểm thưởng (không để điểm bị âm)
                    if (pointsToDeduct > 0 && customerId.HasValue)
                    {
                        string deductSql = @"UPDATE Customers
                                             SET RewardPoints = CASE WHEN RewardPoints >= @Pts
                                                                     THEN RewardPoints - @Pts ELSE 0 END
                                             WHERE CustomerId = @CustomerId";

                        using (SqlCommand cmdDeduct = new SqlCommand(deductSql, connection, transaction))
                        {
                            cmdDeduct.Parameters.AddWithValue("@Pts", pointsToDeduct);
                            cmdDeduct.Parameters.AddWithValue("@CustomerId", customerId.Value);
                            cmdDeduct.ExecuteNonQuery();
                        }
                    }

                    // 5. Xóa chi tiết trước (bảng con), sau đó xóa hóa đơn (bảng cha) để không vi phạm khóa ngoại
                    using (SqlCommand cmdDelDetails = new SqlCommand(
                        "DELETE FROM OrderDetails WHERE OrderId = @OrderId", connection, transaction))
                    {
                        cmdDelDetails.Parameters.AddWithValue("@OrderId", orderId);
                        cmdDelDetails.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdDelOrder = new SqlCommand(
                        "DELETE FROM Orders WHERE OrderId = @OrderId", connection, transaction))
                    {
                        cmdDelOrder.Parameters.AddWithValue("@OrderId", orderId);
                        cmdDelOrder.ExecuteNonQuery();
                    }

                    // 6. Xác nhận lưu vĩnh viễn
                    transaction.Commit();

                    return Ok(new
                    {
                        success = true,
                        message = $"Đã hủy hóa đơn #{orderId} và hoàn trả tồn kho vào CSDL!"
                    });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return BadRequest(new
                    {
                        success = false,
                        message = "Hủy hóa đơn thất bại, giao dịch đã được Rollback!",
                        errorDetail = ex.Message
                    });
                }
            }
        }
    }
}
