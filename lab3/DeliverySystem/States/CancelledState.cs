public class CancelledState : IOrderState
{
    private Order Order;
    public CancelledState(Order order)
    {
        Order = order;
    }

    public void Process()
    {
        Console.WriteLine($"Заказ {Order.Id} отменен");
    }

    public void Cancel()
    {
        Console.WriteLine($"Заказ {Order.Id} отменен");
    }

    public void MarkAsDelivered()
    {
        Console.WriteLine($"Заказ {Order.Id} отменен");
    }

    public string GetStatus() => "Отменено";
}