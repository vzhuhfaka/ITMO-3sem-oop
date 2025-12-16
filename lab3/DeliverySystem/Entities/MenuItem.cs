public class MenuItem
{
    public string Name {get; set;}
    public decimal Price {get; set;}
    public string Description {get; set;}
    public string GetString()
    {
        return $"{Name} - {Price}";
    }
    public MenuItem(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
}