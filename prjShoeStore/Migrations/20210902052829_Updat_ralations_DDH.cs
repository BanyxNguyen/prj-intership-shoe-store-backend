using Microsoft.EntityFrameworkCore.Migrations;

namespace prjShoeStore.Migrations
{
    public partial class Updat_ralations_DDH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonDatHangs_AspNetUsers_NhanVienId",
                table: "DonDatHangs");

            migrationBuilder.DropIndex(
                name: "IX_DonDatHangs_NhanVienId",
                table: "DonDatHangs");

            migrationBuilder.DropColumn(
                name: "NhanVienId",
                table: "DonDatHangs");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatHangs_IdNVGiaoHang",
                table: "DonDatHangs",
                column: "IdNVGiaoHang");

            migrationBuilder.AddForeignKey(
                name: "FK_DonDatHangs_AspNetUsers_IdNVGiaoHang",
                table: "DonDatHangs",
                column: "IdNVGiaoHang",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonDatHangs_AspNetUsers_IdNVGiaoHang",
                table: "DonDatHangs");

            migrationBuilder.DropIndex(
                name: "IX_DonDatHangs_IdNVGiaoHang",
                table: "DonDatHangs");

            migrationBuilder.AddColumn<string>(
                name: "NhanVienId",
                table: "DonDatHangs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonDatHangs_NhanVienId",
                table: "DonDatHangs",
                column: "NhanVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonDatHangs_AspNetUsers_NhanVienId",
                table: "DonDatHangs",
                column: "NhanVienId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
