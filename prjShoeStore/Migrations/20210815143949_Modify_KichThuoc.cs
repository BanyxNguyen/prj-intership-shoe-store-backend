using Microsoft.EntityFrameworkCore.Migrations;

namespace prjShoeStore.Migrations
{
    public partial class Modify_KichThuoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CTPNs",
                table: "CTPNs");

            migrationBuilder.DropIndex(
                name: "IX_CTDDHs_IdSanPham_IdDonDatHang",
                table: "CTDDHs");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "KichThuoc",
                table: "SanPhams");

            migrationBuilder.AddColumn<string>(
                name: "KichThuoc",
                table: "CTPNs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Gia",
                table: "CTPNs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Gia",
                table: "CTDDHs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "KichThuoc",
                table: "CTDDHs",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CTPNs",
                table: "CTPNs",
                columns: new[] { "IdSanPham", "IdPhieuNhap", "KichThuoc" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_CTDDHs_IdSanPham_IdDonDatHang_KichThuoc",
                table: "CTDDHs",
                columns: new[] { "IdSanPham", "IdDonDatHang", "KichThuoc" },
                unique: true,
                filter: "[KichThuoc] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CTPNs",
                table: "CTPNs");

            migrationBuilder.DropIndex(
                name: "IX_CTDDHs_IdSanPham_IdDonDatHang_KichThuoc",
                table: "CTDDHs");

            migrationBuilder.DropColumn(
                name: "KichThuoc",
                table: "CTPNs");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "CTPNs");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "CTDDHs");

            migrationBuilder.DropColumn(
                name: "KichThuoc",
                table: "CTDDHs");

            migrationBuilder.AddColumn<double>(
                name: "Gia",
                table: "SanPhams",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "KichThuoc",
                table: "SanPhams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CTPNs",
                table: "CTPNs",
                columns: new[] { "IdSanPham", "IdPhieuNhap" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_CTDDHs_IdSanPham_IdDonDatHang",
                table: "CTDDHs",
                columns: new[] { "IdSanPham", "IdDonDatHang" },
                unique: true);
        }
    }
}
