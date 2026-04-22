using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class CharacterDataConverter : JsonConverter<CharacterData>
{
    public override CharacterData ReadJson(JsonReader reader, Type objectType, CharacterData existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jObj = JObject.Load(reader);

        string id = (string)jObj["id"];
        CharacterData data = DataTableManager.CharacterTable.Get(id);
        //data.EquippedItems = jObj["Items"];
        return data;
    }

    public override void WriteJson(JsonWriter writer, CharacterData value, JsonSerializer serializer)
    {
        writer.WriteStartObject();      // 중괄호 열기
        writer.WritePropertyName("Id");
        writer.WriteValue(value.Id);
        writer.WritePropertyName("Items");
        writer.WriteValue(value.EquippedItems);
        writer.WriteEndObject();        // 중괄호 닫기
    }
}