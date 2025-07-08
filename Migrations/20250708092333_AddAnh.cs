using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTravel.Migrations
{
    /// <inheritdoc />
    public partial class AddAnh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anh",
                table: "LoaiDichVus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Anh",
                table: "DiaDiems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anh",
                table: "LoaiDichVus");

            migrationBuilder.DropColumn(
                name: "Anh",
                table: "DiaDiems");
        }
    }
}
