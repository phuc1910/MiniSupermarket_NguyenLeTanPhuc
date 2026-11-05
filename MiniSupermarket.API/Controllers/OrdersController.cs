/*
 * Ho ten sinh vien: Nguyen Le Tan Phuc
 * Ma sinh vien: 2124110108
 * Mo ta: API Thanh toan POS da bang duoc bao ve boi SqlTransaction (ACID)
 *        Route khop voi FormPOS: POST api/orders/checkout
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SupermarketDbContext _context;

        // Quy tắc đổi điểm: mỗi điểm được giảm 1.000 đồng.
        private const decimal PointValue = 1000m;

        // ADO.NET xử lý giao dịch; EF Core phục vụ các truy vấn báo cáo chỉ đọc.
        public OrdersController(IConfiguration configuration, SupermarketDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // GET: api/orders?fromDate=2026-10-01&toDate=2026-10-31&pageNumber=1&pageSize=5
        [HttpGet]
        [Authorize(Roles = "Admin,Cashier")]
        public async Task<IActionResult> GetOrders(
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            DateTime? fromDay = fromDate?.Date;
            DateTime? toDay = toDate?.Date;

            if (fromDay.HasValue && toDay.HasValue && fromDay.Value > toDay.Value)
            {
                return BadRequest(new { message = "Từ ngày không được lớn hơn đến ngày!" });
            }
            if (toDay == DateTime.MaxValue.Date)
            {
                return BadRequest(new { message = "Đến ngày phải nhỏ hơn ngày 31/12/9999!" });
            }

            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1 || pageSize > 100) pageSize = 5;
            long skip = ((long)pageNumber - 1) * pageSize;
            if (skip > int.MaxValue)
            {
                return BadRequest(new { message = "Số trang vượt quá giới hạn cho phép!" });
            }

            var query = _context.Orders.AsNoTracking().AsQueryable();
            if (fromDay.HasValue)
            {
                DateTime fromValue = fromDay.Value;
                query = query.Where(o => o.CreatedDate >= fromValue);
            }
            if (toDay.HasValue)
            {
                // Mốc cuối loại trừ để lấy cả phần giây lẻ của ngày được chọn.
                DateTime toExclusive = toDay.Value.AddDays(1);
                query = query.Where(o => o.CreatedDate < toExclusive);
            }

            int totalItems = await query.CountAsync();
            decimal totalRevenue = await query.SumAsync(o => (decimal?)o.FinalAmount) ?? 0m;
            var items = await query
                .OrderByDescending(o => o.CreatedDate)
                .ThenByDescending(o => o.OrderId)
                .Skip((int)skip)
                .Take(pageSize)
                .Select(o => new OrderReportItemDto
                {
                    OrderId = o.OrderId,
                    OrderCode = o.OrderCode,
                    CreatedDate = o.CreatedDate,
                    CashierUsername = o.CashierUsername,
                    CustomerName = o.Customer != null ? o.Customer.CustomerName : "Khách vãng lai",
                    CustomerPhone = o.Customer != null ? o.Customer.PhoneNumber : string.Empty,
                    TotalItems = o.TotalItems,
                    FinalAmount = o.FinalAmount,
                    RewardPoints = o.RewardPoints
                })
                .ToListAsync();

            return Ok(new PagedOrderReportDto
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize),
                TotalRevenue = totalRevenue,
                Items = items
            });
        }

        // GET: api/orders/1 - phép chiếu cả header và các dòng hàng, không truy vấn từng sản phẩm.
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Cashier")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _context.Orders
                .AsNoTracking()
                .Where(o => o.OrderId == id)
                .Select(o => new OrderDetailReportDto
                {
                    OrderId = o.OrderId,
                    OrderCode = o.OrderCode,
                    CreatedDate = o.CreatedDate,
                    CashierUsername = o.CashierUsername,
                    CustomerName = o.Customer != null ? o.Customer.CustomerName : "Khách vãng lai",
                    CustomerPhone = o.Customer != null ? o.Customer.PhoneNumber : string.Empty,
                    TotalItems = o.TotalItems,
                    FinalAmount = o.FinalAmount,
                    RewardPoints = o.RewardPoints,
                    Items = o.OrderDetails
                        .OrderBy(d => d.OrderDetailId)
                        .Select(d => new OrderLineReportDto
                        {
                            ProductId = d.ProductId,
                            Barcode = d.Product != null ? d.Product.Barcode : string.Empty,
                            ProductName = d.Product != null ? d.Product.ProductName : "(Đã xóa)",
                            Quantity = d.Quantity,
                            UnitPrice = d.UnitPrice,
                            LineTotal = d.LineTotal
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return NotFound(new { message = "Không tìm thấy hóa đơn!" });
            }

            return Ok(order);
        }

        // =========================================================================
        // POST: api/orders/checkout
        // Tạo hóa đơn, lưu chi tiết, trừ tồn kho, cộng điểm - tất cả trong 1 Transaction
        // Chỉ Admin và Cashier được bán hàng (Warehouse không có màn hình POS)
        // =========================================================================
        [HttpPost("checkout")]
        [Authorize(Roles = "Admin,Cashier")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequestDto request)
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

            if (request.CashReceived < 0)
            {
                return BadRequest(new { message = "Tiền khách đưa không được âm!" });
            }

            if (request.PointsToRedeem < 0 ||
                (request.UsePoints && request.PointsToRedeem == 0) ||
                (!request.UsePoints && request.PointsToRedeem != 0))
            {
                return BadRequest(new { message = "Khi dùng điểm phải nhập số điểm muốn đổi lớn hơn 0; không dùng điểm thì số điểm đổi phải bằng 0!" });
            }

            // Số lượng âm sẽ làm TĂNG tồn kho thay vì trừ -> phải chặn từ đầu
            if (request.Items.Any(i => i.Quantity <= 0))
            {
                return BadRequest(new { message = "Số lượng của mỗi mặt hàng phải lớn hơn 0!" });
            }

            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // 2. BẮT ĐẦU TRANSACTION: từ đây mọi lệnh phải gắn transaction
                SqlTransaction transaction = (SqlTransaction)await connection.BeginTransactionAsync();

                try
                {
                    // ---------------------------------------------------------------
                    // Tra khách hàng theo số điện thoại (không có / không thấy = vãng lai)
                    // ---------------------------------------------------------------
                    int? customerId = null;
                    string customerName = "Khách vãng lai";
                    int customerPoints = 0; // [TC 47] điểm hiện có của khách, đọc trong Transaction

                    if (!string.IsNullOrWhiteSpace(request.CustomerPhone))
                    {
                        // UPDLOCK khóa dòng khách hàng đến hết Transaction: 2 quầy POS không thể cùng dùng một lượng điểm
                        string findSql = @"SELECT CustomerId, CustomerName, RewardPoints
                                           FROM Customers WITH (UPDLOCK, ROWLOCK)
                                           WHERE PhoneNumber = @Phone";

                        using (SqlCommand cmdFind = new SqlCommand(findSql, connection, transaction))
                        {
                            cmdFind.Parameters.AddWithValue("@Phone", request.CustomerPhone.Trim());

                            using (SqlDataReader reader = await cmdFind.ExecuteReaderAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    customerId = Convert.ToInt32(reader["CustomerId"]);
                                    customerName = reader["CustomerName"].ToString() ?? customerName;
                                    customerPoints = Convert.ToInt32(reader["RewardPoints"]);
                                }
                            }
                        }
                    }

                    // Tổng tiền hàng, tổng số lượng
                    decimal subtotal = request.Items.Sum(i => i.Quantity * i.UnitPrice);
                    int totalItems = request.Items.Sum(i => i.Quantity);

                    // ---------------------------------------------------------------
                    // [TC 47] Đổi điểm thưởng trừ tiền: kiểm tra điều kiện NGAY trong Transaction.
                    // Sai điều kiện -> ném lỗi -> nhảy xuống catch -> Rollback, không lưu gì cả.
                    // ---------------------------------------------------------------
                    decimal discountAmount = 0;
                    int pointsRedeemed = 0;

                    if (request.UsePoints)
                    {
                        if (!customerId.HasValue)
                        {
                            throw new InvalidOperationException("Cần nhập đúng SĐT khách hàng thân thiết mới được dùng điểm!");
                        }
                        if (request.PointsToRedeem > customerPoints)
                        {
                            throw new InvalidOperationException(
                                $"Khách hàng chỉ có {customerPoints} điểm, không thể đổi {request.PointsToRedeem} điểm!");
                        }
                        if (request.PointsToRedeem * PointValue > subtotal)
                        {
                            throw new InvalidOperationException(
                                $"Chỉ được đổi tối đa {Math.Floor(subtotal / PointValue):N0} điểm cho hóa đơn {subtotal:N0} đ!");
                        }

                        pointsRedeemed = request.PointsToRedeem;
                        discountAmount = pointsRedeemed * PointValue;
                    }

                    // Số tiền thực thu (FinalAmount) = tiền hàng - tiền giảm từ điểm
                    decimal finalAmount = subtotal - discountAmount;

                    // Kiểm tra lại ở server trước khi lưu hóa đơn, trừ kho và thay đổi điểm.
                    if (finalAmount > 0 && request.CashReceived <= finalAmount)
                    {
                        throw new InvalidOperationException(
                            $"Tiền khách đưa phải lớn hơn tổng cần thanh toán ({finalAmount:N0} đ)!");
                    }

                    // Điểm thưởng mới (10.000đ = 1 điểm, chỉ khi có khách) tính trên số tiền khách thực trả
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

                        orderId = Convert.ToInt32(await cmdOrder.ExecuteScalarAsync());
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

                            using (SqlDataReader reader = await cmdCheck.ExecuteReaderAsync())
                            {
                                if (!await reader.ReadAsync())
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
                            await cmdDetail.ExecuteNonQueryAsync();
                        }

                        // Trừ tồn kho
                        string updateStockSql = @"UPDATE Products
                                                  SET StockQuantity = StockQuantity - @Qty
                                                  WHERE ProductId = @ProductId";

                        using (SqlCommand cmdStock = new SqlCommand(updateStockSql, connection, transaction))
                        {
                            cmdStock.Parameters.AddWithValue("@Qty", item.Quantity);
                            cmdStock.Parameters.AddWithValue("@ProductId", item.ProductId);
                            await cmdStock.ExecuteNonQueryAsync();
                        }
                    }

                    // ---------------------------------------------------------------
                    // ---------------------------------------------------------------
                    // BƯỚC 4: Cập nhật điểm tích lũy của khách trong CÙNG Transaction:
                    //   điểm mới = điểm cũ - điểm đã dùng + điểm thưởng của hóa đơn này
                    // Điều kiện RewardPoints >= @Redeem chặn trường hợp điểm bị trừ âm
                    // ---------------------------------------------------------------
                    if (customerId.HasValue && (rewardPoints > 0 || pointsRedeemed > 0))
                    {
                        string updatePointsSql = @"UPDATE Customers
                                                   SET RewardPoints = RewardPoints - @Redeem + @Earned
                                                   WHERE CustomerId = @CustomerId AND RewardPoints >= @Redeem";

                        using (SqlCommand cmdPoints = new SqlCommand(updatePointsSql, connection, transaction))
                        {
                            cmdPoints.Parameters.AddWithValue("@Redeem", pointsRedeemed);
                            cmdPoints.Parameters.AddWithValue("@Earned", rewardPoints);
                            cmdPoints.Parameters.AddWithValue("@CustomerId", customerId.Value);

                            int affected = await cmdPoints.ExecuteNonQueryAsync();
                            if (affected == 0)
                            {
                                throw new InvalidOperationException("Không thể trừ điểm của khách hàng (không đủ điểm)!");
                            }
                        }
                    }

                    // BƯỚC 5: Mọi thứ thành công -> XÁC NHẬN LƯU VĨNH VIỄN
                    await transaction.CommitAsync();

                    return Ok(new
                    {
                        success = true,
                        message = "Thanh toán hóa đơn POS thành công!",
                        orderId = orderId,
                        orderCode = orderCode,
                        customerName = customerName,
                        totalItems = totalItems,
                        subtotal = subtotal,
                        discountAmount = discountAmount,
                        pointsRedeemed = pointsRedeemed,
                        finalAmount = finalAmount,
                        rewardPointsAdded = rewardPoints
                    });
                }
                catch (Exception ex)
                {
                    // BƯỚC 6: Có bất kỳ lỗi nào -> HOÀN TÁC TOÀN BỘ
                    try
                    {
                        await transaction.RollbackAsync();
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
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlTransaction transaction = (SqlTransaction)await connection.BeginTransactionAsync();

                try
                {
                    // 1. Kiểm tra hóa đơn tồn tại, lấy khách hàng và điểm thưởng đã tặng
                    int? customerId = null;
                    int pointsToDeduct = 0;
                    decimal finalAmountPaid = 0; // [TC 47] số tiền khách đã thực trả (sau khi trừ điểm)

                    using (SqlCommand cmdGet = new SqlCommand(
                        "SELECT CustomerId, RewardPoints, FinalAmount FROM Orders WHERE OrderId = @OrderId", connection, transaction))
                    {
                        cmdGet.Parameters.AddWithValue("@OrderId", orderId);

                        using (SqlDataReader reader = await cmdGet.ExecuteReaderAsync())
                        {
                            if (!await reader.ReadAsync())
                            {
                                throw new InvalidOperationException($"Không tìm thấy hóa đơn ID = {orderId} để hủy!");
                            }

                            // Hóa đơn của khách vãng lai có CustomerId = NULL
                            if (reader["CustomerId"] != DBNull.Value)
                            {
                                customerId = Convert.ToInt32(reader["CustomerId"]);
                            }
                            pointsToDeduct = Convert.ToInt32(reader["RewardPoints"]);
                            finalAmountPaid = Convert.ToDecimal(reader["FinalAmount"]);
                        }
                    }

                    // 2. Đọc hết chi tiết vào danh sách RAM TRƯỚC khi cập nhật
                    //    (không chạy lệnh khác khi reader còn mở)
                    var itemsToRestore = new List<(int ProductId, int Quantity)>();
                    decimal linesTotal = 0; // [TC 47] tổng tiền hàng trước khi trừ điểm

                    using (SqlCommand cmdDetails = new SqlCommand(
                        "SELECT ProductId, Quantity, LineTotal FROM OrderDetails WHERE OrderId = @OrderId", connection, transaction))
                    {
                        cmdDetails.Parameters.AddWithValue("@OrderId", orderId);

                        using (SqlDataReader reader = await cmdDetails.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                itemsToRestore.Add((
                                    Convert.ToInt32(reader["ProductId"]),
                                    Convert.ToInt32(reader["Quantity"])));
                                linesTotal += Convert.ToDecimal(reader["LineTotal"]);
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
                            await cmdRestore.ExecuteNonQueryAsync();
                        }
                    }

                    // 4. Thu hồi điểm thưởng đã tặng VÀ hoàn lại điểm khách đã dùng để trừ tiền (nếu có)
                    // Tiền giảm = tổng chi tiết - FinalAmount; hoàn đúng số điểm đã đổi theo tỷ lệ 1.000 đ/điểm.
                    decimal discountGiven = Math.Max(0, linesTotal - finalAmountPaid);
                    int pointsToRefund = (int)(discountGiven / PointValue);

                    if (customerId.HasValue && (pointsToDeduct > 0 || pointsToRefund > 0))
                    {
                        string deductSql = @"UPDATE Customers
                                             SET RewardPoints = (CASE WHEN RewardPoints >= @Pts
                                                                      THEN RewardPoints - @Pts ELSE 0 END) + @Refund
                                             WHERE CustomerId = @CustomerId";

                        using (SqlCommand cmdDeduct = new SqlCommand(deductSql, connection, transaction))
                        {
                            cmdDeduct.Parameters.AddWithValue("@Pts", pointsToDeduct);
                            cmdDeduct.Parameters.AddWithValue("@Refund", pointsToRefund);
                            cmdDeduct.Parameters.AddWithValue("@CustomerId", customerId.Value);
                            await cmdDeduct.ExecuteNonQueryAsync();
                        }
                    }

                    // 5. Xóa chi tiết trước (bảng con), sau đó xóa hóa đơn (bảng cha) để không vi phạm khóa ngoại
                    using (SqlCommand cmdDelDetails = new SqlCommand(
                        "DELETE FROM OrderDetails WHERE OrderId = @OrderId", connection, transaction))
                    {
                        cmdDelDetails.Parameters.AddWithValue("@OrderId", orderId);
                        await cmdDelDetails.ExecuteNonQueryAsync();
                    }

                    using (SqlCommand cmdDelOrder = new SqlCommand(
                        "DELETE FROM Orders WHERE OrderId = @OrderId", connection, transaction))
                    {
                        cmdDelOrder.Parameters.AddWithValue("@OrderId", orderId);
                        await cmdDelOrder.ExecuteNonQueryAsync();
                    }

                    // 6. Xác nhận lưu vĩnh viễn
                    await transaction.CommitAsync();

                    return Ok(new
                    {
                        success = true,
                        message = $"Đã hủy hóa đơn #{orderId} và hoàn trả tồn kho vào CSDL!"
                    });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

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
