

public class Program
{
    public static void Main()
    {
        var VM = new VendingMachine(2, 2, "f");
        bool isAdmin = false;

        var utils = new Utils();

        int VMamount = 0;

        while (true)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Сумма в аппарате: {VMamount}");
            Console.WriteLine("1. Список доступных товаров");
            Console.WriteLine("2. Вставить монеты");
            Console.WriteLine("3. Выбрать товар");
            Console.WriteLine("4. Админ. режим");
            if (isAdmin)
            {
                Console.WriteLine("!Вы вошли в систему как администатор!");
                Console.WriteLine("5. Пополнить ассортимент");
                Console.WriteLine("6. Сбор собранных средств");
                Console.WriteLine("7. Выйти из режима администратора");
            }
            Console.WriteLine("----------------------------");


            var choice = Console.ReadLine();


            switch (choice)
            {
                case "1":
                    VM.PrintProductsList();
                    break;
                case "2":
                    VMamount = VM.InsertMoney(VMamount);
                    break;
                case "3":
                    Console.WriteLine(3);
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
                    Console.WriteLine(6);
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
