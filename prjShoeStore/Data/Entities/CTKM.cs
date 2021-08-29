
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
	public class CTKM
	{
		public Guid IdSanPham { get; set; }
		public SanPham SanPham { get; set; }
		public Guid IdKhuyenMai { get; set; }
		public KhuyenMai KhuyenMai { get; set; }
		public double MucGiam { get; set; }
		public DateTime NgayApDung { get; set; }
		public int SoNgayApDung { get; set; }

	}
}
