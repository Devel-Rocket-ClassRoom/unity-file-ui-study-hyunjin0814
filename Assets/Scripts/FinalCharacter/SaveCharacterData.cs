using System;
using Newtonsoft.Json;

[Serializable]
public class SaveCharacterData
{
    public Guid instanceId { get; set; }

    [JsonConverter(typeof(CharacterDataConverter))]
    public CharacterData CharacterData { get; set; }
    public DateTime CreationTime { get; set; }


    public SaveCharacterData()
    {
        instanceId = Guid.NewGuid();
        CreationTime = DateTime.Now;
    }
}
