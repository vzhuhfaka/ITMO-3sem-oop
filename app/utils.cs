class Utils
{
    public int MatchNum(string num)
    {
        switch (num)
        {
            case "1":
                return 1;
            case "2":
                return 2;
            case "3":
                return 3;
            case "4":
                return 4;
            case "5":
                return 5;
            case "6":
                return 6;
            case "7":
                return 7;
            case "8":
                return 8;
            case "9":
                return 9;
            case "0":
                return 0;
        }
        return -1;
    }

    public int pow(int a, int b)
    {
        int res = a;
        if (b == 0)
        {
            return 1;
        }
        for (int i = 0; i < b - 1; i++)
        {
            res *= a;
        }
        return res;
    }

    public int StrToInt(string str)
    {
        int res = 0;
        for (int i = 0; i < str.Length; i++)
        {
            res += pow(10, i) * str[i];
            Console.WriteLine($"{str[i]} * {pow(10, i)} = {str[i] * pow(10, i)}");
        }
        return res;
    }
}