using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using prjShoeStore.Areas.Identity.Data;
using prjShoeStore.Attributes;
using prjShoeStore.Data;
using prjShoeStore.Data.Entities;
using prjShoeStore.DTO;
using prjShoeStore.ModelViews;
using prjShoeStore.PageLists;
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

        [HttpPost]
        [AuthorizeJWT]
        public async Task<ActionResult<IEnumerable<SanPhamDTO>>> GetOrders([FromBody] ModelFilter<OrderModelView> modelFilter)
        {


            if (modelFilter == null)
            {
                ModelState.AddModelError(string.Empty, "ModelFilter is invalid!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var builder = modelFilter.GetBuilder();
            var userId = _UserManager.GetUserId(HttpContext.User);

            if (modelFilter.Page != null && modelFilter.Amount == null)
            {
                ModelState.AddModelError(string.Empty, $"Amount field is requred when the Page field is assigned");
            }

            var FieldNotExist = builder.RemoveFieldNotExist(modelFilter.PropFilters, x => x.FieldName);

            if (FieldNotExist?.Count > 0)
            {
                ModelState.AddModelError(string.Empty, $"Fields not ready exist : {string.Join(",", FieldNotExist.Select(x => x.FieldName))}");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var KTPropFilter = modelFilter.PropFilters.FirstOrDefault(x => x.FieldName == nameof(SanPhamDTO.KichThuocs));
            if (KTPropFilter != null)
            {
                modelFilter.PropFilters.Remove(KTPropFilter);
            }

            var qryOrder = _Context.DonDatHangs
                .Where(x=>x.IdKHachHang == userId)
                .Select(x => new OrderModelView
            {
                Id = x.Id,
                DiaChiNguoiNhan = x.DiaChiNguoiNhan,
                NgayLap = x.NgayLap,
                PaymentId = x.PaymentId,
                PaymentType = x.PaymentType,
                SoDienThoai = x.SoDienThoai,
                TenNguoiNhan = x.TenNguoiNhan,
                TongTien = x.CTDDHs.Sum(x => x.Gia * x.SoLuong)
            });

            qryOrder = builder.OrderBy(qryOrder);

            if (modelFilter.Page != null)
            {
                qryOrder = qryOrder.Skip(modelFilter.Page.Value * modelFilter.Amount.Value).Take(modelFilter.Amount.Value);
            }

            var epr = builder.BuildLinq();
            IList<OrderModelView> data = null;
            if (epr != null)
            {
                data = await qryOrder.Where(epr).ToListAsync();
            }
            else
            {
                data = await qryOrder.ToListAsync();
            }

            return Ok(data);
        }
        [HttpGet]
        [AuthorizeJWT]
        public async Task<ActionResult<IEnumerable<SanPhamDTO>>> GetOrderDetails(Guid? orderId)
        {
            if (!orderId.HasValue)
            {
                ModelState.AddModelError(string.Empty, "orderId is empty!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _Context.CTDDHs.Include(x => x.SanPham)
                .Where(x => x.IdDonDatHang == orderId)
                .Select(x => new OrderDetailDTO
                {
                    Gia = x.Gia,
                    HinhAnh = x.SanPham.HinhAnh,
                    KichThuoc = x.KichThuoc,
                    Mau = x.SanPham.Mau,
                    SoLuong = x.SoLuong,
                    Ten = x.SanPham.Ten
                }).ToListAsync();

            return Ok(data);
        }
        private async Task AttachProductsAsync(IList<CartDTO> CartList)
        {
            var query = _ProductRespository.GetQueryProductCart();
            foreach (var cart in CartList)
            {
                var temp = await query.FirstOrDefaultAsync(x => x.Id == cart.Id && x.Size == cart.Size);
                if (temp != null)
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

                if (Status.Value == TrangThaiDonHang.Complete || Status.Value == TrangThaiDonHang.Cancel)
                {
                    var userId = _UserManager.GetUserId(HttpContext.User);
                    order.IdNhanVien = userId;
                }

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
