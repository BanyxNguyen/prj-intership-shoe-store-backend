using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
	public class HoaDon
	{
		public Guid IdDonDatHang { get; set; }
		public DonDatHang DonDatHang { get; set; }
		public DateTime NgayLap { get; set; }
	}
}
