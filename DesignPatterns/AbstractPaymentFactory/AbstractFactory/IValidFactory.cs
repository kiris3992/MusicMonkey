using DesignPatterns.AbstractPaymentFactory.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractPaymentFactory.AbstractFactory
{
    public interface IValidFactory
    {
        IFactory GetFactory(string name); 
    }
}
