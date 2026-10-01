using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Mỹ phẩm Skincare", Description = "Kem dưỡng, serum, toner, sữa rửa mặt chính hãng" },
                new Category { CategoryId = 2, CategoryName = "Trang điểm (Makeup)", Description = "Son môi, phấn nước, kẻ mắt, má hồng" },
                new Category { CategoryId = 3, CategoryName = "Mặt nạ dưỡng da", Description = "Mặt nạ giấy, mặt nạ ngủ, mặt nạ đất sét" },
                new Category { CategoryId = 4, CategoryName = "Chăm sóc tóc & Da đầu", Description = "Dầu gội, dầu xả, ủ tóc, serum dưỡng tóc" },
                new Category { CategoryId = 5, CategoryName = "Chăm sóc cơ thể", Description = "Sữa tắm, dưỡng thể, tẩy tế bào chết body" },
                new Category { CategoryId = 6, CategoryName = "Nước hoa chính hãng", Description = "Nước hoa mini, fullsize, body mist lưu hương" },
                new Category { CategoryId = 7, CategoryName = "Thực phẩm chức năng làm đẹp", Description = "Viên uống collagen, vitamin C, trắng da, chống lão hóa" },
                new Category { CategoryId = 8, CategoryName = "Chăm sóc da tay & chân", Description = "Kem dưỡng da tay, mặt nạ chân, trị nứt nẻ" },
                new Category { CategoryId = 9, CategoryName = "Dụng cụ & Phụ kiện trang điểm", Description = "Cọ trang điểm, bông mút, kẹp bấm mi, gương mini" },
                new Category { CategoryId = 10, CategoryName = "Chăm sóc răng miệng", Description = "Kem đánh răng trắng răng, nước súc miệng, bàn chải" },
                new Category { CategoryId = 11, CategoryName = "Sản phẩm cho nam giới", Description = "Sữa rửa mặt nam, sáp vuốt tóc, bọt cạo râu" },
                new Category { CategoryId = 12, CategoryName = "Chăm sóc mẹ & bé", Description = "Sữa tắm gội em bé, kem chống hăm, dưỡng ẩm da bé" },
                new Category { CategoryId = 13, CategoryName = "Chống nắng & Bảo vệ da", Description = "Kem chống nắng mặt, chống nắng body, xịt chống nắng" },
                new Category { CategoryId = 14, CategoryName = "Sản phẩm trị mụn & Thâm", Description = "Gel chấm mụn, serum trị thâm, miếng dán mụn" },
                new Category { CategoryId = 15, CategoryName = "Tẩy trang & Làm sạch sâu", Description = "Nước tẩy trang, dầu tẩy trang, sáp tẩy trang" },
                new Category { CategoryId = 16, CategoryName = "Tinh dầu & Thư giãn", Description = "Tinh dầu dưỡng da, nến thơm, xịt thơm phòng ngủ" },
                new Category { CategoryId = 17, CategoryName = "Tóc giả & Phụ kiện tóc", Description = "Kẹp tóc, dây buộc tóc hàn quốc, lược gỡ rối" },
                new Category { CategoryId = 18, CategoryName = "Mỹ phẩm mini & Travel size", Description = "Set mini dùng thử, tuýp nhỏ tiện lợi mang đi du lịch" },
                new Category { CategoryId = 19, CategoryName = "Hộp đựng & Tổ chức mỹ phẩm", Description = "Tủ đựng mỹ phẩm trong suốt, túi đựng đồ trang điểm" },
                new Category { CategoryId = 20, CategoryName = "Quà tặng & Set mỹ phẩm", Description = "Hộp quà sinh nhật, set quà lễ hội, túi giấy Hana Shop" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Barcode = "8809123456011", ProductName = "Serum dưỡng ẩm La Roche-Posay Hyalu B5 30ml", Price = 850000, StockQuantity = 25, CategoryId = 1 },
                new Product { ProductId = 2, Barcode = "8809123456012", ProductName = "Son kem lì Romand Blur Fudge Tint", Price = 180000, StockQuantity = 50, CategoryId = 2 },
                new Product { ProductId = 3, Barcode = "8809123456013", ProductName = "Mặt nạ giấy Mediheal Teatree Care Solution Essential", Price = 25000, StockQuantity = 200, CategoryId = 3 },
                new Product { ProductId = 4, Barcode = "8809123456014", ProductName = "Tinh dầu dưỡng tóc Moroccanoil Treatment 100ml", Price = 780000, StockQuantity = 20, CategoryId = 4 },
                new Product { ProductId = 5, Barcode = "8809123456015", ProductName = "Sữa tắm hương nước hoa On The Body Hàn Quốc 500g", Price = 175000, StockQuantity = 45, CategoryId = 5 },
                new Product { ProductId = 6, Barcode = "8809123456016", ProductName = "Xịt thơm toàn thân Body Mist Bath & Body Works 236ml", Price = 320000, StockQuantity = 35, CategoryId = 6 },
                new Product { ProductId = 7, Barcode = "8809123456017", ProductName = "Viên uống Collagen dạng nước InnerB Aqua Rich", Price = 650000, StockQuantity = 15, CategoryId = 7 },
                new Product { ProductId = 8, Barcode = "8809123456018", ProductName = "Kem dưỡng da tay, chống khô nẻ Kamill 75ml", Price = 95000, StockQuantity = 70, CategoryId = 8 },
                new Product { ProductId = 9, Barcode = "8809123456019", ProductName = "Bộ cọ trang điểm cá nhân Real Techniques 4 món", Price = 380000, StockQuantity = 25, CategoryId = 9 },
                new Product { ProductId = 10, Barcode = "8809123456020", ProductName = "Kem đánh răng Marvis Classic Strong Mint 85ml", Price = 190000, StockQuantity = 60, CategoryId = 10 },
                new Product { ProductId = 11, Barcode = "8809123456021", ProductName = "Sáp vuốt tóc nam giữ nếp cao Gatsby Moving Rubber", Price = 185000, StockQuantity = 40, CategoryId = 11 },
                new Product { ProductId = 12, Barcode = "8809123456022", ProductName = "Sữa tắm gội toàn thân Cetaphil Baby 400ml", Price = 240000, StockQuantity = 28, CategoryId = 12 },
                new Product { ProductId = 13, Barcode = "8809123456023", ProductName = "Kem chống nắng nâng tông Anessa Sun Care Milk 60ml", Price = 520000, StockQuantity = 30, CategoryId = 13 },
                new Product { ProductId = 14, Barcode = "8809123456024", ProductName = "Gel giảm mụn cấp tốc chuyên sâu La Roche-Posay Effaclar AI", Price = 380000, StockQuantity = 40, CategoryId = 14 },
                new Product { ProductId = 15, Barcode = "8809123456025", ProductName = "Nước tẩy trang Bioderma Sensibio H2O 500ml", Price = 420000, StockQuantity = 55, CategoryId = 15 },
                new Product { ProductId = 16, Barcode = "8809123456026", ProductName = "Nến thơm phòng hương hoa nhài Yankee Candle", Price = 350000, StockQuantity = 18, CategoryId = 16 },
                new Product { ProductId = 17, Barcode = "8809123456027", ProductName = "Lược gỡ rối chuyên nghiệp Tangle Teezer Original", Price = 340000, StockQuantity = 22, CategoryId = 17 },
                new Product { ProductId = 18, Barcode = "8809123456028", ProductName = "Set dưỡng da mini 4 món Laneige Essential Power", Price = 450000, StockQuantity = 15, CategoryId = 18 },
                new Product { ProductId = 19, Barcode = "8809123456029", ProductName = "Hộp đựng mỹ phẩm trong suốt nhiều ngăn để bàn", Price = 150000, StockQuantity = 25, CategoryId = 19 },
                new Product { ProductId = 20, Barcode = "8809123456030", ProductName = "Set hộp quà mỹ phẩm xách tay cao cấp Hana Shop", Price = 590000, StockQuantity = 10, CategoryId = 20 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nguyễn Thị Hoa", PhoneNumber = "0901122334", Address = "123 Đường Nguyễn Trãi, Phường 2, Quận 5, Thành phố Hồ Chí Minh", MembershipRank = "Vàng", RewardPoints = 150 },
                new Customer { CustomerId = 2, CustomerName = "Trần Thị Mai", PhoneNumber = "0982233445", Address = "45 Đường Lê Văn Việt, Phường Hiệp Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", MembershipRank = "Bạc", RewardPoints = 80 },
                new Customer { CustomerId = 3, CustomerName = "Lê Hoàng Yến", PhoneNumber = "0913344556", Address = "88 Đường Đồng Khởi, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh", MembershipRank = "Kim cương", RewardPoints = 1200 },
                new Customer { CustomerId = 4, CustomerName = "Phạm Quỳnh Anh", PhoneNumber = "0394455667", Address = "12 Đường Cách Mạng Tháng Tám, Phường 7, Quận Tân Bình, Thành phố Hồ Chí Minh", MembershipRank = "Thành viên mới", RewardPoints = 20 },
                new Customer { CustomerId = 5, CustomerName = "Hoàng Thu Thảo", PhoneNumber = "0975566778", Address = "56 Đường Võ Văn Ngân, Phường Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", MembershipRank = "Vàng", RewardPoints = 320 },
                new Customer { CustomerId = 6, CustomerName = "Vũ Minh Thư", PhoneNumber = "0936677889", Address = "99 Đường Phan Xích Long, Phường 2, Quận Phú Nhuận, Thành phố Hồ Chí Minh", MembershipRank = "Bạc", RewardPoints = 95 },
                new Customer { CustomerId = 7, CustomerName = "Đặng Ngọc Hân", PhoneNumber = "0927788990", Address = "234 Đường Hai Bà Trưng, Phường Võ Thị Sáu, Quận 3, Thành phố Hồ Chí Minh", MembershipRank = "Kim cương", RewardPoints = 950 },
                new Customer { CustomerId = 8, CustomerName = "Bùi Thanh Trúc", PhoneNumber = "0868899001", Address = "15 Đường Nguyễn Kiệm, Phường 3, Quận Gò Vấp, Thành phố Hồ Chí Minh", MembershipRank = "Thành viên mới", RewardPoints = 10 },
                new Customer { CustomerId = 9, CustomerName = "Đỗ Mỹ Linh", PhoneNumber = "0949900112", Address = "78 Đường Lê Duẩn, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh", MembershipRank = "Vàng", RewardPoints = 450 },
                new Customer { CustomerId = 10, CustomerName = "Hồ Ngọc Hà", PhoneNumber = "0901011223", Address = "300 Đường Nguyễn Thị Minh Khai, Phường 5, Quận 3, Thành phố Hồ Chí Minh", MembershipRank = "Kim cương", RewardPoints = 1500 },
                new Customer { CustomerId = 11, CustomerName = "Ngô Thanh Vân", PhoneNumber = "0982122334", Address = "11 Đường Tôn Đức Thắng, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh", MembershipRank = "Bạc", RewardPoints = 110 },
                new Customer { CustomerId = 12, CustomerName = "Dương Cẩm Lynh", PhoneNumber = "0913233445", Address = "50 Đường Hoàng Văn Thụ, Phường 15, Quận Phú Nhuận, Thành phố Hồ Chí Minh", MembershipRank = "Thành viên mới", RewardPoints = 35 },
                new Customer { CustomerId = 13, CustomerName = "Lý Nhã Kỳ", PhoneNumber = "0394344556", Address = "77 Đường Thảo Điền, Phường Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh", MembershipRank = "Vàng", RewardPoints = 280 },
                new Customer { CustomerId = 14, CustomerName = "Trương Ngọc Ánh", PhoneNumber = "0975455667", Address = "102 Đường Pasteur, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh", MembershipRank = "Kim cương", RewardPoints = 1100 },
                new Customer { CustomerId = 15, CustomerName = "Phan Như Thảo", PhoneNumber = "0936566778", Address = "45 Đường Thành Thái, Phường 14, Quận 10, Thành phố Hồ Chí Minh", MembershipRank = "Bạc", RewardPoints = 75 },
                new Customer { CustomerId = 16, CustomerName = "Vương Linh Chi", PhoneNumber = "0927677889", Address = "89 Đường Lũy Bán Bích, Phường Tân Thới Hòa, Quận Tân Phú, Thành phố Hồ Chí Minh", MembershipRank = "Thành viên mới", RewardPoints = 15 },
                new Customer { CustomerId = 17, CustomerName = "Đinh Ngọc Diệp", PhoneNumber = "0868788990", Address = "210 Đường Điện Biên Phủ, Phường 17, Quận Bình Thạnh, Thành phố Hồ Chí Minh", MembershipRank = "Vàng", RewardPoints = 510 },
                new Customer { CustomerId = 18, CustomerName = "Cao Thái Sơn", PhoneNumber = "0948900112", Address = "66 Đường Quang Trung, Phường 10, Quận Gò Vấp, Thành phố Hồ Chí Minh", MembershipRank = "Bạc", RewardPoints = 60 },
                new Customer { CustomerId = 19, CustomerName = "Trịnh Thăng Bình", PhoneNumber = "0909011223", Address = "33 Đường Sư Vạn Hạnh, Phường 12, Quận 10, Thành phố Hồ Chí Minh", MembershipRank = "Thành viên mới", RewardPoints = 25 },
                new Customer { CustomerId = 20, CustomerName = "Sơn Tùng M-TP", PhoneNumber = "0989122334", Address = "1 Công Trường Lam Sơn, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh", MembershipRank = "Kim cương", RewardPoints = 2000 });
        }
    }
}
