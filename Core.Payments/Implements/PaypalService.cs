using Core.Payments.Common;
using Core.Payments.Interfaces;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Payments.Implements
{
    class PaypalService : IPayPalService
    {
        private readonly SandboxEnvironment _SandboxEnvironment;

        public PaypalService(SandboxEnvironment sandboxEnvironment)
        {
            _SandboxEnvironment = sandboxEnvironment;
            Client = new PayPalHttpClient(_SandboxEnvironment);
        }
        public PayPalHttpClient Client { get; }

        public async Task<HttpResponse> CaptureOrder(string ApprovedOrderId)
        {
            var request = new OrdersCaptureRequest(ApprovedOrderId);
            request.RequestBody(new OrderActionRequest());
            return await Client.Execute(request);
        }

        public Task<HttpResponse> CreateExecutePayment(IEnumerable<Transaction> transactions, ApplicationContext applicationContext)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponse> CreateOrder(IEnumerable<PurchaseUnitRequest> purchaseUnits, ApplicationContext applicationContext)
        {
            // Construct a request object and set desired parameters
            // Here, OrdersCreateRequest() creates a POST request to /v2/checkout/orders
            var order = new OrderRequest()
            {
                CheckoutPaymentIntent = IntentHelper.CAPTURE,
                PurchaseUnits = purchaseUnits.ToList(),
                ApplicationContext = applicationContext
            };


            // Call API with your client and get a response for your call
            var request = new OrdersCreateRequest();
            request.Prefer(PreferHelper.REPRESENTATION);
            request.RequestBody(order);
            return await Client.Execute(request);
        }

        public Task<HttpResponse> CreatePayment(IEnumerable<Transaction> transactions, ApplicationContext applicationContext)
        {
            throw new NotImplementedException();
        }
    }
}
