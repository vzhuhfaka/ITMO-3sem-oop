public class MenuItemBuilder : IMenuItemBuilder
{
    private string _name = "";
    private string _description = "";
    private decimal _price = 0.0m;

    public IMenuItemBuilder SetName(string name)
    {
        _name = name;
        return this;
    }
    
    public IMenuItemBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }
    
    public IMenuItemBuilder SetPrice(decimal price)
    {
        _price = price;
        return this;
    }
    
    public MenuItem Build()
    {
        return new MenuItem(_name, _description, _price);
    }
}