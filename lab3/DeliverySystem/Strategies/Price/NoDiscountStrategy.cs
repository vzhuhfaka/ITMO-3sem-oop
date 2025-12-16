public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateAmount(decimal orderAmount)
    {
        return orderAmount;
    }
}