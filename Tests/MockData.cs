using Checkout;

namespace Tests
{
    internal class MockData
    {
        public static Dictionary<string, Price> CurrentPrice()
        {
            var priceList = new Dictionary<string, Price>();
            priceList["A"] = new Price(50, 3, 130);
            priceList["B"] = new Price(30, 2, 45);
            priceList["C"] = new Price(20, null, null);
            priceList["D"] = new Price(15, null, null);
            return priceList;
        }

        public static Dictionary<string, Price> EmptyPrice => new Dictionary<string, Price>();

        public static Dictionary<string, Price> PriceWithMultiplierButNoSpecialPrice
        {
            get
            {
                var priceList = new Dictionary<string, Price>();
                priceList["A"] = new Price(50, 3, null);
                return priceList;
            }
        }

        public static Dictionary<string, Price> PriceWithSpecialPriceButNoMultiplier
        {
            get
            {
                var priceList = new Dictionary<string, Price>();
                priceList["A"] = new Price(50, null, 4);
                return priceList;
            }
        }
    }


}