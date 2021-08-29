using prjShoeStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Respositories.Interfaces
{
    public interface IProductRespository
    {
        IQueryable<CartDTO> GetQueryProductCart();
    }
}
