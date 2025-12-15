
public interface IArmor : IEquipable, IUpgradable
{
    int Defense { get; }
    ArmorType Type { get; }
}

public enum ArmorType
{
    Helmet,
    Chestplate,
    Leggings,
    Boots,
    Shield
}
