using prjShoeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.ModelViews
{
    public class OrderModelView
    {
        public Guid Id { get; set; }
        public EPaymentType PaymentType { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenNguoiNhan { get; set; }
        public string DiaChiNguoiNhan { get; set; }
        public string SoDienThoai { get; set; }
        public string PaymentId { get; set; }
        [DataType(DataType.Currency)]
        public double TongTien { get; set; }
    }
}
