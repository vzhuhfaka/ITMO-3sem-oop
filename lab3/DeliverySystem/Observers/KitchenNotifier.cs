public class KitchenNotifier : IOrderObserver
{
    public void Update(Order order, string message)
        {
            Console.WriteLine($"Уведомление для кухни: #{order.Id} - {message}");
        }
}