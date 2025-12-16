public class StandardDeliveryStrategy : IDeliveryStrategy
{
    public decimal CalculateDeliveryCost(decimal orderAmount)
    {
        if (orderAmount >= 1000)
        {
            return 0;
        } else
        {
            return orderAmount * 0.01m;
        }
    }
}