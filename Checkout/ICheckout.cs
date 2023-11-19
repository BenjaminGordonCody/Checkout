namespace Checkout
{
    interface ICheckout
    {
        void Scan(string item);
        float GetTotalPrice();
    }
}