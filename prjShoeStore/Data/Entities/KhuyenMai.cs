using prjShoeStore.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
	public class KhuyenMai
	{
		public Guid Id { get; set; }
		public string Ten { get; set; }
		public string IdKhachHang { get; set; }
		public ApplicationUser KhachHang { get; set; }
	}
}
