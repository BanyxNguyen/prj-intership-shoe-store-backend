using Microsoft.EntityFrameworkCore.Migrations;

namespace prjShoeStore.Migrations
{
    public partial class Modify_KichThuoc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CTPNs",
                table: "CTPNs");

            migrationBuilder.DropIndex(
                name: "IX_CTDDHs_IdSanPham_IdDonDatHang",
                table: "CTDDHs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CTPNs",
                table: "CTPNs",
                columns: new[] { "IdSanPham", "IdPhieuNhap", "KichThuoc" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_CTDDHs_IdSanPham_IdDonDatHang_KichThuoc",
                table: "CTDDHs",
                columns: new[] { "IdSanPham", "IdDonDatHang", "KichThuoc" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CTPNs",
                table: "CTPNs");

            migrationBuilder.DropIndex(
                name: "IX_CTDDHs_IdSanPham_IdDonDatHang_KichThuoc",
                table: "CTDDHs");

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
