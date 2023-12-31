using Checkout = Checkouts.Checkout;

namespace CheckoutTests
{

    public class UnitTests
    {
        [Fact]
        public void Checkout_Init_ExpectedInputThrowsNoErrors()
        {
            var exception = Record.Exception(() => new Checkout(MockData.CurrentPrice()));
            Assert.Null(exception);
        }

        [Fact]
        public void Checkout_Init_EmptyPriceInputThrowsErrors()
        {
            var exception = Record.Exception(() => new Checkout(MockData.EmptyPrice));
            Assert.NotNull(exception);
            Assert.Equal("Price List is empty.", exception.Message);
        }

        [Fact]
        public void Checkout_Init_PriceInputWithMultiplierButNoSpecialPriceThrowsErrors()
        {
            var exception = Record.Exception(() => new Checkout(MockData.PriceWithMultiplierButNoSpecialPrice));
            Assert.NotNull(exception);
            Assert.Equal("Price List is not formatted correctly.", exception.Message);

        }

        [Fact]
        public void Checkout_Init_PrinceInputWithSpecialPriceButNoMultiplier()
        {
            var exception = Record.Exception(() => new Checkout(MockData.PriceWithSpecialPriceButNoMultiplier));
            Assert.NotNull(exception);
            Assert.Equal("Price List is not formatted correctly.", exception.Message);
        }

        [Fact]
        public void Checkout_Scan_UnknownSkuThrowsError()
        {
            var sut = new Checkout(MockData.CurrentPrice());
            var exception = Record.Exception(() => sut.Scan("UnknownSku"));
            Assert.NotNull(exception);
            Assert.Equal("Checkout does not recognise the scanned SKU", exception.Message);
        }

        [Fact]
        public void Checkout_GetTotalPrice_BasicPricesOnly()
        {
            var sut = new Checkout(MockData.CurrentPrice());
            var items = new string[] { "A", "B", "C", "D" };
            foreach (var sku in items)
            {
                sut.Scan(sku);
            }
            var totalPrice = sut.GetTotalPrice();
            Assert.Equal(50 + 30 + 20 + 15, totalPrice);
        }

        [Fact]
        public void Checkout_MultipleScans_BasicPricesOnly()
        {
            var sut = new Checkout(MockData.CurrentPrice());
            var items = new string[] { "A", "C", "D", "A", "C", "D" };
            foreach (var sku in items)
            {
                sut.Scan(sku);
            }
            var totalPrice = sut.GetTotalPrice();
            Assert.Equal(50 + 20 + 15 + 50 + 20 + 15, totalPrice);
        }

        [Fact]
        public void Checkout_GetTotalPrice_4ScansPerSku_SpecialPrices()
        {
            var sut = new Checkout(MockData.CurrentPrice());
            var items = new string[] { "A", "B", "C", "D" };

            for (int i = 0; i < 4; i++)
            {
                foreach (var sku in items)
                {
                    sut.Scan(sku);
                }
            }

            float expectedPriceA = 130 + 50;
            float expectedPriceB = 90;
            float expectedPriceC = 80;
            float expectedPriceD = 60;

            float expectedTotal = expectedPriceA + expectedPriceB + expectedPriceC + expectedPriceD;
            var totalPrice = sut.GetTotalPrice();
            Assert.Equal(expectedTotal, totalPrice);
        }

        [Fact]
        public void Checkout_GetTotalPrice_3ScansPerSku_SpecialPrices()
        {
            var sut = new Checkout(MockData.CurrentPrice());
            var items = new string[] { "A", "B", "C", "D" };

            for (int i = 0; i < 3; i++)
            {
                foreach (var sku in items)
                {
                    sut.Scan(sku);
                }
            }

            float expectedPriceA = 130;
            float expectedPriceB = 45 + 30;
            float expectedPriceC = 60;
            float expectedPriceD = 45;

            float expectedTotal = expectedPriceA + expectedPriceB + expectedPriceC + expectedPriceD;
            var totalPrice = sut.GetTotalPrice();
            Assert.Equal(expectedTotal, totalPrice);
        }
    }
}