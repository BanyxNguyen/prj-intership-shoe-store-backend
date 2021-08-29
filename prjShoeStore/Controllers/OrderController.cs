using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;
using prjShoeStore.DTO;
using prjShoeStore.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Controllers
{
    public class OrderController : ApiBaseController
    {
        private readonly AppDbContext _Context;
        private readonly IProductRespository _ProductRespository;
        public OrderController(AppDbContext appDbContext, IProductRespository productRespository)
        {
            _Context = appDbContext;
            _ProductRespository = productRespository;
        }
        [HttpPost]
        public async Task<IActionResult> GetOrderProduct([FromForm] IList<CartDTO> CartList)
        {
            await AttachProductsAsync(CartList);
            return Ok(CartList);
        }
        private async Task AttachProductsAsync(IList<CartDTO> CartList)
        {
            var query = _ProductRespository.GetQueryProductCart();
            foreach (var cart in CartList)
            {
                var temp = await query.FirstOrDefaultAsync(x => x.Id == cart.Id && x.Size == cart.Size);
                cart.Amount = temp.Amount;
                cart.Price = temp.Price;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromForm] OrderDTO orderDTO)
        {
            if (orderDTO == null || orderDTO.CartList == null || orderDTO.CartList.Count < 1)
            {
                ModelState.AddModelError(string.Empty, "CartList is empty!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = new DonDatHang()
            {
                DiaChiNguoiNhan = orderDTO.DiaChiNguoiNhan,
                NgayLap = DateTime.Now,
                PaymentType = orderDTO.PaymentType,
                SoDienThoai = orderDTO.SoDienThoai,
                TenNguoiNhan = orderDTO.TenNguoiNhan,
                CTDDHs = orderDTO.CartList.Select(x => new CTDDH
                {
                    IdSanPham = x.Id,
                    Gia = x.Price,
                    Id = Guid.NewGuid(),
                    KichThuoc = x.Size,
                    SoLuong = x.Amount
                }).ToList()
            };

            try
            {
                var temp = await _Context.DonDatHangs.AddAsync(order);
                await _Context.SaveChangesAsync();
                return Ok(temp.Entity.Id);
            }
            catch
            {
                return BadRequest("Create order is failed!");
            }
        }
    }
}
