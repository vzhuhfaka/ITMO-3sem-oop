public class PercentDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateAmount(decimal orderAmount)
    {
        return orderAmount * 0.95m;
    }
}