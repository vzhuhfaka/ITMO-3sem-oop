public class Programm
{
    public static void Main()
    {
        // Создаем персонажа
        var character = new Character("Hero");
        
        // Создаем инвентарь
        var inventory = new Inventory(50);
        
        // Создаем предметы с помощью Builder
        var sword = new WeaponBuilder()
            .SetName("Стальной меч")
            .SetDamage(25)
            .SetRarity(ItemRarity.Rare)
            .SetWeight(12)
            .Build();
            
        var armor = new ArmorBuilder()
            .SetName("Железный нагрудник")
            .SetDefense(15)
            .SetRarity(ItemRarity.Uncommon)
            .SetWeight(20)
            .Build();
            
        var potion = new PotionBuilder()
            .SetName("Зелье здоровья")
            .SetEffect(PotionEffect.Health)
            .SetPower(15)
            .Build();
        
        var digger = new WeaponBuilder()
            .SetName("Дамасский кинжал")
            .SetDamage(25)
            .SetRarity(ItemRarity.Legendary)
            .SetWeight(12)
            .Build();
        
        // Добавляем предметы в инвентарь
        inventory.AddItem(sword);
        inventory.AddItem(armor);
        inventory.AddItem(potion);
        inventory.AddItem(digger);
        
        Console.WriteLine("Добавленные в инвентарь предметы:");
        foreach (var item in inventory.GetAllItems())
        {
            Console.WriteLine($"- {item.Name} ({item.Rarity})");
        }
        
        // Экипируем оружие
        inventory.EquipItem(sword.Id);
        inventory.EquipItem(armor.Id);
        Console.WriteLine($"\nМеч экипирован: {(sword as IEquipable)?.IsEquipped}");
        Console.WriteLine($"\nБроня экипирована: {(armor as IEquipable)?.IsEquipped}");
        
        // Используем зелье
        Console.WriteLine($"\nПолное здоровье: {character.Health}");
        character.TakeDamage(20);
        Console.WriteLine($"Здоровье после получения урона: {character.Health}");
        inventory.UseItem(potion.Id, character);
        Console.WriteLine($"Здоровье после использования расходника: {character.Health}");
        
        // Выводим информацию об инвентаре
        Console.WriteLine($"\n{inventory.GetInventoryInfo()}");
        
        // Тест улучшения оружия
        Console.WriteLine($"\nУрон оружия до улучшения: {sword.Damage}");
        Console.WriteLine($"Уровень оружия до улучшения: {sword.Level}");
        if (inventory.CanUpgradeItem(sword.Id))
        {
            inventory.UpgradeItem(sword.Id);
            Console.WriteLine($"Урон оружия после улучшения: {sword.Damage}");
            Console.WriteLine($"Уровень оружия: {sword.Level}");
        }
    }
}