using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjShoeStore.Areas.Identity.Data;
using prjShoeStore.Attributes;
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
        private readonly UserManager<ApplicationUser> _UserManager;
        public OrderController(
            AppDbContext appDbContext,
            IProductRespository productRespository,
            UserManager<ApplicationUser> userManager)
        {
            _Context = appDbContext;
            _ProductRespository = productRespository;
            _UserManager = userManager;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetOrderProduct([FromBody] IList<CartDTO> CartList)
        {
            CartList = CartList.GroupBy(x => new { x.Size, x.Id }).Select(x => x.First()).ToList();
            await AttachProductsAsync(CartList);
            return Ok(CartList);
        }
        private async Task AttachProductsAsync(IList<CartDTO> CartList)
        {
            var query = _ProductRespository.GetQueryProductCart();
            foreach (var cart in CartList)
            {
                var temp = await query.FirstOrDefaultAsync(x => x.Id == cart.Id && x.Size == cart.Size);
                if(temp != null)
                {
                    cart.Amount = temp.Amount;
                    cart.Price = temp.Price;
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> ChangeStaus(Guid? OrderId, TrangThaiDonHang? Status)
        {
            if (OrderId == null || Status == null)
            {
                return NotFound();
            }

            try
            {
                var order = await _Context.DonDatHangs.FindAsync(OrderId);
                order.TrangThai = Status.Value;
                _Context.DonDatHangs.Update(order);
                var ret = await _Context.SaveChangesAsync();
                return Ok(ret > 0);
            }
            catch
            {
                return BadRequest();
            }
        }

        [AuthorizeJWT]
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderDTO orderDTO)
        {
            var UserId = _UserManager.GetUserId(HttpContext.User);

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
                IdKHachHang = UserId,
                TrangThai = orderDTO.PaymentType == EPaymentType.Prepay ? TrangThaiDonHang.None : TrangThaiDonHang.Pending,
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
