using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopMarket.Migrations
{
    /// <inheritdoc />
    public partial class ameer10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coupon",
                table: "Cart_items");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    Added_at = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order_tableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_tables_Order_tableId",
                        column: x => x.Order_tableId,
                        principalTable: "Order_tables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_Order_tableId",
                table: "OrderItem",
                column: "Order_tableId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.AddColumn<string>(
                name: "coupon",
                table: "Cart_items",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
