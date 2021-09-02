using Microsoft.EntityFrameworkCore.Migrations;

namespace prjShoeStore.Migrations
{
    public partial class Update_Table_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CTTraHangs_phieuTras_PhieuTraIdDonDatHang",
                table: "CTTraHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_phieuTras_DonDatHangs_IdDonDatHang",
                table: "phieuTras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_phieuTras",
                table: "phieuTras");

            migrationBuilder.RenameTable(
                name: "phieuTras",
                newName: "PhieuTras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuTras",
                table: "PhieuTras",
                column: "IdDonDatHang")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddForeignKey(
                name: "FK_CTTraHangs_PhieuTras_PhieuTraIdDonDatHang",
                table: "CTTraHangs",
                column: "PhieuTraIdDonDatHang",
                principalTable: "PhieuTras",
                principalColumn: "IdDonDatHang",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuTras_DonDatHangs_IdDonDatHang",
                table: "PhieuTras",
                column: "IdDonDatHang",
                principalTable: "DonDatHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CTTraHangs_PhieuTras_PhieuTraIdDonDatHang",
                table: "CTTraHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuTras_DonDatHangs_IdDonDatHang",
                table: "PhieuTras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuTras",
                table: "PhieuTras");

            migrationBuilder.RenameTable(
                name: "PhieuTras",
                newName: "phieuTras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_phieuTras",
                table: "phieuTras",
                column: "IdDonDatHang")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddForeignKey(
                name: "FK_CTTraHangs_phieuTras_PhieuTraIdDonDatHang",
                table: "CTTraHangs",
                column: "PhieuTraIdDonDatHang",
                principalTable: "phieuTras",
                principalColumn: "IdDonDatHang",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_phieuTras_DonDatHangs_IdDonDatHang",
                table: "phieuTras",
                column: "IdDonDatHang",
                principalTable: "DonDatHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
