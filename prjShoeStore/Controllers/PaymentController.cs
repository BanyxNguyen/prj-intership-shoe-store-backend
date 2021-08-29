using Core.Payments.Common;
using Core.Payments.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayPalCheckoutSdk.Orders;
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
        public PaymentController(
            IPayPalService payPalService
            //IOrderService orderService,
            //IMediaControllerService mediaControllerService,
            //IManageMailSender manageMailSender,
            //UserManager<ApplicationUser> userManager
            )
        {
            _PayPal = payPalService;
            //_OrderService = orderService;
            //MediaService = mediaControllerService;
            //MailSender = manageMailSender;
            //_UserManager = userManager;
        }

        public async Task<IActionResult> CreateOrderPayPalAsync()
        {
            var lstTemp = new List<dynamic>();
            var PurchaseUnits = new PurchaseUnitRequest[]
            {
                new PurchaseUnitRequest
                {
                    ReferenceId = Guid.NewGuid().ToString(),
                    Items = lstTemp.Select(x => new Item
                    {
                        Description = x.Type.ToString(),
                        Name = x.Title,
                        Quantity = "1",
                        UnitAmount = new Money
                        {
                            CurrencyCode = CurrencyHelper.USD,
                            Value = x.Price.ToString()
                        }
                    }).ToList(),
                    AmountWithBreakdown = new AmountWithBreakdown
                    {
                        AmountBreakdown = new AmountBreakdown
                        {
                            ItemTotal = new Money
                            {
                                CurrencyCode = CurrencyHelper.USD,
                                Value = lstTemp.Sum(x=>x.Price).ToString()
                            },
                        },
                        CurrencyCode = CurrencyHelper.USD,
                        Value = lstTemp.Sum(x => x.Price).ToString()
                    },
                }
            };

            try
            {
                var response = await _PayPal.CreateOrder(PurchaseUnits, new ApplicationContext
                {
                    CancelUrl = $"{HttpContext.Request.Host}{Url.Action(nameof(PaymentController.PayPalCancel))}",
                    ReturnUrl = $"{HttpContext.Request.Host}{Url.Action(nameof(PaymentController.PayPalReturn))}"
                });
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var order = response.Result<Order>();
                    return Ok(JObject.FromObject(order).ToString());
                }
            }
            catch (Exception)
            {
            }
            return BadRequest();
        }
        public async Task<IActionResult> CaptureOrderAsync(string ApprovedOrderId)
        {
            try
            {
                var response = await _PayPal.CaptureOrder(ApprovedOrderId);
                var result = response.Result<Order>();
                var resultString = JsonConvert.SerializeObject(result);
                //var IdInvoice = await _OrderService.SaveOrderToDataBase(result.Id, resultString, EPaymentMethod.PayPal);
                //await _OrderService.RemoveOrderSession();
                //var lstTmp = await MediaService.GetDownLoadLinksAsync(IdInvoice);
                //var user = await _UserManager.GetUserAsync(User);
                //await MailSender.SendMailDownLoadLink(user.Email, lstTmp);
                return Ok(ApprovedOrderId);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

        public IActionResult ExecutePayment()
        {
            return Ok();
        }
        public IActionResult PayPalReturn()
        {
            return Ok();
        }
        public IActionResult PayPalCancel()
        {
            return Ok();
        }
    }
}
