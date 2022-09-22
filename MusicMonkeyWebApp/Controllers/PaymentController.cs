using Entities.Models;
using MusicMonkeyWebApp.Models;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMonkeyWebApp.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult PaymentWithPaypal()
        {
            APIContext apicontext = PaypalConfiguration.GetAPIContext();
            try
            {
                string PayerID = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(PayerID))
                {
                    string baseURL = Request.Url.Scheme + "://" + Request.Url.Authority + "PaymentWithPaypal/Paypal";
                    var Guid = Convert.ToString((new Random()).Next(10000));
                    var createPayment = this.CreatePayment(apicontext, baseURL + "guid=" + Guid);
                    var links = createPayment.links.GetEnumerator();
                    string paypalRedirectURL = null;

                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectURL = lnk.href;
                        }
                        
                    }
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executePayment = ExecutePayment(apicontext, PayerID, Session[guid] as string);
                    if (executePayment.ToString().ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception)
            {
                return View("FailureView");
            }
            return View("SuccessView");
        }

        private object ExecutePayment(APIContext apicontext, string payerID, string PaymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerID };
            this.payment = new Payment() { id=PaymentId};
            return this.payment.Execute(apicontext, paymentExecution);
        }

        private PayPal.Api.Payment payment;

        private Payment CreatePayment(APIContext apicontext, string redirectUrl)
        {
            var ItemsList=new ItemList() { items= new List<Item>() };


            if (Session["cart"] == null)
            {
                //List<Subscription> cart = (List<Subscription>)(Session["cart"]);

                //foreach (var item in cart)
                //{
                //    ItemsList.items.Add(new Item()
                //    {
                //        name = item.Name.ToString(),
                //        price = item.Price.ToString(),
                //        currency = "EUR",
                //        sku = "sku"

                //    }) ;

                //}

                ItemsList.items.Add(new Item()
                {
                    name = "Gold",
                    price = "20",
                    currency = "EUR",
                    sku = "sku"
                });

                var payer = new Payer() { payment_method = "paypal" };

                var redirtUrl = new RedirectUrls() { cancel_url = redirectUrl + "&Cancel=true", return_url = redirectUrl };

                var details = new Details() { tax = "1", shipping = "1", subtotal = "1" };

                var amount = new Amount() { currency = "EUR", total = "1", details = details };

                var transactionList = new List<Transaction>();
                transactionList.Add(new Transaction() { description = "Transaction Description", invoice_number = "#100000", amount = amount, item_list = ItemsList  });

                this.payment = new Payment() { intent = "sale", payer = payer, transactions = transactionList, redirect_urls = redirtUrl };
            }

           return this.payment.Create(apicontext);

            

        } 

        
    }
}