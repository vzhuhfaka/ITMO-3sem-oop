class Money
{
    private int userMoney = 0;
    private int collectedMoney = 0;
    public void InsertMoney()
    {
        while (true)
        {
            Console.WriteLine($"Сумма в аппарате: {userMoney}");
            Console.WriteLine("Вставьте монеты номиналом:");
            Console.WriteLine("1. 1 руб.");
            Console.WriteLine("2. 10 руб.");
            Console.WriteLine("3. 50 руб.");
            Console.WriteLine("Чтобы закончить напишите end");
            var moneyChoice = Console.ReadLine();
            if (moneyChoice == "end")
            {
                break;
            }
            switch (moneyChoice)
            {
                case "1":
                    userMoney += 1;
                    break;
                case "2":
                    userMoney += 10;
                    break;
                case "3":
                    userMoney += 50;
                    break;
            }
        }
    }
    public int getUserMoney()
    {
        return userMoney;
    }
    public int getCollectedMoney()
    {
        return collectedMoney;
    }
    public void setUserMoney(int amount)
    {
        userMoney = amount;
    }
}