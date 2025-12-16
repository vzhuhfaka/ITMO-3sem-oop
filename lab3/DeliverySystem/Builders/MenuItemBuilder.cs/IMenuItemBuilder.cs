public interface IMenuItemBuilder
{
    IMenuItemBuilder SetName(string name);
    IMenuItemBuilder SetDescription(string description);
    IMenuItemBuilder SetPrice(decimal price);
}