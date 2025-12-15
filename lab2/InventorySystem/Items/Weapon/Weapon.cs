public class Weapon : BaseItem, IEquipable, IUpgradable
{
    public int Damage { get; private set; }
    public WeaponType Type { get; }
    public bool IsEquipped { get; set; }
    public int Level { get; private set; }
    public int MaxLevel { get; }

    public Weapon(string id, string name, string description, int weight, 
        ItemRarity rarity, int damage, WeaponType type, int maxLevel = 10)
        : base(id, name, description, weight, rarity)
    {
        Damage = damage;
        Type = type;
        Level = 1;
        MaxLevel = maxLevel;
    }

    public void Equip() => IsEquipped = true;
    public void Unequip() => IsEquipped = false;

    public void Upgrade()
    {
        if (Level >= MaxLevel)
            throw new InvalidOperationException($"Оружие {Name} уже на максимальном уровне");

        Level++;
        Damage = (int)(Damage * 1.2);
    }
}

public enum WeaponType
{
    Sword,
    Axe,
    Bow,
    Staff,
    Dagger
}
