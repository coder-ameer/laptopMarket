using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopMarket.Migrations
{
    /// <inheritdoc />
    public partial class ameer7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Order_tables",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_tables_AppUserID",
                table: "Order_tables",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_tables_AspNetUsers_AppUserID",
                table: "Order_tables",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_tables_AspNetUsers_AppUserID",
                table: "Order_tables");

            migrationBuilder.DropIndex(
                name: "IX_Order_tables_AppUserID",
                table: "Order_tables");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Order_tables");
        }
    }
}
