

public class Program
{
    public static void Main()
    {
        string adminpassword = "f";
        int rows = 2;
        int columns = 2;
        var VM = new VendingMachine(rows, columns, adminpassword);
        bool isAdmin = false;

        while (true)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Сумма в аппарате: {VM.getUserMoney()}");
            Console.WriteLine("0. Вернуть деньги (отменить операцию)");
            Console.WriteLine("1. Список доступных товаров");
            Console.WriteLine("2. Вставить монеты");
            Console.WriteLine("3. Выбрать товар");
            Console.WriteLine("4. Админ. режим");
            if (isAdmin)
            {
                Console.WriteLine("!Вы вошли в систему как администатор!");
                Console.WriteLine($"Средств в аппарате: {VM.getCollectedMoney()}");
                Console.WriteLine("5. Пополнить ассортимент");
                Console.WriteLine("6. Сбор собранных средств");
                Console.WriteLine("7. Выйти из режима администратора");
            }
            Console.WriteLine("----------------------------");


            var choice = Console.ReadLine();


            switch (choice)
            {
                case "0":
                    Console.WriteLine($"Возвращено денег: {VM.getUserMoney()}");
                    VM.nullUserMoney();
                    break;
                case "1":
                    VM.PrintProductsList();
                    break;
                case "2":
                    VM.InsertMoney();
                    break;
                case "3":
                    Console.WriteLine("Напишите номер товара для покупки");
                    string? productChoice = Console.ReadLine();
                    VM.SelectProduct(productChoice);
                    
                    break;
                case "4":
                    if (!isAdmin)
                    {
                        Console.WriteLine("Введите пароль");
                        var password = Console.ReadLine();
                        bool auth = VM.EnterAdmin(password);
                        if (auth)
                        {
                            isAdmin = true;
                            Console.WriteLine("Вы вошли в систему как администатор");
                        }
                        else
                        {
                            Console.WriteLine("Пароль неверный");
                        }
                    }
                    break;
                case "5":
                    if (!isAdmin)
                    {
                        break;
                    }
                    VM.FillAssortment();
                    break;
                case "6":
                    if (!isAdmin)
                    {
                        break;
                    }
                    int collectedMoney = VM.CollectMoney();
                    Console.WriteLine($"Собрано средств: {collectedMoney}");
                    break;
                case "7":
                    if (!isAdmin)
                    {
                        break;
                    }
                    isAdmin = false;
                    Console.WriteLine("Вы вышли из режима администратора");
                    break;
            }
        }
    }
}
