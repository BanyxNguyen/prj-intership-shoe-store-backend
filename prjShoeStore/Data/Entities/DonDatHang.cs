using prjShoeStore.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
    public enum TrangThaiDonHang
    {
        None, Pending, Dilivery, Complete, Cancel
    }
    public enum EPaymentType
    {
        Prepay, PostPaid
    }
    public class DonDatHang
    {
        public Guid Id { get; set; }
		[MaxLength(25)]
        public EPaymentType PaymentType { get; set; }
        public DateTime NgayLap { get; set; }
		[MaxLength(50)]
        public string TenNguoiNhan { get; set; }
		[MaxLength(100)]
        public string DiaChiNguoiNhan { get; set; }
		[MaxLength(25)]
        public string SoDienThoai { get; set; }
        [DisplayName("KhachHang")]
        public string IdKHachHang { get; set; }
        [DisplayName("NhanVien")]
        public string IdNhanVien { get; set; }
        [DisplayName("NVGiaoHang")]
		[MaxLength(450)]
        public string IdNVGiaoHang { get; set; }
		[MaxLength(256)]
        public string PaymentId { get; set; }
		[MaxLength(50)]
        public TrangThaiDonHang TrangThai { get; set; }
        public ApplicationUser KhachHang { get; set; }
        public ApplicationUser NhanVien { get; set; }
        public ApplicationUser NVGiaoHang { get; set; }

        public IList<CTDDH> CTDDHs { get; set; }

    }
}
