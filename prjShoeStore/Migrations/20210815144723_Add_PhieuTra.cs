using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace prjShoeStore.Migrations
{
    public partial class Add_PhieuTra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdDonDatHang",
                table: "CTTraHangs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PhieuTraIdDonDatHang",
                table: "CTTraHangs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "phieuTras",
                columns: table => new
                {
                    IdDonDatHang = table.Column<Guid>(nullable: false),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    MoTa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuTras", x => x.IdDonDatHang)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_phieuTras_DonDatHangs_IdDonDatHang",
                        column: x => x.IdDonDatHang,
                        principalTable: "DonDatHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CTTraHangs_PhieuTraIdDonDatHang",
                table: "CTTraHangs",
                column: "PhieuTraIdDonDatHang");

            migrationBuilder.AddForeignKey(
                name: "FK_CTTraHangs_phieuTras_PhieuTraIdDonDatHang",
                table: "CTTraHangs",
                column: "PhieuTraIdDonDatHang",
                principalTable: "phieuTras",
                principalColumn: "IdDonDatHang",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CTTraHangs_phieuTras_PhieuTraIdDonDatHang",
                table: "CTTraHangs");

            migrationBuilder.DropTable(
                name: "phieuTras");

            migrationBuilder.DropIndex(
                name: "IX_CTTraHangs_PhieuTraIdDonDatHang",
                table: "CTTraHangs");

            migrationBuilder.DropColumn(
                name: "IdDonDatHang",
                table: "CTTraHangs");

            migrationBuilder.DropColumn(
                name: "PhieuTraIdDonDatHang",
                table: "CTTraHangs");
        }
    }
}
