public class Order
{
    public int Id {get; set;}
    public List<MenuItem> Items {get; }
    public IOrderState State {get; set;}
    public IDeliveryStrategy DeliveryStrategy {get; set;}
    public IDiscountStrategy DiscountStrategy {get; set;}
    public decimal TotalPrice => CalculateTotal();
    private OrderStatusPublisher StatusPublisher = new();
    
    public void SubscribeObserver(IOrderObserver observer) => StatusPublisher.Subscribe(observer);
    public void UnsubscribeObserver(IOrderObserver observer) => StatusPublisher.Unsubscribe(observer);

    public Order(int id, IDeliveryStrategy deliveryStrategy, IDiscountStrategy discountStrategy)
    {
        Id = id;
        DeliveryStrategy = deliveryStrategy;
        DiscountStrategy = discountStrategy;
        State = new PreparingState(this);
        Items = new();
    }
    public void AddItem(MenuItem orderItem) => Items.Add(orderItem);
    public void Removeitem(MenuItem orderItem) => Items.Remove(orderItem);
    public decimal ItemsPriceSum()
    {
        decimal subtotal = 0;
        foreach (MenuItem item in Items)
        {
            subtotal += item.Price;
        }
        return subtotal;
    }
    private decimal CalculateTotal()
    {
        decimal pricesSum = ItemsPriceSum();
        decimal deliveryCost = DeliveryStrategy.CalculateDeliveryCost(pricesSum);
        decimal subtotal = pricesSum + deliveryCost;

        decimal total = DiscountStrategy.CalculateAmount(subtotal);
        return total;
    }
    public void Process()
    {
        State.Process();
        StatusPublisher.Notify(this, $"(Уведомление) Заказ #{Id} перешел в статус: {State.GetStatus()}");
    }
    public void Cancel()
    {
        State.Cancel();
        StatusPublisher.Notify(this, $"(Уведомление) Заказ #{Id} перешел в статус: {State.GetStatus()}");
    }
    public void MarkAsDelivered()
    {
        State.MarkAsDelivered();
        StatusPublisher.Notify(this, $"(Уведомление) Заказ #{Id} перешел в статус: {State.GetStatus()}");
    }
    public string GetString()
    {
        string items = "";
        foreach (MenuItem item in Items)
        {
            items += item.GetString() + "; ";
        }
        return $"Заказ #{Id} содержит следующее: {items}";
    }
}