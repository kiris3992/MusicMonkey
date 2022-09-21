using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe;

namespace MusicMonkeyWebApp.Controllers
{
    public class SubscriptionController : Controller
    {
        // GET: Subscription
        public ActionResult Index()
        {
            ViewBag.StripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            return View();
        }

        [Obsolete]
        [HttpPost]
        public ActionResult Charge(string stripeToken, string stripeEmail)
        {
            Stripe.StripeConfiguration.SetApiKey("pk_test_51LkQULFznYPUzqY82RAcHxEBVQ0PpUn6n6afKegZa8CP8mtvfctcOq4pjrpoDh9pZTQjaUnASNEf8GwUCRDJ5BPO00DHfwTmQS");
            Stripe.StripeConfiguration.ApiKey = "sk_test_51LkQULFznYPUzqY8v6y5sZmdATOwV6jZRD9MK7WqHcDOuAwAQphvPdYKIkUtIMLu6yOtYfbhsrfKdjPCcgfTgp7q00DDTr4wQO";

            var myCharge = new Stripe.ChargeCreateOptions();
            // always set these properties
            myCharge.Amount = 500;
            myCharge.Currency = "USD";
            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "Sample Charge";
            myCharge.Source = stripeToken;
            myCharge.Capture = true;
            var chargeService = new Stripe.ChargeService();
            Charge stripeCharge = chargeService.Create(myCharge);
            return View();
        }
    }
}