﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class Checkout : ICheckout
    {
        public Checkout(Dictionary<string, Price> priceList)
        {
            if(priceList.Count == 0)
            {
                throw new ArgumentException("Price List is empty.");

            }
            foreach (var price in priceList.Values)
            {
                if(!isValidPrice(price)) {
                    throw new ArgumentException("Price List is not formatted correctly.");
                }
            }

            PriceList = priceList;
        }

        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, Price> PriceList;

        private static bool isValidPrice(Price price)
        {
            return (price.SpecialPrice == null) == (price.SpecialPriceMultiplier == null);

        }
    }
}
