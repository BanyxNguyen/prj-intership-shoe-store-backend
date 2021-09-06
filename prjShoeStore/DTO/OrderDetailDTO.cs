using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.DTO
{
    public class OrderDetailDTO
    {
        public string HinhAnh { get; set; }
        public string Ten { get; set; }
        public string Mau { get; set; }
        public double KichThuoc { get; set; }
        public int SoLuong { get; set; }
        public double Gia { get; set; }
    }
}
