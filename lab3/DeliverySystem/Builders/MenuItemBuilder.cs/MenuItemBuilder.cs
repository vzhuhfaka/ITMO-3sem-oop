public class MenuItemBuilder : IMenuItemBuilder
{
    MenuItem menuItem = new MenuItem("", "", 0.0m);

    public IMenuItemBuilder SetName(string name)
    {
        menuItem.Name = name;
        return this;
    }
    public IMenuItemBuilder SetDescription(string description)
    {
        menuItem.Description = description;
        return this;
    }
    public IMenuItemBuilder SetPrice(decimal price)
    {
        menuItem.Price = price;
        return this;
    }
    public MenuItem Build()
    {
        return menuItem;
    }
}