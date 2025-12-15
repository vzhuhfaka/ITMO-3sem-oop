public interface IItem
{
    string Id { get; }
    string Name { get; }
    string Description { get; }
    int Weight { get; }
    ItemRarity Rarity { get; }
}

public interface IEquipable : IItem
{
    bool IsEquipped { get; set; }
    void Equip();
    void Unequip();
}

public interface IUsable : IItem
{
    void Use(Character character);
}

public interface IUpgradable : IItem
{
    int Level { get; }
    void Upgrade();
    int MaxLevel { get; }
}

public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
