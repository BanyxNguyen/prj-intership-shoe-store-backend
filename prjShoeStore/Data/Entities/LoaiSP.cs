using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
	public class LoaiSP
	{
		public Guid Id { get; set; }
		public string Ten { get; set; }
		[DisplayName("ThuongHieu")]
		public Guid IdThuongHieu { get; set; }
		public ThuongHieu ThuongHieu { get; set; }
		[DisplayName("Category Parent")]
        public Guid? IdParent { get; set; }
        public LoaiSP Parent { get; set; }
        public IList<LoaiSP> Childrens { get; set; }
	}
}
