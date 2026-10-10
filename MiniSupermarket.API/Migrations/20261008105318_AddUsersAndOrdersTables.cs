using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersAndOrdersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CashierUsername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    FinalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RewardPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CashierUsername", "CreatedDate", "CustomerId", "FinalAmount", "OrderCode", "RewardPoints", "TotalItems" },
                values: new object[,]
                {
                    { 1, "cashier01", new DateTime(2026, 3, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 1030000m, "HD-20260301-001", 10, 2 },
                    { 2, "cashier02", new DateTime(2026, 3, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, 780000m, "HD-20260301-002", 7, 1 },
                    { 3, "cashier01", new DateTime(2026, 3, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), 3, 980000m, "HD-20260302-001", 9, 3 },
                    { 4, "cashier03", new DateTime(2026, 3, 2, 14, 20, 0, 0, DateTimeKind.Unspecified), 4, 95000m, "HD-20260302-002", 1, 1 },
                    { 5, "cashier02", new DateTime(2026, 3, 3, 15, 45, 0, 0, DateTimeKind.Unspecified), 5, 570000m, "HD-20260303-001", 5, 2 },
                    { 6, "cashier04", new DateTime(2026, 3, 3, 16, 10, 0, 0, DateTimeKind.Unspecified), 6, 185000m, "HD-20260303-002", 1, 1 },
                    { 7, "cashier01", new DateTime(2026, 3, 4, 8, 50, 0, 0, DateTimeKind.Unspecified), 7, 760000m, "HD-20260304-001", 7, 2 },
                    { 8, "cashier05", new DateTime(2026, 3, 4, 13, 15, 0, 0, DateTimeKind.Unspecified), 8, 420000m, "HD-20260304-002", 4, 1 },
                    { 9, "cashier03", new DateTime(2026, 3, 5, 17, 30, 0, 0, DateTimeKind.Unspecified), 9, 690000m, "HD-20260305-001", 6, 2 },
                    { 10, "cashier02", new DateTime(2026, 3, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 10, 450000m, "HD-20260305-002", 4, 1 },
                    { 11, "cashier06", new DateTime(2026, 3, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), 11, 740000m, "HD-20260306-001", 7, 2 },
                    { 12, "cashier01", new DateTime(2026, 3, 6, 11, 40, 0, 0, DateTimeKind.Unspecified), 12, 590000m, "HD-20260306-002", 5, 1 },
                    { 13, "cashier04", new DateTime(2026, 3, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), 13, 1030000m, "HD-20260307-001", 10, 2 },
                    { 14, "cashier05", new DateTime(2026, 3, 7, 18, 25, 0, 0, DateTimeKind.Unspecified), 14, 250000m, "HD-20260307-002", 2, 1 },
                    { 15, "cashier02", new DateTime(2026, 3, 8, 9, 30, 0, 0, DateTimeKind.Unspecified), 15, 1095000m, "HD-20260308-001", 10, 3 },
                    { 16, "cashier03", new DateTime(2026, 3, 8, 12, 10, 0, 0, DateTimeKind.Unspecified), 16, 320000m, "HD-20260308-002", 3, 1 },
                    { 17, "cashier06", new DateTime(2026, 3, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), 17, 840000m, "HD-20260309-001", 8, 2 },
                    { 18, "cashier01", new DateTime(2026, 3, 9, 16, 45, 0, 0, DateTimeKind.Unspecified), 18, 190000m, "HD-20260309-002", 1, 1 },
                    { 19, "cashier06", new DateTime(2026, 3, 10, 10, 15, 0, 0, DateTimeKind.Unspecified), 19, 760000m, "HD-20260310-001", 7, 2 },
                    { 20, "cashier02", new DateTime(2026, 3, 10, 20, 0, 0, 0, DateTimeKind.Unspecified), 20, 520000m, "HD-20260310-002", 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FullName", "IsActive", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Nguyễn Quản Trị", true, "AQAAAAEAACcQAAAAEH...", "Admin", "admin01" },
                    { 2, "Trần Giám Đốc", true, "AQAAAAEAACcQAAAAEH...", "Admin", "admin02" },
                    { 3, "Lê Thu Ngân", true, "AQAAAAEAACcQAAAAEH...", "Cashier", "cashier01" },
                    { 4, "Phạm Bán Hàng", true, "AQAAAAEAACcQAAAAEH...", "Cashier", "cashier02" },
                    { 5, "Hoàng Thu Ngân", true, "AQAAAAEAACcQAAAAEH...", "Cashier", "cashier03" },
                    { 6, "Vũ Thị Quầy", true, "AQAAAAEAACcQAAAAEH...", "Cashier", "cashier04" },
                    { 7, "Đỗ Bán Lẻ", true, "AQAAAAEAACcQAAAAEH...", "Cashier", "cashier05" },
                    { 8, "Ngô Quản Kho", true, "AQAAAAEAACcQAAAAEH...", "Warehouse", "ware01" },
                    { 9, "Bùi Kiểm Kê", true, "AQAAAAEAACcQAAAAEH...", "Warehouse", "ware02" },
                    { 10, "Dương Thủ Kho", true, "AQAAAAEAACcQAAAAEH...", "Warehouse", "ware03" },
                    { 11, "Lý Nhập Hàng", true, "AQAAAAEAACcQAAAAEH...", "Warehouse", "ware04" },
                    { 12, "Đặng Hỗ Trợ", true, "AQAAAAEAACcQAAAAEH...", "Admin", "admin_backup" },
                    { 13, "Hồ Ca Chiều", true, "AQAAAAEAACcQAAAAEH...", "Cashier", "cashier06" },
                    { 14, "Trương Vận Chuyển", true, "AQAAAAEAACcQAAAAEH...", "Warehouse", "ware05" },
                    { 15, "Mai Giám Sát", true, "AQAAAAEAACcQAAAAEH...", "Admin", "supervisor" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "LineTotal", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 850000m, 1, 1, 1, 850000m },
                    { 2, 180000m, 1, 2, 1, 180000m },
                    { 3, 780000m, 2, 4, 1, 780000m },
                    { 4, 50000m, 3, 3, 2, 25000m },
                    { 5, 650000m, 3, 7, 1, 650000m },
                    { 6, 190000m, 3, 10, 1, 190000m },
                    { 7, 95000m, 4, 8, 1, 95000m },
                    { 8, 175000m, 5, 5, 1, 175000m },
                    { 9, 380000m, 5, 14, 1, 380000m },
                    { 10, 185000m, 6, 11, 1, 185000m },
                    { 11, 760000m, 7, 9, 2, 380000m },
                    { 12, 420000m, 8, 15, 1, 420000m },
                    { 13, 340000m, 9, 17, 1, 340000m },
                    { 14, 350000m, 9, 16, 1, 350000m },
                    { 15, 450000m, 10, 18, 1, 450000m },
                    { 16, 240000m, 11, 12, 1, 240000m },
                    { 17, 520000m, 11, 13, 1, 520000m },
                    { 18, 590000m, 12, 20, 1, 590000m },
                    { 19, 850000m, 13, 1, 1, 850000m },
                    { 20, 180000m, 13, 2, 1, 180000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
