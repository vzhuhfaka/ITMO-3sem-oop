public class QuestItem : BaseItem
{
    public string QuestId { get; }
    public bool IsQuestCompleted { get; private set; }

    public QuestItem(string id, string name, string description, int weight,
        ItemRarity rarity, string questId)
        : base(id, name, description, weight, rarity)
    {
        QuestId = questId;
    }

    public void MarkQuestCompleted() => IsQuestCompleted = true;
}