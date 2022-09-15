using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractPaymentFactory.Product
{
    public interface ICard
    {
        int CardNumber { get; set; }
        int SecurityNumber { get; set; }

        DateTime ExpireDate { get; set; }
        string MakePayment(int amount);

    }
}
