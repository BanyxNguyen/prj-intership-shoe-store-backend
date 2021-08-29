using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.DTO
{
    public class SanPhamDTO
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string Mau { get; set; }
        public Guid IdLoaiSP { get; set; }
        public string LoaiSP { get; set; }
        public Guid IdThuongHieu { get; set; }
        public string ThuongHieu { get; set; }
        public IList<double> KichThuocs { get; set; }

    }
}
