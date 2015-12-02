namespace BusinessLogic.OrderLogic
{
    public class CartLogic
    {
        public CartLogic()
        {
        }

        public decimal CalculateTotalPrice(int quantity, decimal price)
        {
            return quantity*price;
        }
    }
}