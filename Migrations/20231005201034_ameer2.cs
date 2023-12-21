using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopMarket.Migrations
{
    /// <inheritdoc />
    public partial class ameer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imageurl",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imageurl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
