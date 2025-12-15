public class Armor : BaseItem, IArmor
    {
        public int Defense { get; private set; }
        public ArmorType Type { get; }
        public bool IsEquipped { get; set; }
        public int Level { get; private set; }
        public int MaxLevel { get; }

        public Armor(string id, string name, string description, int weight,
            ItemRarity rarity, int defense, ArmorType type, int maxLevel = 10)
            : base(id, name, description, weight, rarity)
        {
            Defense = defense;
            Type = type;
            Level = 1;
            MaxLevel = maxLevel;
        }

        public void Equip() => IsEquipped = true;
        public void Unequip() => IsEquipped = false;

        public void Upgrade()
        {
            if (Level >= MaxLevel)
                throw new InvalidOperationException($"Armor {Name} is already at max level");

            Level++;
            Defense = (int)(Defense * 1.15);
        }
    }