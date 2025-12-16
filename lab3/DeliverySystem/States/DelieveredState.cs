public class DeliveredState : IOrderState
{
    private Order Order;
    public DeliveredState(Order order)
    {
        Order = order;
    }

    public void Process()
    {
        Console.WriteLine($"Заказ {Order.Id} уже доставлен");
    }

    public void Cancel()
    {
        Console.WriteLine($"Заказ {Order.Id} уже доставлен");
    }

    public void MarkAsDelivered()
    {
        Console.WriteLine($"Заказ {Order.Id} уже доставлен");
    }

    public string GetStatus() => "Доставлено";
}