using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Payments.Interfaces
{
    public interface IPayPalService
    {
        Task<HttpResponse> CreateOrder(IEnumerable<PurchaseUnitRequest> purchaseUnits, ApplicationContext applicationContext);
        Task<HttpResponse> CreatePayment(IEnumerable<Transaction> transactions, ApplicationContext applicationContext);
        Task<HttpResponse> CreateExecutePayment(IEnumerable<Transaction> transactions, ApplicationContext applicationContext);
        Task<HttpResponse> CaptureOrder(string ApprovedOrderId);
    }
}
