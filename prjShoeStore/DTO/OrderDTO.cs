using prjShoeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.DTO
{
    public class OrderDTO
    {
        public EPaymentType PaymentType { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenNguoiNhan { get; set; }
        public string DiaChiNguoiNhan { get; set; }
        public string SoDienThoai { get; set; }
        public IList<CartDTO> CartList { get; set; }
    }
}
