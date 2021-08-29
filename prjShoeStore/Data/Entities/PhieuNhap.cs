using prjShoeStore.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
	public class PhieuNhap
	{
		public Guid Id { get; set; }
		public DateTime NgayLap { get; set; }
		[DisplayName("Email")]
		public string IdNhanVien { get; set; }
		public ApplicationUser NhanVien { get; set; }
		public IList<CTPN> CTPNs { get; set; }

	}
}
