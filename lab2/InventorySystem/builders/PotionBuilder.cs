public class PotionBuilder
    {
        private string Id = Guid.NewGuid().ToString();
        private string Name = string.Empty;
        private string Description = string.Empty;
        private int Weight = 1;
        private ItemRarity Rarity = ItemRarity.Common;
        private PotionEffect Effect = PotionEffect.Health;
        private int Power = 20;

        public PotionBuilder SetName(string name) { 
            Name = name; 
            return this; 
            }
        public PotionBuilder SetDescription(string description) { 
            Description = description; 
            return this; 
        }
        public PotionBuilder SetWeight(int weight) { 
            Weight = weight; 
            return this; 
        }
        public PotionBuilder SetRarity(ItemRarity rarity) { 
            Rarity = rarity; 
            return this; 
        }
        public PotionBuilder SetEffect(PotionEffect effect) { 
            Effect = effect; 
            return this; 
        }
        public PotionBuilder SetPower(int power) { 
            Power = power; 
            return this; 
        }

        public Potion Build()
        {
            return new Potion(Id, Name, Description, Weight, Rarity, Effect, Power);
        }
    }