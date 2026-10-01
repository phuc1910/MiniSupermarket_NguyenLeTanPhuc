using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Mỹ phẩm Skincare", "Kem dưỡng, serum, toner, sữa rửa mặt chính hãng" },
                    { 2, "Trang điểm (Makeup)", "Son môi, phấn nước, kẻ mắt, má hồng" },
                    { 3, "Mặt nạ dưỡng da", "Mặt nạ giấy, mặt nạ ngủ, mặt nạ đất sét" },
                    { 4, "Chăm sóc tóc & Da đầu", "Dầu gội, dầu xả, ủ tóc, serum dưỡng tóc" },
                    { 5, "Chăm sóc cơ thể", "Sữa tắm, dưỡng thể, tẩy tế bào chết body" },
                    { 6, "Nước hoa chính hãng", "Nước hoa mini, fullsize, body mist lưu hương" },
                    { 7, "Thực phẩm chức năng làm đẹp", "Viên uống collagen, vitamin C, trắng da, chống lão hóa" },
                    { 8, "Chăm sóc da tay & chân", "Kem dưỡng da tay, mặt nạ chân, trị nứt nẻ" },
                    { 9, "Dụng cụ & Phụ kiện trang điểm", "Cọ trang điểm, bông mút, kẹp bấm mi, gương mini" },
                    { 10, "Chăm sóc răng miệng", "Kem đánh răng trắng răng, nước súc miệng, bàn chải" },
                    { 11, "Sản phẩm cho nam giới", "Sữa rửa mặt nam, sáp vuốt tóc, bọt cạo râu" },
                    { 12, "Chăm sóc mẹ & bé", "Sữa tắm gội em bé, kem chống hăm, dưỡng ẩm da bé" },
                    { 13, "Chống nắng & Bảo vệ da", "Kem chống nắng mặt, chống nắng body, xịt chống nắng" },
                    { 14, "Sản phẩm trị mụn & Thâm", "Gel chấm mụn, serum trị thâm, miếng dán mụn" },
                    { 15, "Tẩy trang & Làm sạch sâu", "Nước tẩy trang, dầu tẩy trang, sáp tẩy trang" },
                    { 16, "Tinh dầu & Thư giãn", "Tinh dầu dưỡng da, nến thơm, xịt thơm phòng ngủ" },
                    { 17, "Tóc giả & Phụ kiện tóc", "Kẹp tóc, dây buộc tóc hàn quốc, lược gỡ rối" },
                    { 18, "Mỹ phẩm mini & Travel size", "Set mini dùng thử, tuýp nhỏ tiện lợi mang đi du lịch" },
                    { 19, "Hộp đựng & Tổ chức mỹ phẩm", "Tủ đựng mỹ phẩm trong suốt, túi đựng đồ trang điểm" },
                    { 20, "Quà tặng & Set mỹ phẩm", "Hộp quà sinh nhật, set quà lễ hội, túi giấy Hana Shop" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "8809123456011", 1, 850000m, "Serum dưỡng ẩm La Roche-Posay Hyalu B5 30ml", 25 },
                    { 2, "8809123456012", 2, 180000m, "Son kem lì Romand Blur Fudge Tint", 50 },
                    { 3, "8809123456013", 3, 25000m, "Mặt nạ giấy Mediheal Teatree Care Solution Essential", 200 },
                    { 4, "8809123456014", 4, 780000m, "Tinh dầu dưỡng tóc Moroccanoil Treatment 100ml", 20 },
                    { 5, "8809123456015", 5, 175000m, "Sữa tắm hương nước hoa On The Body Hàn Quốc 500g", 45 },
                    { 6, "8809123456016", 6, 320000m, "Xịt thơm toàn thân Body Mist Bath & Body Works 236ml", 35 },
                    { 7, "8809123456017", 7, 650000m, "Viên uống Collagen dạng nước InnerB Aqua Rich", 15 },
                    { 8, "8809123456018", 8, 95000m, "Kem dưỡng da tay, chống khô nẻ Kamill 75ml", 70 },
                    { 9, "8809123456019", 9, 380000m, "Bộ cọ trang điểm cá nhân Real Techniques 4 món", 25 },
                    { 10, "8809123456020", 10, 190000m, "Kem đánh răng Marvis Classic Strong Mint 85ml", 60 },
                    { 11, "8809123456021", 11, 185000m, "Sáp vuốt tóc nam giữ nếp cao Gatsby Moving Rubber", 40 },
                    { 12, "8809123456022", 12, 240000m, "Sữa tắm gội toàn thân Cetaphil Baby 400ml", 28 },
                    { 13, "8809123456023", 13, 520000m, "Kem chống nắng nâng tông Anessa Sun Care Milk 60ml", 30 },
                    { 14, "8809123456024", 14, 380000m, "Gel giảm mụn cấp tốc chuyên sâu La Roche-Posay Effaclar AI", 40 },
                    { 15, "8809123456025", 15, 420000m, "Nước tẩy trang Bioderma Sensibio H2O 500ml", 55 },
                    { 16, "8809123456026", 16, 350000m, "Nến thơm phòng hương hoa nhài Yankee Candle", 18 },
                    { 17, "8809123456027", 17, 340000m, "Lược gỡ rối chuyên nghiệp Tangle Teezer Original", 22 },
                    { 18, "8809123456028", 18, 450000m, "Set dưỡng da mini 4 món Laneige Essential Power", 15 },
                    { 19, "8809123456029", 19, 150000m, "Hộp đựng mỹ phẩm trong suốt nhiều ngăn để bàn", 25 },
                    { 20, "8809123456030", 20, 590000m, "Set hộp quà mỹ phẩm xách tay cao cấp Hana Shop", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
