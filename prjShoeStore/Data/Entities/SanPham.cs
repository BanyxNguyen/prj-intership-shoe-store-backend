using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Data.Entities
{
    public class SanPham
    {
        //static Random Random = new Random();
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string Mau { get; set; }
        [DisplayName("LoaiSP")]
        public Guid IdLoaiSP { get; set; }
        //[NotMapped]
        //public double Test { get; set; } = 10 * Random.NextDouble();
        public LoaiSP LoaiSP { get; set; }
    }
}
