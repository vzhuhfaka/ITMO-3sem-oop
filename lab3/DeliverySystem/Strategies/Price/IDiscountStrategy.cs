public interface IDiscountStrategy
{
    decimal CalculateAmount(decimal orderAmount);
}