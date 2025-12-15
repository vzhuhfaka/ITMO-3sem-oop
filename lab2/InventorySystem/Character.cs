public class Character
{
    public string Name { get; }
    public int Health { get; private set; }
    public int MaxHealth { get; }
    public int Mana { get; private set; }
    public int MaxMana { get; }
    public int Stamina { get; private set; }
    public int MaxStamina { get; }

    public Character(string name, int maxHealth = 100, int maxMana = 50, int maxStamina = 100)
    {
        Name = name;
        MaxHealth = maxHealth;
        MaxMana = maxMana;
        MaxStamina = maxStamina;
        Health = maxHealth;
        Mana = maxMana;
        Stamina = maxStamina;
    }

    public void Heal(int amount) => Health = Math.Min(Health + amount, MaxHealth);
    public void RestoreMana(int amount) => Mana = Math.Min(Mana + amount, MaxMana);
    public void RestoreStamina(int amount) => Stamina = Math.Min(Stamina + amount, MaxStamina);
    
    public void TakeDamage(int amount) => Health = Math.Max(Health - amount, 0);
}
