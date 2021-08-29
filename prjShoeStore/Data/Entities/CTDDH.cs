using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
	public class CTDDH
	{
		public Guid Id { get; set; }
		public Guid IdSanPham { get; set; }
		public double Gia { get; set; }
        public double KichThuoc { get; set; }
		public SanPham SanPham { get; set; }
		public Guid IdDonDatHang { get; set; }
		public DonDatHang DonDatHang { get; set; }
		public int SoLuong { get; set; }
	}
}
