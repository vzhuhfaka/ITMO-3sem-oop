public class InDeliveryState : IOrderState
{
    private Order Order;

    public InDeliveryState(Order order)
    {
        Order = order;
    }

    public void Process()
    {
        Console.WriteLine($"Заказ {Order.Id} уже в доставке");
    }

    public void Cancel()
    {
        Console.WriteLine($"Заказ {Order.Id} невозможно отменить, так как он уже в доставке");
    }

    public void MarkAsDelivered()
    {
        Console.WriteLine($"Заказ {Order.Id} доставлен");
        Order.State = new DeliveredState(Order);
    }

    public string GetStatus() => "В доставке";
}