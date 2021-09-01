using Core.Payments.Common;
using Core.Payments.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayPalCheckoutSdk.Orders;
using prjShoeStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Controllers
{
    public class PaymentController : ApiBaseController
    {
        private readonly IPayPalService _PayPal;
        //private readonly IOrderService _OrderService;
        //private readonly IMediaControllerService MediaService;
        //private readonly IManageMailSender MailSender;
        //private readonly UserManager<ApplicationUser> _UserManager;
        private readonly AppDbContext _Context;
        public PaymentController(
            IPayPalService payPalService,
            AppDbContext appDbContext
            //IOrderService orderService,
            //IMediaControllerService mediaControllerService,
            //IManageMailSender manageMailSender,
            //UserManager<ApplicationUser> userManager
            )
        {
            _Context = appDbContext;
            _PayPal = payPalService;
            //_OrderService = orderService;
            //MediaService = mediaControllerService;
            //MailSender = manageMailSender;
            //_UserManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrderPayPalAsync(Guid OrderId)
        {
            var lstTemp = await _Context.CTDDHs
                .Where(x => x.IdDonDatHang == OrderId)
                .Select(x => new { x.IdSanPham, x.KichThuoc, x.SanPham.Ten, x.SoLuong, x.Gia })
                .ToListAsync();
            var PurchaseUnits = new PurchaseUnitRequest[]
            {
                new PurchaseUnitRequest
                {
                    ReferenceId = OrderId.ToString(),
                    Items = lstTemp.Select(x => new Item
                    {
                        Description = $"{x.Ten} - {x.KichThuoc}",
                        Name = x.Ten,
                        Quantity = x.SoLuong.ToString(),
                        UnitAmount = new Money
                        {
                            CurrencyCode = CurrencyHelper.USD,
                            Value = x.Gia.ToString()
                        }
                    }).ToList(),
                    AmountWithBreakdown = new AmountWithBreakdown
                    {
                        AmountBreakdown = new AmountBreakdown
                        {
                            ItemTotal = new Money
                            {
                                CurrencyCode = CurrencyHelper.USD,
                                Value = lstTemp.Sum(x=>x.Gia*x.SoLuong).ToString()
                            },
                        },
                        CurrencyCode = CurrencyHelper.USD,
                        Value = lstTemp.Sum(x => x.Gia*x.SoLuong).ToString()
                    },
                }
            };

            try
            {
                var response = await _PayPal.CreateOrder(PurchaseUnits, new ApplicationContext
                {
                    //CancelUrl = $"{HttpContext.Request.Host}{Url.Action(nameof(PaymentController.PayPalCancel))}",
                    //ReturnUrl = $"{HttpContext.Request.Host}{Url.Action(nameof(PaymentController.PayPalReturn))}"
                });

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var order = response.Result<Order>();
                    return Ok(JObject.FromObject(order).ToString());
                }
            }
            catch (Exception e)
            {
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> CaptureOrderAsync(string ApprovedOrderId)
        {
            try
            {
                var response = await _PayPal.CaptureOrder(ApprovedOrderId);
                var result = response.Result<Order>();
                var PurchaseUnit = result.PurchaseUnits.FirstOrDefault();

                if (PurchaseUnit == null) throw new Exception("CaptureOrder is failed! can not find PurchaseUnit");

                var OrderId = Guid.Parse(PurchaseUnit.ReferenceId);
                var order = await _Context.DonDatHangs.FirstOrDefaultAsync(x => x.Id == OrderId);

                if (order != null)
                {
                    order.TrangThai = Data.Entities.TrangThaiDonHang.Pending;
                    order.PaymentId = ApprovedOrderId;
                    await _Context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("CaptureOrder is failed! can not find order!");
                }

                //var IdInvoice = await _OrderService.SaveOrderToDataBase(result.Id, resultString, EPaymentMethod.PayPal);
                //await _OrderService.RemoveOrderSession();
                //var lstTmp = await MediaService.GetDownLoadLinksAsync(IdInvoice);
                //var user = await _UserManager.GetUserAsync(User);
                //await MailSender.SendMailDownLoadLink(user.Email, lstTmp);
                return Ok(ApprovedOrderId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ExecutePayment()
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult PayPalReturn()
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult PayPalCancel()
        {
            return Ok();
        }
    }
}
