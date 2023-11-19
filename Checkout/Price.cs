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

        public float CostOf(int purchased)
        {
            if (SpecialPriceMultiplier != null && SpecialPrice != null)
            {
                int standardPricePurchases = (int)(purchased % SpecialPriceMultiplier);
                float standardPricePurchaseCost = standardPricePurchases * SinglePrice;
                float specialPricePurchases = (float)((purchased - standardPricePurchases) / SpecialPriceMultiplier);
                float specialPurchasesCost = (float)(specialPricePurchases * SpecialPrice);
                return standardPricePurchaseCost + specialPurchasesCost;
            }
            return SinglePrice * purchased;
        }

        public float SinglePrice { get; }

        public int? SpecialPriceMultiplier { get; }

        public float? SpecialPrice { get; }

    }
}
