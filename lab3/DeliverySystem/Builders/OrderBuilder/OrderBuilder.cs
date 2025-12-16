public class OrderBuilder : IOrderBuilder
{
    private Order Order = new Order(0, 
        new StandardDeliveryStrategy(), 
        new NoDiscountStrategy());

    private static int OrderIdCounter = 1;
    public OrderBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        Order = new Order(OrderIdCounter++, 
            new StandardDeliveryStrategy(), 
            new NoDiscountStrategy());
    }

    public IOrderBuilder SetId(int id)
    {
        Order.Id = id;
        return this;
    }

    public IOrderBuilder AddItem(MenuItem menuItem)
    {
        Order.AddItem(menuItem);
        return this;
    }

    public IOrderBuilder RemoveItem(MenuItem menuItem)
    {
        Order.Removeitem(menuItem);
        return this;
    }

    public IOrderBuilder SetDeliveryStrategy(IDeliveryStrategy strategy)
    {
        Order.DeliveryStrategy = strategy;
        return this;
    }

    public IOrderBuilder SetDiscountStrategy(IDiscountStrategy strategy)
    {
        Order.DiscountStrategy = strategy;
        return this;
    }

    public IOrderBuilder SetState(IOrderState state)
    {
        Order.State = state;
        return this;
    }

    public Order Build()
    {
        var result = Order;
        Reset();
        return result;
    }
}