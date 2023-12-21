using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopMarket.Migrations
{
    /// <inheritdoc />
    public partial class ameer6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Cart_tables",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_tables_AppUserID",
                table: "Cart_tables",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_tables_AspNetUsers_AppUserID",
                table: "Cart_tables",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_tables_AspNetUsers_AppUserID",
                table: "Cart_tables");

            migrationBuilder.DropIndex(
                name: "IX_Cart_tables_AppUserID",
                table: "Cart_tables");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Cart_tables");
        }
    }
}
