using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
	public class ThuongHieu
	{
		public Guid Id { get; set; }
		[MaxLength(50)]
		public string Ten { get; set; }

	}
}
