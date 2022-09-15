using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractPaymentFactory.Product
{
    public class PeirausCard : ICard
    {
        public int CardNumber { get; set; }
        public int SecurityNumber { get; set; }
        public DateTime ExpireDate { get; set; }

        public string MakePayment(int amount)
        {
            // connection with Bank and make payment
            return "";
        }
    }
}
