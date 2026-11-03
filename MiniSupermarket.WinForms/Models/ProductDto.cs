using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSupermarket.WinForms.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string Barcode { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        // Các giá trị này do API tính; máy khách chỉ dùng để hiển thị.
        public bool IsLowStock { get; set; }

        public string StockStatus { get; set; } = string.Empty;

        public int LowStockThreshold { get; set; }
    }

    // [BUỔI 6] Cấu trúc phân trang do API trả về (khớp PagedResult<T> bên API)
    public class PagedViewResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new();
    }

    public class ProductPagedViewResult : PagedViewResult<ProductDto>
    {
        public int TotalLowStockItems { get; set; }
        public int LowStockThreshold { get; set; }
    }
}
