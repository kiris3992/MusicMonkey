using DesignPatterns.AbstractPaymentFactory.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractPaymentFactory.Factory
{
    public interface IFactory
    {
        ICard CreateCard(int cardNumber, int securityCode, DateTime expireDate);

        
    }
}
