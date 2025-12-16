public class PreparingState : IOrderState
{
    private Order Order;
    
    public PreparingState(Order order)
    {
        Order = order;
    }

    public void Process()
    {
        Console.WriteLine($"Заказ {Order.Id} передан в доставку");
        Order.State = new InDeliveryState(Order);
    }

    public void Cancel()
    {
        Console.WriteLine($"Заказ {Order.Id} отменен");
        Order.State = new CancelledState(Order);
    }

    public void MarkAsDelivered()
    {
        Console.WriteLine($"Заказ {Order.Id} не может быть доставлен пока готовится");
    }

    public string GetStatus() => "Готовится";
}