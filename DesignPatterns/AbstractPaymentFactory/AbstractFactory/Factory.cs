using DesignPatterns.AbstractPaymentFactory.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractPaymentFactory.AbstractFactory
{
    public class Factory : IValidFactory
    {
        public IFactory GetFactory(string name)
        {
            if (name == "Alpha")
            {
                return new AlphaBankFactory();
            }
            else if (name == "Peiraus")
            {
                return new PeirausBankFactory();
            }
            else
            {
                return new NationalBankFactory();
            }
        }
    }
}
