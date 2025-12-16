public interface IDeliveryStrategy
{
    decimal CalculateDeliveryCost(decimal orderAmount);
    
}