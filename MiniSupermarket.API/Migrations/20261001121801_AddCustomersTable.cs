using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RewardPoints = table.Column<int>(type: "int", nullable: false),
                    MembershipRank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 1, null, "Nguyễn Thị Hoa", "Vàng", "0901122334", 150 },
                    { 2, null, "Trần Thị Mai", "Bạc", "0982233445", 80 },
                    { 3, null, "Lê Hoàng Yến", "Kim cương", "0913344556", 1200 },
                    { 4, null, "Phạm Quỳnh Anh", "Thành viên mới", "0394455667", 20 },
                    { 5, null, "Hoàng Thu Thảo", "Vàng", "0975566778", 320 },
                    { 6, null, "Vũ Minh Thư", "Bạc", "0936677889", 95 },
                    { 7, null, "Đặng Ngọc Hân", "Kim cương", "0927788990", 950 },
                    { 8, null, "Bùi Thanh Trúc", "Thành viên mới", "0868899001", 10 },
                    { 9, null, "Đỗ Mỹ Linh", "Vàng", "0949900112", 450 },
                    { 10, null, "Hồ Ngọc Hà", "Kim cương", "0901011223", 1500 },
                    { 11, null, "Ngô Thanh Vân", "Bạc", "0982122334", 110 },
                    { 12, null, "Dương Cẩm Lynh", "Thành viên mới", "0913233445", 35 },
                    { 13, null, "Lý Nhã Kỳ", "Vàng", "0394344556", 280 },
                    { 14, null, "Trương Ngọc Ánh", "Kim cương", "0975455667", 1100 },
                    { 15, null, "Phan Như Thảo", "Bạc", "0936566778", 75 },
                    { 16, null, "Vương Linh Chi", "Thành viên mới", "0927677889", 15 },
                    { 17, null, "Đinh Ngọc Diệp", "Vàng", "0868788990", 510 },
                    { 18, null, "Cao Thái Sơn", "Bạc", "0948900112", 60 },
                    { 19, null, "Trịnh Thăng Bình", "Thành viên mới", "0909011223", 25 },
                    { 20, null, "Sơn Tùng M-TP", "Kim cương", "0989122334", 2000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
