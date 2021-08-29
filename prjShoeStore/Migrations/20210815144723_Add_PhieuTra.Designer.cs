﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prjShoeStore.Data;

namespace prjShoeStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210815144723_Add_PhieuTra")]
    partial class Add_PhieuTra
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("prjShoeStore.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.CTDDH", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Gia")
                        .HasColumnType("float");

                    b.Property<Guid>("IdDonDatHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KichThuoc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDonDatHang");

                    b.HasIndex("IdSanPham", "IdDonDatHang", "KichThuoc")
                        .IsUnique()
                        .HasFilter("[KichThuoc] IS NOT NULL");

                    b.ToTable("CTDDHs");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.CTKM", b =>
                {
                    b.Property<Guid>("IdKhuyenMai")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("MucGiam")
                        .HasColumnType("float");

                    b.Property<DateTime>("NgayApDung")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoNgayApDung")
                        .HasColumnType("int");

                    b.HasKey("IdKhuyenMai", "IdSanPham")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("IdSanPham");

                    b.ToTable("CTKMs");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.CTPN", b =>
                {
                    b.Property<Guid>("IdSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPhieuNhap")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KichThuoc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Gia")
                        .HasColumnType("float");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("IdSanPham", "IdPhieuNhap", "KichThuoc")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("IdPhieuNhap");

                    b.ToTable("CTPNs");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.CTTraHang", b =>
                {
                    b.Property<Guid>("IdCTDDH")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdDonDatHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PhieuTraIdDonDatHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("IdCTDDH")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("PhieuTraIdDonDatHang");

                    b.ToTable("CTTraHangs");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.DonDatHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChiNguoiNhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdKHachHang")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdNVGiaoHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNhanVien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("NhanVienId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiNhan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdKHachHang");

                    b.HasIndex("IdNhanVien");

                    b.HasIndex("NhanVienId");

                    b.ToTable("DonDatHangs");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.HoaDon", b =>
                {
                    b.Property<Guid>("IdDonDatHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.HasKey("IdDonDatHang")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.KhuyenMai", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdKhachHang")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdKhachHang");

                    b.ToTable("KhuyenMais");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.LoaiSP", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdThuongHieu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdThuongHieu");

                    b.ToTable("LoaiSPs");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.PhieuNhap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdNhanVien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdNhanVien");

                    b.ToTable("PhieuNhaps");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.PhieuTra", b =>
                {
                    b.Property<Guid>("IdDonDatHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.HasKey("IdDonDatHang")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("phieuTras");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.SanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdLoaiSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdLoaiSP");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.ThuongHieu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ThuongHieus");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("prjShoeStore.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("prjShoeStore.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("prjShoeStore.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("prjShoeStore.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.CTDDH", b =>
                {
                    b.HasOne("prjShoeStore.Data.Entities.DonDatHang", "DonDatHang")
                        .WithMany()
                        .HasForeignKey("IdDonDatHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("prjShoeStore.Data.Entities.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.CTKM", b =>
                {
                    b.HasOne("prjShoeStore.Data.Entities.KhuyenMai", "KhuyenMai")
                        .WithMany()
                        .HasForeignKey("IdKhuyenMai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("prjShoeStore.Data.Entities.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.CTPN", b =>
                {
                    b.HasOne("prjShoeStore.Data.Entities.PhieuNhap", "PhieuNhap")
                        .WithMany()
                        .HasForeignKey("IdPhieuNhap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("prjShoeStore.Data.Entities.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.CTTraHang", b =>
                {
                    b.HasOne("prjShoeStore.Data.Entities.CTDDH", "CTDDH")
                        .WithMany()
                        .HasForeignKey("IdCTDDH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("prjShoeStore.Data.Entities.PhieuTra", "PhieuTra")
                        .WithMany()
                        .HasForeignKey("PhieuTraIdDonDatHang");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.DonDatHang", b =>
                {
                    b.HasOne("prjShoeStore.Areas.Identity.Data.ApplicationUser", "KhachHang")
                        .WithMany()
                        .HasForeignKey("IdKHachHang");

                    b.HasOne("prjShoeStore.Areas.Identity.Data.ApplicationUser", "NVGiaoHang")
                        .WithMany()
                        .HasForeignKey("IdNhanVien");

                    b.HasOne("prjShoeStore.Areas.Identity.Data.ApplicationUser", "NhanVien")
                        .WithMany()
                        .HasForeignKey("NhanVienId");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.HoaDon", b =>
                {
                    b.HasOne("prjShoeStore.Data.Entities.DonDatHang", "DonDatHang")
                        .WithMany()
                        .HasForeignKey("IdDonDatHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.KhuyenMai", b =>
                {
                    b.HasOne("prjShoeStore.Areas.Identity.Data.ApplicationUser", "KhachHang")
                        .WithMany()
                        .HasForeignKey("IdKhachHang");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.LoaiSP", b =>
                {
                    b.HasOne("prjShoeStore.Data.Entities.ThuongHieu", "ThuongHieu")
                        .WithMany()
                        .HasForeignKey("IdThuongHieu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.PhieuNhap", b =>
                {
                    b.HasOne("prjShoeStore.Areas.Identity.Data.ApplicationUser", "NhanVien")
                        .WithMany()
                        .HasForeignKey("IdNhanVien");
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.PhieuTra", b =>
                {
                    b.HasOne("prjShoeStore.Data.Entities.DonDatHang", "DonDatHang")
                        .WithMany()
                        .HasForeignKey("IdDonDatHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("prjShoeStore.Data.Entities.SanPham", b =>
                {
                    b.HasOne("prjShoeStore.Data.Entities.LoaiSP", "LoaiSP")
                        .WithMany()
                        .HasForeignKey("IdLoaiSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
