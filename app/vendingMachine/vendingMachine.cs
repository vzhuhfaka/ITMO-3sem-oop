public class VendingMachine
{
    private Assortment _assort;
    private Utils utils = new Utils();
    private Money money = new Money();
    private string _adminpassword;

    public void PrintProductsList()
    {
        _assort.printAssortment();
    }

    public void InsertMoney()
    {
        money.InsertMoney();
    }

    public string SelectProduct()
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

    public int getUserMoney()
    {
        return money.getUserMoney();
    }

    public int CollectMoney()
    {
        return money.getCollectedMoney();
    }

    public void nullUserMoney()
    {
        money.setUserMoney(0);
    }

    public VendingMachine(int rows, int columns, string adminpassword)
    {
        _assort = new Assortment(rows, columns);
        _adminpassword = adminpassword;
    }
}
