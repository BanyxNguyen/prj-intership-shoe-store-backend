using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace prjShoeStore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonDatHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    TenNguoiNhan = table.Column<string>(nullable: true),
                    DiaChiNguoiNhan = table.Column<string>(nullable: true),
                    SoDienThoai = table.Column<string>(nullable: true),
                    IdKHachHang = table.Column<string>(nullable: true),
                    IdNhanVien = table.Column<string>(nullable: true),
                    IdNVGiaoHang = table.Column<string>(nullable: true),
                    NhanVienId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDatHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonDatHangs_AspNetUsers_IdKHachHang",
                        column: x => x.IdKHachHang,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonDatHangs_AspNetUsers_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonDatHangs_AspNetUsers_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(nullable: true),
                    IdKhachHang = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhuyenMais_AspNetUsers_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    IdNhanVien = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuNhaps_AspNetUsers_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(nullable: true),
                    IdThuongHieu = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiSPs_ThuongHieus_IdThuongHieu",
                        column: x => x.IdThuongHieu,
                        principalTable: "ThuongHieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    IdDonDatHang = table.Column<Guid>(nullable: false),
                    NgayLap = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.IdDonDatHang)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_HoaDons_DonDatHangs_IdDonDatHang",
                        column: x => x.IdDonDatHang,
                        principalTable: "DonDatHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(nullable: true),
                    IdLoaiSP = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSPs_IdLoaiSP",
                        column: x => x.IdLoaiSP,
                        principalTable: "LoaiSPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTDDHs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdSanPham = table.Column<Guid>(nullable: false),
                    IdDonDatHang = table.Column<Guid>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTDDHs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTDDHs_DonDatHangs_IdDonDatHang",
                        column: x => x.IdDonDatHang,
                        principalTable: "DonDatHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTDDHs_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTKMs",
                columns: table => new
                {
                    IdSanPham = table.Column<Guid>(nullable: false),
                    IdKhuyenMai = table.Column<Guid>(nullable: false),
                    MucGiam = table.Column<double>(nullable: false),
                    NgayApDung = table.Column<DateTime>(nullable: false),
                    SoNgayApDung = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTKMs", x => new { x.IdKhuyenMai, x.IdSanPham })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CTKMs_KhuyenMais_IdKhuyenMai",
                        column: x => x.IdKhuyenMai,
                        principalTable: "KhuyenMais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTKMs_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTPNs",
                columns: table => new
                {
                    IdPhieuNhap = table.Column<Guid>(nullable: false),
                    IdSanPham = table.Column<Guid>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTPNs", x => new { x.IdSanPham, x.IdPhieuNhap })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CTPNs_PhieuNhaps_IdPhieuNhap",
                        column: x => x.IdPhieuNhap,
                        principalTable: "PhieuNhaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTPNs_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTTraHangs",
                columns: table => new
                {
                    IdCTDDH = table.Column<Guid>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTTraHangs", x => x.IdCTDDH)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CTTraHangs_CTDDHs_IdCTDDH",
                        column: x => x.IdCTDDH,
                        principalTable: "CTDDHs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CTDDHs_IdDonDatHang",
                table: "CTDDHs",
                column: "IdDonDatHang");

            migrationBuilder.CreateIndex(
                name: "IX_CTDDHs_IdSanPham_IdDonDatHang",
                table: "CTDDHs",
                columns: new[] { "IdSanPham", "IdDonDatHang" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CTKMs_IdSanPham",
                table: "CTKMs",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_CTPNs_IdPhieuNhap",
                table: "CTPNs",
                column: "IdPhieuNhap");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatHangs_IdKHachHang",
                table: "DonDatHangs",
                column: "IdKHachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatHangs_IdNhanVien",
                table: "DonDatHangs",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatHangs_NhanVienId",
                table: "DonDatHangs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMais_IdKhachHang",
                table: "KhuyenMais",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSPs_IdThuongHieu",
                table: "LoaiSPs",
                column: "IdThuongHieu");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_IdNhanVien",
                table: "PhieuNhaps",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_IdLoaiSP",
                table: "SanPhams",
                column: "IdLoaiSP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CTKMs");

            migrationBuilder.DropTable(
                name: "CTPNs");

            migrationBuilder.DropTable(
                name: "CTTraHangs");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "PhieuNhaps");

            migrationBuilder.DropTable(
                name: "CTDDHs");

            migrationBuilder.DropTable(
                name: "DonDatHangs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LoaiSPs");

            migrationBuilder.DropTable(
                name: "ThuongHieus");
        }
    }
}
