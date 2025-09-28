public class VendingMachine
{
    private Assortment _assort;
    private Utils utils = new Utils();
    private string _adminpassword;

    public void PrintProductsList()
    {
        _assort.printAssortment();
    }

    public int InsertMoney(int amount)
    {
        while (true)
        {
            Console.WriteLine($"Сумма в аппарате: {amount}");
            Console.WriteLine("Вставьте монеты номиналом:");
            Console.WriteLine("1. 1 руб.");
            Console.WriteLine("2. 10 руб.");
            Console.WriteLine("3. 50 руб.");
            Console.WriteLine("Чтобы закончить напишите end");
            var moneyChoice = Console.ReadLine();
            if (moneyChoice == "end")
            {
                return amount;
            }
            switch (moneyChoice)
            {
                case "1":
                    amount += 1;
                    break;
                case "2":
                    amount += 10;
                    break;
                case "3":
                    amount += 50;
                    break;
            }
        }
    }

    public string SelectProduct()
    {
        return "";
    }

    public string CancelOperation()
    {
        return "";
    }

    public bool EnterAdmin(string? password)
    {
        if (password == _adminpassword)
        {
            return true;
        }
        return false;
    }

    public void FillAssortment()
    {
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
            _assort.addSlot(name, priceInt, quantityInt, row, column);
        }
    }

    public string CollectMoney()
    {
        return "";
    }

    public string ExitAdmin()
    {
        return "";
    }

    public VendingMachine(int rows, int columns, string adminpassword)
    {
        _assort = new Assortment(rows, columns);
        _adminpassword = adminpassword;
    }
}
