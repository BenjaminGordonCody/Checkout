namespace Checkouts
{
    interface ICheckout
    {
        void Scan(string item);
        float GetTotalPrice();
    }
}