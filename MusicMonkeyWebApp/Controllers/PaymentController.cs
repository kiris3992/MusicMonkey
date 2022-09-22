using Entities.Models;
using MusicMonkeyWebApp.App_Start;
using MusicMonkeyWebApp.Models;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMonkeyWebApp.Controllers
{
    [Authorize(Roles = "Silver,Gold")]
    public class PaymentController : Controller
    {
        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            //getting the apiContext
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal
                //Payer Id will be returned when payment proceeds or click to pay
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist
                    //it is returned by the create function call of the payment class
                    // Creating a payment
                    // baseURL is the url on which paypal sendsback the data.
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority +
                    "/Payment/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session
                    //which will be used in the payment execution
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url
                    //on which payer is redirected for paypal account payment
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("FailureView");
            }
            //on successful payment, show success page to user.

            //ViewBag.roleChanged = UsersConfig.ChangeUsersRole(HttpContext.User.Identity.Name, "Gold");
            //return View("SuccessView");

            return View("SuccessView");
        }








        



        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            //create itemlist and add item objects to it
            var itemList = new ItemList() { items = new List<Item>() };
            //Adding Item Details like name, currency, price etc
            itemList.items.Add(new Item()
            {
                name = "MusicMonkey Silver test2",
                currency = "EUR",
                price = "1",
                quantity = "1",
                sku = "sku"
            });
            var payer = new Payer() { payment_method = "paypal" };
            // Configure Redirect Urls here with RedirectUrls object
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details
            var details = new Details()
            {
                tax = "1",
                shipping = "1",
                subtotal = "1"
            };
            //Final amount with details
            var amount = new Amount()
            {
                currency = "EUR",
                total = "3", // Total must be equal to sum of tax, shipping and subtotal.
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction
            transactionList.Add(new Transaction()
            {
                description = "Transaction description",
                invoice_number = "your generated invoice number", //Generate an Invoice No
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext
            return this.payment.Create(apiContext);
        }




        //// GET: Payment
        //public ActionResult PaymentWithPaypal()
        //{
        //    APIContext apicontext = PaypalConfiguration.GetAPIContext();
        //    try
        //    {
        //        string PayerID = Request.Params["PayerID"];
        //        if (string.IsNullOrEmpty(PayerID))
        //        {
        //            string baseURL = Request.Url.Scheme + "://" + Request.Url.Authority + "/PaymentWithPaypal/Paypal";
        //            var Guid = Convert.ToString((new Random()).Next(100000000));
        //            var createPayment = this.CreatePayment(apicontext, baseURL + "guid=" + Guid);
        //            var links = createPayment.links.GetEnumerator();
        //            string paypalRedirectURL = null;

        //            while (links.MoveNext())
        //            {
        //                Links lnk = links.Current;
        //                if (lnk.rel.ToLower().Trim().Equals("approval_url"))
        //                {
        //                    paypalRedirectURL = lnk.href;
        //                }

        //            }
        //        }
        //        else
        //        {
        //            var guid = Request.Params["guid"];
        //            var executePayment = ExecutePayment(apicontext, PayerID, Session[guid] as string);
        //            if (executePayment.ToString().ToLower() != "approved")
        //            {
        //                return View("FailureView");
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return View("FailureView");
        //    }
        //    return View("SuccessView");
        //}

        //private object ExecutePayment(APIContext apicontext, string payerID, string PaymentId)
        //{
        //    var paymentExecution = new PaymentExecution() { payer_id = payerID };
        //    this.payment = new Payment() { id=PaymentId};
        //    return this.payment.Execute(apicontext, paymentExecution);
        //}

        //private PayPal.Api.Payment payment;

        //private Payment CreatePayment(APIContext apicontext, string redirectUrl)
        //{
        //    var ItemsList=new ItemList() { items= new List<Item>() };


        //    if (Session["cart"] == null)
        //    {
        //        //List<Subscription> cart = (List<Subscription>)(Session["cart"]);

        //        //foreach (var item in cart)
        //        //{
        //        //    ItemsList.items.Add(new Item()
        //        //    {
        //        //        name = item.Name.ToString(),
        //        //        price = item.Price.ToString(),
        //        //        currency = "EUR",
        //        //        sku = "sku"

        //        //    }) ;

        //        //}

        //        ItemsList.items.Add(new Item()
        //        {
        //            name = "Gold",
        //            price = "20",
        //            currency = "EUR",
        //            sku = "sku"
        //        });

        //        var payer = new Payer() { payment_method = "paypal" };

        //        var redirtUrl = new RedirectUrls() { cancel_url = redirectUrl + "&Cancel=true", return_url = redirectUrl };

        //        var details = new Details() { tax = "1", shipping = "1", subtotal = "1" };

        //        var amount = new Amount() { currency = "EUR", total = "1", details = details };

        //        var transactionList = new List<Transaction>();
        //        transactionList.Add(new Transaction() { description = "Transaction Description", invoice_number = "#100000", amount = amount, item_list = ItemsList  });

        //        this.payment = new Payment() { intent = "sale", payer = payer, transactions = transactionList, redirect_urls = redirtUrl };
        //    }

        //   return this.payment.Create(apicontext);



        //} 


    }
}