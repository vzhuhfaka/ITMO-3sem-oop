public class ExpressDeliveryStrategy : IDeliveryStrategy
{
    public decimal CalculateDeliveryCost(decimal orderAmount)
    {
        return 200.0m;
    }
}