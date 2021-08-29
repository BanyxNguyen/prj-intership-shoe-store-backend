using Microsoft.EntityFrameworkCore.Migrations;

namespace prjShoeStore.Migrations
{
    public partial class add_properties_in_sanpham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "SanPhams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KichThuoc",
                table: "SanPhams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mau",
                table: "SanPhams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "SanPhams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "KichThuoc",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "Mau",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "SanPhams");
        }
    }
}
