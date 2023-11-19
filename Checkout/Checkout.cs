namespace Checkouts
{
    public class Checkout : ICheckout
    {
        public Checkout(Dictionary<string, Price> priceList)
        {
            if (priceList.Count == 0)
            {
                throw new ArgumentException("Price List is empty.");

            }
            foreach (var price in priceList.Values)
            {
                if (!IsValidPrice(price))
                {
                    throw new ArgumentException("Price List is not formatted correctly.");
                }
            }

            PriceList = priceList;
        }

        public float GetTotalPrice()
        {
            float totalPrice = 0;
            foreach (var sku in ScannedSkus)
            {
                totalPrice += PriceList[sku.Key].CostOf(sku.Value);
            }
            return totalPrice;
        }

        public void Scan(string item)
        {
            if (!PriceList.ContainsKey(item))
            {
                throw new ArgumentException("Checkout does not recognise the scanned SKU");
            }
            if (ScannedSkus.ContainsKey(item))
            {
                ScannedSkus[item] += 1;
            }
            else { ScannedSkus.Add(item, 1); }
        }

        private readonly Dictionary<string, Price> PriceList;

        private static bool IsValidPrice(Price price)
        {
            return (price.SpecialPrice == null) == (price.SpecialPriceMultiplier == null);
        }

        private readonly Dictionary<string, int> ScannedSkus = new();

    }
}
