public class OrderStatusPublisher
{
    private readonly List<IOrderObserver> Observers = new();

    public void Subscribe(IOrderObserver observer)
    {
        if (!Observers.Contains(observer))
            Observers.Add(observer);
    }

    public void Unsubscribe(IOrderObserver observer)
    {
        Observers.Remove(observer);
    }

    public void Notify(Order order, string message)
    {
        foreach (var observer in Observers)
        {
            observer.Update(order, message);
        }
    }
}