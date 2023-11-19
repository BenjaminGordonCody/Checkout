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
        }

        [Fact]
        public void Checkout_Init_PriceInputWithMultiplierButNoSpecialPriceThrowsErrors()
        {
            var exception = Record.Exception(() => new Checkout.Checkout(MockData.PriceWithMultiplierButNoSpecialPrice));
            Assert.NotNull(exception);
        }

        [Fact]
        public void Checkout_Init_PrinceInputWithSpecialPriceButNoMultiplier()
        {
            var exception = Record.Exception(() => new Checkout.Checkout(MockData.PriceWithSpecialPriceButNoMultiplier));
            Assert.NotNull(exception);
        }
    }
}