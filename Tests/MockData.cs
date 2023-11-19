using Checkouts;

namespace CheckoutTests
{
    internal static class MockData
    {
        public static Dictionary<string, Price> CurrentPrice()
        {
            var priceList = new Dictionary<string, Price>
            {
                ["A"] = new Price(50, 3, 130),
                ["B"] = new Price(30, 2, 45),
                ["C"] = new Price(20, null, null),
                ["D"] = new Price(15, null, null)
            };
            return priceList;
        }

        public static Dictionary<string, Price> EmptyPrice
        {
            get
            {
                return new();
            }
        }

        public static Dictionary<string, Price> PriceWithMultiplierButNoSpecialPrice
        {
            get
            {
                var priceList = new Dictionary<string, Price>
                {
                    ["A"] = new Price(50, 3, null)
                };
                return priceList;
            }
        }

        public static Dictionary<string, Price> PriceWithSpecialPriceButNoMultiplier
        {
            get
            {
                var priceList = new Dictionary<string, Price>
                {
                    ["A"] = new Price(50, null, 4)
                };
                return priceList;
            }
        }
    }
}