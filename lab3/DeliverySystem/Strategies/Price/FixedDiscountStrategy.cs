public class FixedDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateAmount(decimal orderAmount)
    {
        return orderAmount - 50;
    }
}