public class CustomerNotifier : IOrderObserver
{
    public void Update(Order order, string message)
        {
            Console.WriteLine($"Уведомление для клиента: {message}");
        }
}