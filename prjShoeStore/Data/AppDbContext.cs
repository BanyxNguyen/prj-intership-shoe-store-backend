using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<LoaiSP> LoaiSPs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<CTPN> CTPNs { get; set; }
        public DbSet<CTKM> CTKMs { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<CTTraHang> CTTraHangs { get; set; }
        public DbSet<CTDDH> CTDDHs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<DonDatHang> DonDatHangs { get; set; }
        public DbSet<PhieuTra> PhieuTras { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<PhieuTra>()
                .HasOne(x => x.DonDatHang)
                .WithMany()
                .HasForeignKey(x => x.IdDonDatHang);
            builder.Entity<PhieuTra>()
                .HasKey(x => x.IdDonDatHang)
                .IsClustered();

            builder.Entity<LoaiSP>()
                .HasOne(x => x.ThuongHieu)
                .WithMany()
                .HasForeignKey(x => x.IdThuongHieu);

            builder.Entity<LoaiSP>()
                .HasOne(x => x.Parent)
                .WithMany(x => x.Childrens)
                .HasForeignKey(x => x.IdParent)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<LoaiSP>()
                .HasMany(x => x.Childrens)
                .WithOne(x => x.Parent)
                .HasForeignKey(x => x.IdParent)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SanPham>()
                .HasOne(x => x.LoaiSP)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiSP);

            builder.Entity<CTKM>()
                .HasOne(x => x.SanPham)
                .WithMany()
                .HasForeignKey(x => x.IdSanPham);

            builder.Entity<CTKM>()
                .HasOne(x => x.KhuyenMai)
                .WithMany()
                .HasForeignKey(x => x.IdKhuyenMai);

            builder.Entity<CTKM>()
                .HasKey(x => new { x.IdKhuyenMai, x.IdSanPham })
                .IsClustered();

            builder.Entity<CTPN>()
                .HasOne(x => x.SanPham)
                .WithMany()
                .HasForeignKey(x => x.IdSanPham);

            builder.Entity<CTPN>()
                .HasOne(x => x.PhieuNhap)
                .WithMany(x => x.CTPNs)
                .HasForeignKey(x => x.IdPhieuNhap);
            builder.Entity<CTPN>()
                .HasKey(x => new { x.IdSanPham, x.IdPhieuNhap, x.KichThuoc })
                .IsClustered();

            builder.Entity<CTDDH>()
                .HasOne(x => x.SanPham)
                .WithMany()
                .HasForeignKey(x => x.IdSanPham);



            builder.Entity<CTDDH>()
                .HasOne(x => x.DonDatHang)
                .WithMany(x=>x.CTDDHs)
                .HasForeignKey(x => x.IdDonDatHang);

            builder.Entity<CTDDH>()
                .HasIndex(x => new { x.IdSanPham, x.IdDonDatHang, x.KichThuoc })
                .IsUnique();

            builder.Entity<CTTraHang>()
                .HasKey(x => x.IdCTDDH )
                .IsClustered();
            builder.Entity<CTTraHang>()
                .HasOne(x => x.CTDDH)
                .WithMany()
                .HasForeignKey(x => x.IdCTDDH)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<CTTraHang>()
                .HasOne(x => x.PhieuTra)
                .WithMany()
                .HasForeignKey(x => x.IdDonDatHang)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<KhuyenMai>()
                .HasOne(x => x.KhachHang)
                .WithMany()
                .HasForeignKey(x => x.IdKhachHang);

            builder.Entity<PhieuNhap>()
                .HasOne(x => x.NhanVien)
                .WithMany()
                .HasForeignKey(x => x.IdNhanVien);

            builder.Entity<HoaDon>()
            .HasOne(x => x.DonDatHang)
            .WithMany()
            .HasForeignKey(x => x.IdDonDatHang);

            builder.Entity<HoaDon>()
                .HasKey(x => x.IdDonDatHang)
                .IsClustered();
            builder.Entity<DonDatHang>()
             .Property(x => x.PaymentType)
             .HasConversion(x => x.ToString(), x => (EPaymentType)Enum.Parse(typeof(EPaymentType), x));

            builder.Entity<DonDatHang>()
             .Property(x => x.TrangThai)
             .HasConversion(x => x.ToString(), x => (TrangThaiDonHang)Enum.Parse(typeof(TrangThaiDonHang), x));
            builder.Entity<DonDatHang>()
                .HasOne(x => x.NhanVien)
                .WithMany()
                .HasForeignKey(x => x.IdNhanVien);
            builder.Entity<DonDatHang>()
                .HasOne(x => x.KhachHang)
                .WithMany()
                .HasForeignKey(x => x.IdKHachHang);
            builder.Entity<DonDatHang>()
                .HasOne(x => x.NVGiaoHang)
                .WithMany()
                .HasForeignKey(x => x.IdNVGiaoHang);


        }
    }
}
