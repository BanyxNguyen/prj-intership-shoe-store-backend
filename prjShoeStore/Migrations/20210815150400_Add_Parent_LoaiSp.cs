using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace prjShoeStore.Migrations
{
    public partial class Add_Parent_LoaiSp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdParent",
                table: "LoaiSPs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSPs_IdParent",
                table: "LoaiSPs",
                column: "IdParent");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiSPs_LoaiSPs_IdParent",
                table: "LoaiSPs",
                column: "IdParent",
                principalTable: "LoaiSPs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoaiSPs_LoaiSPs_IdParent",
                table: "LoaiSPs");

            migrationBuilder.DropIndex(
                name: "IX_LoaiSPs_IdParent",
                table: "LoaiSPs");

            migrationBuilder.DropColumn(
                name: "IdParent",
                table: "LoaiSPs");
        }
    }
}
