using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class Price
    {
        public Price(float singlePrice, int? specialPriceMultiplier, float? specialPrice)
        {
            SinglePrice = singlePrice;
            SpecialPriceMultiplier = specialPriceMultiplier;
            SpecialPrice = specialPrice;
        }

        public float SinglePrice { get; }

        public int? SpecialPriceMultiplier { get; }

        public float? SpecialPrice { get; }

    }
}
