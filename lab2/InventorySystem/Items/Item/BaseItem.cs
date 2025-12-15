public abstract class BaseItem : IItem
{
    public string Id { get; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Weight { get; protected set; }
    public ItemRarity Rarity { get; protected set; }

    protected BaseItem(string id, string name, string description, int weight, ItemRarity rarity)
    {
        Id = id;
        Name = name;
        Description = description;
        Weight = weight;
        Rarity = rarity;
    }
}