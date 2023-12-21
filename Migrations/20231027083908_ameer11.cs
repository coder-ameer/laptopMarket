using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopMarket.Migrations
{
    /// <inheritdoc />
    public partial class ameer11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Warehouses");

            migrationBuilder.AddColumn<byte[]>(
                name: "Imageurl",
                table: "Warehouses",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imageurl",
                table: "Warehouses");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
