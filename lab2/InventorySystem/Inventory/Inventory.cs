public class Inventory : IInventory
{
    public Dictionary<string, IItem> Items { get; private set; }
    public int TotalWeight { get; private set; }
    public int MaxWeight { get; private set; }
    
    public Inventory(int maxWeight = 100)
    {
        Items = new Dictionary<string, IItem>();
        TotalWeight = 0;
        MaxWeight = maxWeight;
    }

    public void AddItem(IItem item)
    {
        if (TotalWeight + item.Weight > MaxWeight)
            throw new InvalidOperationException("Невозможно добавить предмет, так как он превышает вес инвентаря");

        Items[item.Id] = item;
        TotalWeight += item.Weight;
    }

    public void RemoveItem(string itemId)
    {
        if (!Items.ContainsKey(itemId))
            throw new InvalidOperationException("Такого предмета не найдено");

        var item = Items[itemId];
        TotalWeight -= item.Weight;
        Items.Remove(itemId);
    }

    public bool CanAddItem(IItem item) => TotalWeight + item.Weight <= MaxWeight;

    public IItem GetItem(string itemId)
    {
        var item = Items.GetValueOrDefault(itemId);
        if (item == null)
            throw new KeyNotFoundException($"Предмет с ID '{itemId}' не найден");
        return item;
    }

    public List<IItem> GetAllItems() => Items.Values.ToList();

    public List<IItem> GetEquippedItems() =>
        Items.Values.Where(item => item is IEquipable equipable && equipable.IsEquipped).ToList();

    public List<T> GetItemsByType<T>() where T : IItem =>
        Items.Values.OfType<T>().ToList();

    public void EquipItem(string itemId)
    {
        var item = GetItem(itemId);
        if (item is IEquipable equipable)
            equipable.Equip();
    }

    public void UnequipItem(string itemId)
    {
        var item = GetItem(itemId);
        if (item is IEquipable equipable)
            equipable.Unequip();
    }

    public void UseItem(string itemId, Character character)
    {
        var item = GetItem(itemId);
        if (item == null)
            throw new InvalidOperationException("Предмет не найден");

        if (item is IUsable usable)
        {
            usable.Use(character);
            
            // Удаляем зелье после использования
            if (item is Potion)
                RemoveItem(itemId);
        }
        else
        {
            throw new InvalidOperationException("Item is not usable");
        }
    }

    public bool CanUpgradeItem(string itemId)
    {
        var item = GetItem(itemId);
        if (item is not IUpgradable upgradable)
            return false;

        return upgradable.Level < upgradable.MaxLevel;
    }

    public void UpgradeItem(string itemId)
    {
        var item = GetItem(itemId);
        if (item is IUpgradable upgradable)
            upgradable.Upgrade();
        else
            throw new InvalidOperationException("Этот предмет нельзя улучшать");
    }


    public string GetInventoryInfo()
    {
        var info = $"Инвентарь (Вес: {TotalWeight}/{MaxWeight}):\n";
        
        var equipped = GetEquippedItems();
        if (equipped.Any())
        {
            info += "\nЭкипированные предметы:\n";
            foreach (var item in equipped)
                info += $"  - {item.Name} ({item.Rarity})\n";
        }

        var weapons = GetItemsByType<Weapon>();
        var armors = GetItemsByType<Armor>();
        var potions = GetItemsByType<Potion>();
        var questItems = Items.Values.OfType<QuestItem>();

        info += $"\nОружия: {weapons.Count}\n";
        info += $"Броня: {armors.Count}\n";
        info += $"зелья: {potions.Count}\n";
        info += $"Квестовые предметы: {questItems.Count()}\n";

        return info;
    }
}
