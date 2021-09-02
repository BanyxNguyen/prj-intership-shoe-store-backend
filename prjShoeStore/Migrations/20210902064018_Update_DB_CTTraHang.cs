using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace prjShoeStore.Migrations
{
    public partial class Update_DB_CTTraHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CTTraHangs_CTDDHs_IdCTDDH",
                table: "CTTraHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_CTTraHangs_PhieuTras_PhieuTraIdDonDatHang",
                table: "CTTraHangs");

            migrationBuilder.DropIndex(
                name: "IX_CTTraHangs_PhieuTraIdDonDatHang",
                table: "CTTraHangs");

            migrationBuilder.DropColumn(
                name: "PhieuTraIdDonDatHang",
                table: "CTTraHangs");

            migrationBuilder.CreateIndex(
                name: "IX_CTTraHangs_IdDonDatHang",
                table: "CTTraHangs",
                column: "IdDonDatHang");

            migrationBuilder.AddForeignKey(
                name: "FK_CTTraHangs_CTDDHs_IdCTDDH",
                table: "CTTraHangs",
                column: "IdCTDDH",
                principalTable: "CTDDHs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CTTraHangs_PhieuTras_IdDonDatHang",
                table: "CTTraHangs",
                column: "IdDonDatHang",
                principalTable: "PhieuTras",
                principalColumn: "IdDonDatHang",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CTTraHangs_CTDDHs_IdCTDDH",
                table: "CTTraHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_CTTraHangs_PhieuTras_IdDonDatHang",
                table: "CTTraHangs");

            migrationBuilder.DropIndex(
                name: "IX_CTTraHangs_IdDonDatHang",
                table: "CTTraHangs");

            migrationBuilder.AddColumn<Guid>(
                name: "PhieuTraIdDonDatHang",
                table: "CTTraHangs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CTTraHangs_PhieuTraIdDonDatHang",
                table: "CTTraHangs",
                column: "PhieuTraIdDonDatHang");

            migrationBuilder.AddForeignKey(
                name: "FK_CTTraHangs_CTDDHs_IdCTDDH",
                table: "CTTraHangs",
                column: "IdCTDDH",
                principalTable: "CTDDHs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CTTraHangs_PhieuTras_PhieuTraIdDonDatHang",
                table: "CTTraHangs",
                column: "PhieuTraIdDonDatHang",
                principalTable: "PhieuTras",
                principalColumn: "IdDonDatHang",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
