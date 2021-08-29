using prjShoeStore.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
    public enum TrangThaiDonHang
    {
        None, Dilivery, Cancel, Complete
    }
    public class DonDatHang
    {
        public Guid Id { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenNguoiNhan { get; set; }
        public string DiaChiNguoiNhan { get; set; }
        public string SoDienThoai { get; set; }
        [DisplayName("KhachHang")]
        public string IdKHachHang { get; set; }
        [DisplayName("NhanVien")]
        public string IdNhanVien { get; set; }
        [DisplayName("NVGiaoHang")]
        public string IdNVGiaoHang { get; set; }
        public TrangThaiDonHang TrangThai { get; set; }

        public ApplicationUser KhachHang { get; set; }
        public ApplicationUser NhanVien { get; set; }
        public ApplicationUser NVGiaoHang { get; set; }

    }
}
