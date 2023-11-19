using Checkout;

namespace Tests
{

    public class UnitTests
    {
        [Fact]
        public void Checkout_Init_ExpectedInputThrowsNoErrors()
        {
            var exception = Record.Exception(() => new Checkout.Checkout(MockData.CurrentPrice()));
            Assert.Null(exception);
        }

        [Fact]
        public void Checkout_Init_EmptyPriceInputThrowsErrors()
        {
            var exception = Record.Exception(() => new Checkout.Checkout(MockData.EmptyPrice));
            Assert.NotNull(exception);
            Assert.Equal("Price List is empty.", exception.Message);
        }

        [Fact]
        public void Checkout_Init_PriceInputWithMultiplierButNoSpecialPriceThrowsErrors()
        {
            var exception = Record.Exception(() => new Checkout.Checkout(MockData.PriceWithMultiplierButNoSpecialPrice));
            Assert.NotNull(exception);
            Assert.Equal("Price List is not formatted correctly.", exception.Message);

        }

        [Fact]
        public void Checkout_Init_PrinceInputWithSpecialPriceButNoMultiplier()
        {
            var exception = Record.Exception(() => new Checkout.Checkout(MockData.PriceWithSpecialPriceButNoMultiplier));
            Assert.NotNull(exception);
            Assert.Equal("Price List is not formatted correctly.", exception.Message);
        }

        [Fact]
        public void Checkout_Scan_UnknownSkuThrowsError()
        {
            var sut = new Checkout.Checkout(MockData.CurrentPrice());
            var exception = Record.Exception(() => sut.Scan("UnknownSku"));
            Assert.NotNull(exception);
            Assert.Equal("Checkout does not recognise the scanned SKU", exception.Message);
        }

        [Fact]
        public void Checkout_GetTotalPrice_BasicPricesOnly()
        {
            var sut = new Checkout.Checkout(MockData.CurrentPrice());
            var items = new string[]{ "A", "B", "C", "D" };
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
            var sut = new Checkout.Checkout(MockData.CurrentPrice());
            var items = new string[] { "A", "C", "D", "A", "C", "D" };
            foreach (var sku in items)
            {
                sut.Scan(sku);
            }
            var totalPrice = sut.GetTotalPrice();
            Assert.Equal(50 + 20 + 15 + 50 + 20 + 15, totalPrice);
        }
    }
}