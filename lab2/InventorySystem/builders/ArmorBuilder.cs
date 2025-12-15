public class ArmorBuilder
    {
        private string Id = Guid.NewGuid().ToString();
        private string Name = string.Empty;
        private string Description = string.Empty;
        private int Weight = 15;
        private ItemRarity Rarity = ItemRarity.Common;
        private int Defense = 10;
        private ArmorType Type = ArmorType.Chestplate;
        private int MaxLevel = 10;

        public ArmorBuilder SetName(string name) { 
            Name = name; 
            return this; 
        }
        public ArmorBuilder SetDescription(string description) { 
            Description = description; 
            return this; 
        }
        public ArmorBuilder SetWeight(int weight) { 
            Weight = weight; 
            return this; 
        }
        public ArmorBuilder SetRarity(ItemRarity rarity) { 
            Rarity = rarity; 
            return this; 
        }
        public ArmorBuilder SetDefense(int defense) { 
            Defense = defense; 
            return this; 
        }
        public ArmorBuilder SetType(ArmorType type) { 
            Type = type; 
            return this; 
        }
        public ArmorBuilder SetMaxLevel(int maxLevel) { 
            MaxLevel = maxLevel; 
            return this; 
        }

        public Armor Build() 
        {
            return new Armor(Id, Name, Description, Weight, Rarity, Defense, Type, MaxLevel);
        }
    }