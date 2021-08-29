using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.DTO
{
    public class CTPNDTO
    {
        public Guid IdSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double KichThuoc { get; set; }
        public int SoLuong { get; set; }
        public double Gia { get; set; }
    }
}
