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
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

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
                new Customer { CustomerId = 20, CustomerName = "Sơn Tùng M-TP", PhoneNumber = "0989122334", Address = "1 Công Trường Lam Sơn, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh", MembershipRank = "Kim cương", RewardPoints = 2000 }
                );

            // 1. Seed Data cho bảng Users (15 nhân viên theo danh sách mới)
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin01", PasswordHash = "123456", FullName = "Nguyễn Quản Trị", Role = "Admin", IsActive = true },
                new User { UserId = 2, Username = "admin02", PasswordHash = "123456", FullName = "Trần Giám Đốc", Role = "Admin", IsActive = true },
                new User { UserId = 3, Username = "cashier01", PasswordHash = "123456", FullName = "Lê Thu Ngân", Role = "Cashier", IsActive = true },
                new User { UserId = 4, Username = "cashier02", PasswordHash = "123456", FullName = "Phạm Bán Hàng", Role = "Cashier", IsActive = true },
                new User { UserId = 5, Username = "cashier03", PasswordHash = "123456", FullName = "Hoàng Thu Ngân", Role = "Cashier", IsActive = true },
                new User { UserId = 6, Username = "cashier04", PasswordHash = "123456", FullName = "Vũ Thị Quầy", Role = "Cashier", IsActive = true },
                new User { UserId = 7, Username = "cashier05", PasswordHash = "123456", FullName = "Đỗ Bán Lẻ", Role = "Cashier", IsActive = true },
                new User { UserId = 8, Username = "ware01", PasswordHash = "123456", FullName = "Ngô Quản Kho", Role = "Warehouse", IsActive = true },
                new User { UserId = 9, Username = "ware02", PasswordHash = "123456", FullName = "Bùi Kiểm Kê", Role = "Warehouse", IsActive = true },
                new User { UserId = 10, Username = "ware03", PasswordHash = "123456", FullName = "Dương Thủ Kho", Role = "Warehouse", IsActive = true },
                new User { UserId = 11, Username = "ware04", PasswordHash = "123456", FullName = "Lý Nhập Hàng", Role = "Warehouse", IsActive = true },
                new User { UserId = 12, Username = "admin_backup", PasswordHash = "123456", FullName = "Đặng Hỗ Trợ", Role = "Admin", IsActive = true },
                new User { UserId = 13, Username = "cashier06", PasswordHash = "123456", FullName = "Hồ Ca Chiều", Role = "Cashier", IsActive = true },
                new User { UserId = 14, Username = "ware05", PasswordHash = "123456", FullName = "Trương Vận Chuyển", Role = "Warehouse", IsActive = true },
                new User { UserId = 15, Username = "supervisor", PasswordHash = "123456", FullName = "Mai Giám Sát", Role = "Admin", IsActive = true }
            );

            // 2. Seed Data cho bảng Orders (20 hóa đơn bán hàng - Cập nhật CashierUsername khớp với danh sách 15 Users mới)
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, OrderCode = "HD-20260301-001", CreatedDate = new DateTime(2026, 3, 1, 9, 15, 0), CashierUsername = "cashier01", CustomerId = 1, TotalItems = 2, FinalAmount = 1030000, RewardPoints = 10 },
                new Order { OrderId = 2, OrderCode = "HD-20260301-002", CreatedDate = new DateTime(2026, 3, 1, 10, 30, 0), CashierUsername = "cashier02", CustomerId = 2, TotalItems = 1, FinalAmount = 780000, RewardPoints = 7 },
                new Order { OrderId = 3, OrderCode = "HD-20260302-001", CreatedDate = new DateTime(2026, 3, 2, 11, 0, 0), CashierUsername = "cashier01", CustomerId = 3, TotalItems = 3, FinalAmount = 980000, RewardPoints = 9 },
                new Order { OrderId = 4, OrderCode = "HD-20260302-002", CreatedDate = new DateTime(2026, 3, 2, 14, 20, 0), CashierUsername = "cashier03", CustomerId = 4, TotalItems = 1, FinalAmount = 95000, RewardPoints = 1 },
                new Order { OrderId = 5, OrderCode = "HD-20260303-001", CreatedDate = new DateTime(2026, 3, 3, 15, 45, 0), CashierUsername = "cashier02", CustomerId = 5, TotalItems = 2, FinalAmount = 570000, RewardPoints = 5 },
                new Order { OrderId = 6, OrderCode = "HD-20260303-002", CreatedDate = new DateTime(2026, 3, 3, 16, 10, 0), CashierUsername = "cashier04", CustomerId = 6, TotalItems = 1, FinalAmount = 185000, RewardPoints = 1 },
                new Order { OrderId = 7, OrderCode = "HD-20260304-001", CreatedDate = new DateTime(2026, 3, 4, 8, 50, 0), CashierUsername = "cashier01", CustomerId = 7, TotalItems = 2, FinalAmount = 760000, RewardPoints = 7 },
                new Order { OrderId = 8, OrderCode = "HD-20260304-002", CreatedDate = new DateTime(2026, 3, 4, 13, 15, 0), CashierUsername = "cashier05", CustomerId = 8, TotalItems = 1, FinalAmount = 420000, RewardPoints = 4 },
                new Order { OrderId = 9, OrderCode = "HD-20260305-001", CreatedDate = new DateTime(2026, 3, 5, 17, 30, 0), CashierUsername = "cashier03", CustomerId = 9, TotalItems = 2, FinalAmount = 690000, RewardPoints = 6 },
                new Order { OrderId = 10, OrderCode = "HD-20260305-002", CreatedDate = new DateTime(2026, 3, 5, 19, 0, 0), CashierUsername = "cashier02", CustomerId = 10, TotalItems = 1, FinalAmount = 450000, RewardPoints = 4 },
                new Order { OrderId = 11, OrderCode = "HD-20260306-001", CreatedDate = new DateTime(2026, 3, 6, 10, 0, 0), CashierUsername = "cashier06", CustomerId = 11, TotalItems = 2, FinalAmount = 740000, RewardPoints = 7 },
                new Order { OrderId = 12, OrderCode = "HD-20260306-002", CreatedDate = new DateTime(2026, 3, 6, 11, 40, 0), CashierUsername = "cashier01", CustomerId = 12, TotalItems = 1, FinalAmount = 590000, RewardPoints = 5 },
                new Order { OrderId = 13, OrderCode = "HD-20260307-001", CreatedDate = new DateTime(2026, 3, 7, 14, 0, 0), CashierUsername = "cashier04", CustomerId = 13, TotalItems = 2, FinalAmount = 1030000, RewardPoints = 10 },
                new Order { OrderId = 14, OrderCode = "HD-20260307-002", CreatedDate = new DateTime(2026, 3, 7, 18, 25, 0), CashierUsername = "cashier05", CustomerId = 14, TotalItems = 1, FinalAmount = 250000, RewardPoints = 2 },
                new Order { OrderId = 15, OrderCode = "HD-20260308-001", CreatedDate = new DateTime(2026, 3, 8, 9, 30, 0), CashierUsername = "cashier02", CustomerId = 15, TotalItems = 3, FinalAmount = 1095000, RewardPoints = 10 },
                new Order { OrderId = 16, OrderCode = "HD-20260308-002", CreatedDate = new DateTime(2026, 3, 8, 12, 10, 0), CashierUsername = "cashier03", CustomerId = 16, TotalItems = 1, FinalAmount = 320000, RewardPoints = 3 },
                new Order { OrderId = 17, OrderCode = "HD-20260309-001", CreatedDate = new DateTime(2026, 3, 9, 15, 0, 0), CashierUsername = "cashier06", CustomerId = 17, TotalItems = 2, FinalAmount = 840000, RewardPoints = 8 },
                new Order { OrderId = 18, OrderCode = "HD-20260309-002", CreatedDate = new DateTime(2026, 3, 9, 16, 45, 0), CashierUsername = "cashier01", CustomerId = 18, TotalItems = 1, FinalAmount = 190000, RewardPoints = 1 },
                new Order { OrderId = 19, OrderCode = "HD-20260310-001", CreatedDate = new DateTime(2026, 3, 10, 10, 15, 0), CashierUsername = "cashier06", CustomerId = 19, TotalItems = 2, FinalAmount = 760000, RewardPoints = 7 },
                new Order { OrderId = 20, OrderCode = "HD-20260310-002", CreatedDate = new DateTime(2026, 3, 10, 20, 0, 0), CashierUsername = "cashier02", CustomerId = 20, TotalItems = 1, FinalAmount = 520000, RewardPoints = 5 }
            );

            // 3. Seed Data cho bảng OrderDetails (20 chi tiết hóa đơn giữ nguyên tính toàn vẹn)
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { OrderDetailId = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 850000, LineTotal = 850000 },
                new OrderDetail { OrderDetailId = 2, OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 180000, LineTotal = 180000 },
                new OrderDetail { OrderDetailId = 3, OrderId = 2, ProductId = 4, Quantity = 1, UnitPrice = 780000, LineTotal = 780000 },
                new OrderDetail { OrderDetailId = 4, OrderId = 3, ProductId = 3, Quantity = 2, UnitPrice = 25000, LineTotal = 50000 },
                new OrderDetail { OrderDetailId = 5, OrderId = 3, ProductId = 7, Quantity = 1, UnitPrice = 650000, LineTotal = 650000 },
                new OrderDetail { OrderDetailId = 6, OrderId = 3, ProductId = 10, Quantity = 1, UnitPrice = 190000, LineTotal = 190000 },
                new OrderDetail { OrderDetailId = 7, OrderId = 4, ProductId = 8, Quantity = 1, UnitPrice = 95000, LineTotal = 95000 },
                new OrderDetail { OrderDetailId = 8, OrderId = 5, ProductId = 5, Quantity = 1, UnitPrice = 175000, LineTotal = 175000 },
                new OrderDetail { OrderDetailId = 9, OrderId = 5, ProductId = 14, Quantity = 1, UnitPrice = 380000, LineTotal = 380000 },
                new OrderDetail { OrderDetailId = 10, OrderId = 6, ProductId = 11, Quantity = 1, UnitPrice = 185000, LineTotal = 185000 },
                new OrderDetail { OrderDetailId = 11, OrderId = 7, ProductId = 9, Quantity = 2, UnitPrice = 380000, LineTotal = 760000 },
                new OrderDetail { OrderDetailId = 12, OrderId = 8, ProductId = 15, Quantity = 1, UnitPrice = 420000, LineTotal = 420000 },
                new OrderDetail { OrderDetailId = 13, OrderId = 9, ProductId = 17, Quantity = 1, UnitPrice = 340000, LineTotal = 340000 },
                new OrderDetail { OrderDetailId = 14, OrderId = 9, ProductId = 16, Quantity = 1, UnitPrice = 350000, LineTotal = 350000 },
                new OrderDetail { OrderDetailId = 15, OrderId = 10, ProductId = 18, Quantity = 1, UnitPrice = 450000, LineTotal = 450000 },
                new OrderDetail { OrderDetailId = 16, OrderId = 11, ProductId = 12, Quantity = 1, UnitPrice = 240000, LineTotal = 240000 },
                new OrderDetail { OrderDetailId = 17, OrderId = 11, ProductId = 13, Quantity = 1, UnitPrice = 520000, LineTotal = 520000 },
                new OrderDetail { OrderDetailId = 18, OrderId = 12, ProductId = 20, Quantity = 1, UnitPrice = 590000, LineTotal = 590000 },
                new OrderDetail { OrderDetailId = 19, OrderId = 13, ProductId = 1, Quantity = 1, UnitPrice = 850000, LineTotal = 850000 },
                new OrderDetail { OrderDetailId = 20, OrderId = 13, ProductId = 2, Quantity = 1, UnitPrice = 180000, LineTotal = 180000 }
            );
        }
    }
}
