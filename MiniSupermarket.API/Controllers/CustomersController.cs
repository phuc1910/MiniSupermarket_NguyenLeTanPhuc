using Microsoft.AspNetCore.Mvc; // Controller API
using Microsoft.EntityFrameworkCore; // EF Core
using Microsoft.AspNetCore.Authorization; // Phân quyền
using MiniSupermarket.API.Data; // DbContext
using MiniSupermarket.API.Models; // Model Customer

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")] // URL: api/Customers
    [ApiController] // Controller API
    [Authorize] // Phải có JWT Token
    public class CustomersController : ControllerBase
    {
        private readonly SupermarketDbContext _context; // Kết nối Database

        // Tiêm DbContext vào Controller
        public CustomersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        // Lấy toàn bộ khách hàng
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Customers
                .AsNoTracking()
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/Customers/1
        // Lấy khách hàng theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng!"
                });
            }

            return Ok(customer);
        }

        // GET: api/Customers/search?keyword=Nguyen
        // Tìm theo tên hoặc số điện thoại
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new
                {
                    message = "Vui lòng nhập từ khóa!"
                });
            }

            var result = await _context.Customers
                .Where(c =>
                    c.CustomerName.Contains(keyword) ||
                    c.PhoneNumber.Contains(keyword))
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        // POST: api/Customers
        // Thêm khách hàng
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Thêm vào Database
            _context.Customers.Add(newCustomer);

            // Lưu thay đổi
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = newCustomer.CustomerId },
                newCustomer
            );
        }

        // PUT: api/Customers/1
        // Cập nhật khách hàng
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] Customer updateCustomer)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng cần sửa!"
                });
            }

            customer.CustomerName = updateCustomer.CustomerName;
            customer.PhoneNumber = updateCustomer.PhoneNumber;
            customer.Address = updateCustomer.Address;
            customer.RewardPoints = updateCustomer.RewardPoints;
            customer.MembershipRank = updateCustomer.MembershipRank;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Cập nhật khách hàng thành công!"
            });
        }

        // DELETE: api/Customers/1
        // Xóa khách hàng
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng cần xóa!"
                });
            }

            // Xóa khách hàng
            _context.Customers.Remove(customer);

            // Lưu thay đổi
            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Xóa khách hàng thành công!"
            });
        }
    }
}
