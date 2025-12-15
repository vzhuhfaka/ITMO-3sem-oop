public interface IInventory
{
    Dictionary<string, IItem> Items { get; }
    int TotalWeight { get; }
    int MaxWeight { get; }
    
    void AddItem(IItem item);
    void RemoveItem(string itemId);
    bool CanAddItem(IItem item);
    IItem GetItem(string itemId);
    List<IItem> GetAllItems();
    List<IItem> GetEquippedItems();
    List<T> GetItemsByType<T>() where T : IItem;
    void EquipItem(string itemId);
    void UnequipItem(string itemId);
    void UseItem(string itemId, Character character);
    bool CanUpgradeItem(string itemId);
    void UpgradeItem(string itemId);
    string GetInventoryInfo();
}
