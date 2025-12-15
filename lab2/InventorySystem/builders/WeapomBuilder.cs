public class WeaponBuilder
{
    private string Id = Guid.NewGuid().ToString();
    private string Name = string.Empty;
    private string Description = string.Empty;
    private int Weight = 10;
    private ItemRarity Rarity = ItemRarity.Common;
    private int Damage = 15;
    private WeaponType Type = WeaponType.Sword;
    private int MaxLevel = 10;

    public WeaponBuilder SetName(string name) {
        Name = name; 
        return this; 
    }
    public WeaponBuilder SetDescription(string description) { 
        Description = description; 
        return this; 
    }
    public WeaponBuilder SetWeight(int weight) { 
        Weight = weight; 
        return this; 
    }
    public WeaponBuilder SetRarity(ItemRarity rarity) { 
        Rarity = rarity; 
        return this; 
    }
    public WeaponBuilder SetDamage(int damage) { 
        Damage = damage; 
        return this; 
    }
    public WeaponBuilder SetType(WeaponType type) { 
        Type = type; 
        return this; 
    }
    public WeaponBuilder SetMaxLevel(int maxLevel) { 
        MaxLevel = maxLevel; 
        return this; 
    }

    public Weapon Build()
    {
        return new Weapon(Id, Name, Description, Weight, Rarity, Damage, Type, MaxLevel);
    }
}