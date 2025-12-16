public interface IOrderBuilder
{
    IOrderBuilder SetId(int id);
    IOrderBuilder AddItem(MenuItem menuItem);
    IOrderBuilder RemoveItem(MenuItem menuItem);
    IOrderBuilder SetDeliveryStrategy(IDeliveryStrategy strategy);
    IOrderBuilder SetDiscountStrategy(IDiscountStrategy strategy);
    IOrderBuilder SetState(IOrderState state);
    Order Build();
    void Reset();
}