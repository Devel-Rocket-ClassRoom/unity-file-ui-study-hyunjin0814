using System;
using Newtonsoft.Json;

[Serializable]
public class SaveCharacterData
{
    public Guid instanceId { get; set; }

    [JsonConverter(typeof(CharacterDataConverter))]
    public CharacterData CharacterData { get; set; }
    public DateTime CreationTime { get; set; }

    //public static SaveItemData GetRandomItem()
    //{
    //    SaveItemData newItem = new SaveItemData();
    //    newItem.ItemData = DataTableManager.ItemTable.GetRandom();
    //    return newItem;
    //}

    public SaveCharacterData()
    {
        instanceId = Guid.NewGuid();
        CreationTime = DateTime.Now;
    }

    //public override string ToString()
    //{
    //    return $"{instanceId}\n{CreationTime}\n{CharacterData.Id}";
    //}
}
