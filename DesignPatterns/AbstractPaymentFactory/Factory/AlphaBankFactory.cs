﻿using DesignPatterns.AbstractPaymentFactory.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractPaymentFactory.Factory
{
    public class AlphaBankFactory : IFactory
    {
        public ICard CreateCard(int cardNumber, int securityCode, DateTime expireDate)
        {
            return new AlphaCard() { CardNumber = cardNumber, SecurityNumber = securityCode, ExpireDate = expireDate };
        }

        
    }
}