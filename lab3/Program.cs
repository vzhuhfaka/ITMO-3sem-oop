public class Program
{
    public static void Main()
    {
        // Создаем объекты для меню
        var menuItem1 = new MenuItemBuilder()
            .SetName("Блины")
            .SetDescription("Блины(описание)")
            .SetPrice(440)
            .Build();
        var menuItem2 = new MenuItemBuilder()
            .SetName("Борщ")
            .SetDescription("Борщ(описание)")
            .SetPrice(550)
            .Build();
        var menuItem3 = new MenuItemBuilder()
            .SetName("Салат")
            .SetDescription("Салат(описание)")
            .SetPrice(370)
            .Build();
        Console.WriteLine("Блюда в меню:");
        Console.WriteLine(menuItem1.GetString()); // "Блины - 499"
        Console.WriteLine(menuItem2.GetString()); // "Борщ - 550"
        Console.WriteLine(menuItem3.GetString()); // "Салат - 370"

        // Создаем заказ
        var deliveryStrategy1 = new StandardDeliveryStrategy();
        var discountStrategy1 = new NoDiscountStrategy();
        
        var order1 = new OrderBuilder()
            .SetDeliveryStrategy(deliveryStrategy1)
            .SetDiscountStrategy(discountStrategy1)
            .AddItem(menuItem1)
            .AddItem(menuItem2)
            .Build();

        var deliveryStrategy2 = new ExpressDeliveryStrategy();
        var discountStrategy2 = new PercentDiscountStrategy();
        
        var order2 = new OrderBuilder()
            .SetDeliveryStrategy(deliveryStrategy2)
            .SetDiscountStrategy(discountStrategy2)
            .AddItem(menuItem2)
            .AddItem(menuItem3)
            .Build();

        // Создаем наблюдателей
        var kitchenNotifier = new KitchenNotifier();
        var customerNotifier = new CustomerNotifier();
        // Привязываем наблюдателей к order1
        order1.SubscribeObserver(kitchenNotifier);
        order1.SubscribeObserver(customerNotifier);
        // Провязываем наблюдателей к order2
        order2.SubscribeObserver(kitchenNotifier);
        order2.SubscribeObserver(customerNotifier);

        // Выведем состав заказов
        Console.WriteLine();
        Console.WriteLine(order1.GetString());
        Console.WriteLine(order2.GetString());

        Console.WriteLine($"Статус заказа #{order1.Id}: {order1.State.GetStatus()}");
        Console.WriteLine($"Статус заказа #{order2.Id}: {order2.State.GetStatus()}");

        // Изменим статус заказа
        Console.WriteLine();
        Console.WriteLine($"Статус заказа #{order1.Id}: {order1.State.GetStatus()}");
        order1.Process();
        Console.WriteLine($"Статус заказа #{order1.Id}: {order1.State.GetStatus()}");
        
        Console.WriteLine();
        Console.WriteLine($"Статус заказа #{order2.Id}: {order2.State.GetStatus()}");
        order2.Process();
        order2.MarkAsDelivered();
        Console.WriteLine($"Статус заказа #{order2.Id}: {order2.State.GetStatus()}");
    }
}