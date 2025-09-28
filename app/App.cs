

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
                    bool flag = true;
                    Console.WriteLine("Напишите в таком виде товар, который хотите добавить ->");
                    Console.WriteLine("<номер места> <наименование товара> <цена> <количество штук>");
                    while (flag)
                    {
                        Console.WriteLine("Напишите end чтобы закончить добавление");
                        string? slot = Console.ReadLine();
                        if (slot == "end")
                        {
                            break;
                        }
                        string[] parts = slot.Split();
                        string number = parts[0];
                        int row = utils.MatchNum(number[0].ToString());
                        int column = utils.MatchNum(number[1].ToString());
                        string name = parts[1];
                        string price = parts[2];
                        string quantity = parts[3];

                        int priceInt = int.Parse(price);
                        int quantityInt = int.Parse(quantity);
                        VM.FillAssortment(name, priceInt, quantityInt, row, column);
                    }
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
