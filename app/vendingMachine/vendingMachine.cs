public class VendingMachine
{
    private Assortment _assort;
    private Utils utils = new Utils();
    private Money _money = new Money();
    private string _adminpassword;

    public void PrintProductsList()
    {
        _assort.printAssortment();
    }

    public void InsertMoney()
    {
        _money.InsertMoney();
    }

    public void SelectProduct(string slotNum)
    {
        int row = utils.MatchNum(slotNum[0].ToString());
        int column = utils.MatchNum(slotNum[1].ToString());
        string product = _assort.getOneItemName(row, column);
        if (product == "")
        {
            Console.WriteLine("Такого товара нет, выберите другой");
            return;
        }
        else if (product == "none")
        {
            Console.WriteLine("Товар закончился, выберите другой");
            return;
        }
        int productPrice = _assort.getOneItemPrice(row, column);
        int userMoney = _money.getUserMoney();
        if (userMoney >= productPrice)
        {
            _money.setUserMoney(userMoney - productPrice);
            Console.WriteLine("*Выдача товара*");
            Console.WriteLine("Спасибо за покупку!");
        }
        else
        {
            Console.WriteLine("Недостаточно средств");
        }
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
        return _money.getUserMoney();
    }

    public int getCollectedMoney()
    {
        return _money.getCollectedMoney();
    }

    public int CollectMoney()
    {
        return _money.getCollectedMoney();
    }

    public void nullUserMoney()
    {
        _money.setUserMoney(0);
    }

    public void nullCollectedMoney()
    {
        _money.setCollectedMoney(0);
    }

    public VendingMachine(int rows, int columns, string adminpassword)
    {
        _assort = new Assortment(rows, columns);
        _adminpassword = adminpassword;
    }
}
