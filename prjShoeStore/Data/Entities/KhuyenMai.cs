using prjShoeStore.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
	public class KhuyenMai
	{
		public Guid Id { get; set; }
		[MaxLength(50)]
		public string Ten { get; set; }
		public string IdKhachHang { get; set; }
		public ApplicationUser KhachHang { get; set; }
	}
}
