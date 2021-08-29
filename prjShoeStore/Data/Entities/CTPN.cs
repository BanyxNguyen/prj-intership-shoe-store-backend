using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
	public class CTPN
	{
		public Guid IdPhieuNhap { get; set; }
        public double KichThuoc { get; set; }
		public double Gia { get; set; }
		public PhieuNhap PhieuNhap { get; set; }
		public Guid IdSanPham { get; set; }
		public SanPham SanPham { get; set; }
		public int SoLuong { get; set; }
	}
}
