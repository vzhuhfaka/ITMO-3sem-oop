public class Potion : BaseItem, IUsable
{
    public PotionEffect Effect { get; }
    public int Power { get; }

    public Potion(string id, string name, string description, int weight,
        ItemRarity rarity, PotionEffect effect, int power)
        : base(id, name, description, weight, rarity)
    {
        Effect = effect;
        Power = power;
    }

    public void Use(Character character)
    {
        switch (Effect)
        {
            case PotionEffect.Health:
                character.Heal(Power);
                break;
            case PotionEffect.Mana:
                character.RestoreMana(Power);
                break;
            case PotionEffect.Stamina:
                character.RestoreStamina(Power);
                break;
        }
    }
}

public enum PotionEffect
{
    Health,
    Mana,
    Stamina
}