using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.DTO
{
    public class CartDTO
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
    }
}
