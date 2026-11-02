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

        // Phép chiếu Entity -> DTO: không trả nguyên Entity CSDL ra ngoài
        private static CustomerItemDto ToDto(Customer c) => new CustomerItemDto
        {
            CustomerId = c.CustomerId,
            CustomerName = c.CustomerName,
            PhoneNumber = c.PhoneNumber,
            Address = c.Address,
            RewardPoints = c.RewardPoints,
            MembershipRank = c.MembershipRank,
            CreatedDate = c.CreatedDate
        };

        // GET: api/Customers
        // Lấy toàn bộ khách hàng (trả về DTO)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Customers
                .AsNoTracking()
                .OrderBy(c => c.CustomerId)
                .Select(c => new CustomerItemDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    RewardPoints = c.RewardPoints,
                    MembershipRank = c.MembershipRank,
                    CreatedDate = c.CreatedDate
                })
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/Customers/1
        // Lấy khách hàng theo ID (trả về DTO)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng!"
                });
            }

            return Ok(ToDto(customer));
        }

        // [BUỔI 6 - Bài tập 6.1] GET: api/Customers/paged?keyword=an&pageNumber=1&pageSize=5
        // Phân trang khách hàng thân thiết, sắp xếp tăng dần theo Mã KH (CustomerId)
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedCustomers(
            [FromQuery] string? keyword,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1 || pageSize > 50) pageSize = 5;

            var query = _context.Customers.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string search = keyword.Trim();
                query = query.Where(c => c.CustomerName.Contains(search) || c.PhoneNumber.Contains(search));
            }

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var items = await query
                .OrderBy(c => c.CustomerId) // Sắp xếp theo Mã KH tăng dần
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CustomerItemDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    RewardPoints = c.RewardPoints,
                    MembershipRank = c.MembershipRank,
                    CreatedDate = c.CreatedDate
                })
                .ToListAsync();

            return Ok(new PagedResult<CustomerItemDto>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            });
        }

        // GET: api/Customers/search?keyword=Nguyen
        // Tìm theo tên hoặc số điện thoại (trả về DTO)
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

            string search = keyword.Trim();

            var result = await _context.Customers
                .AsNoTracking()
                .Where(c =>
                    c.CustomerName.Contains(search) ||
                    c.PhoneNumber.Contains(search))
                .OrderBy(c => c.CustomerId)
                .Select(c => new CustomerItemDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    RewardPoints = c.RewardPoints,
                    MembershipRank = c.MembershipRank,
                    CreatedDate = c.CreatedDate
                })
                .ToListAsync();

            return Ok(result);
        }

        // POST: api/Customers
        // Thêm khách hàng - nhận CustomerRequestDto (không nhận thẳng Entity)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CustomerRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string phone = dto.PhoneNumber.Trim();

            // PhoneNumber có Unique Index: kiểm tra trước để trả 409 thay vì lỗi 500
            if (await _context.Customers.AnyAsync(c => c.PhoneNumber == phone))
            {
                return Conflict(new { message = "Số điện thoại đã được đăng ký!" });
            }

            var newCustomer = new Customer
            {
                CustomerName = dto.CustomerName.Trim(),
                PhoneNumber = phone,
                Address = dto.Address,
                RewardPoints = dto.RewardPoints,
                MembershipRank = dto.MembershipRank,
                // [TC 44] Ghi nhận thời điểm đăng ký khách hàng
                CreatedDate = DateTime.Now
            };

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = newCustomer.CustomerId },
                ToDto(newCustomer)
            );
        }

        // PUT: api/Customers/1
        // Cập nhật khách hàng - nhận CustomerRequestDto
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng cần sửa!"
                });
            }

            string phone = dto.PhoneNumber.Trim();

            if (await _context.Customers.AnyAsync(c => c.PhoneNumber == phone && c.CustomerId != id))
            {
                return Conflict(new { message = "Số điện thoại đã được khách hàng khác sử dụng!" });
            }

            customer.CustomerName = dto.CustomerName.Trim();
            customer.PhoneNumber = phone;
            customer.Address = dto.Address;
            customer.RewardPoints = dto.RewardPoints;
            customer.MembershipRank = dto.MembershipRank;

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