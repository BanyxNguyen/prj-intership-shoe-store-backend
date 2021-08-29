using Microsoft.EntityFrameworkCore.Migrations;

namespace prjShoeStore.Migrations
{
    public partial class Modify_KichThuoc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CTPNs",
                table: "CTPNs");

            migrationBuilder.DropIndex(
                name: "IX_CTDDHs_IdSanPham_IdDonDatHang_KichThuoc",
                table: "CTDDHs");

            migrationBuilder.AlterColumn<double>(
                name: "KichThuoc",
                table: "CTPNs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<double>(
                name: "KichThuoc",
                table: "CTDDHs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CTPNs",
                table: "CTPNs");

            migrationBuilder.DropIndex(
                name: "IX_CTDDHs_IdSanPham_IdDonDatHang",
                table: "CTDDHs");

            migrationBuilder.AlterColumn<string>(
                name: "KichThuoc",
                table: "CTPNs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "KichThuoc",
                table: "CTDDHs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(double));

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
    }
}
