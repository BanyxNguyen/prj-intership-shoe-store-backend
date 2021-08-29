using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
	public class CTTraHang
	{
		public Guid IdCTDDH { get; set; }
		public CTDDH CTDDH { get; set; }
        public Guid IdDonDatHang { get; set; }
        public PhieuTra PhieuTra { get; set; }
        public int SoLuong { get; set; }
	}
}
