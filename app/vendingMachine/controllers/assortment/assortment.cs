public class Assortment
{
    private int _rows;
    private int _columns;
    private string[,] _assortment;
    private int[,] _prices;
    private int[,] _quantities;

    public void addSlot(string item, int price, int quantity, int row, int column)
    {
        _assortment[row, column] = item;
        _prices[row, column] = price;
        _quantities[row, column] = quantity;
    }

    public void removeSlot(int row, int column)
    {
        _assortment[row, column] = "none";
        _prices[row, column] = 0;
        _quantities[row, column] = 0;
    }

    public string getOneItem(int row, int column)
    {
        _quantities[row, column]--;
        string requestedItem = _assortment[row, column];
        return requestedItem;
    }

    public void printAssortment()
    {
        for (int row1 = 0; row1 < _rows; row1++)
        {
            for (int col1 = 0; col1 < _columns; col1++)
            {
                Console.WriteLine($"Номер: {row1}{col1}; Товар: {_assortment[row1, col1]}; Цена: {_prices[row1, col1]}; Осталось штук: {_quantities[row1, col1]}");
            }
        }
    }

    public Assortment(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
        _assortment = new string[_rows, _columns];
        _prices = new int[_rows, _columns];
        _quantities = new int[_rows, _columns];
    } 
}