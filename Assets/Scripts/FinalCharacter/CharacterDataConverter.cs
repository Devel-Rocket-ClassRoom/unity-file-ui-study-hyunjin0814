using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

public class CharacterDataConverter : JsonConverter<CharacterData>
{
    public override CharacterData ReadJson(JsonReader reader, Type objectType, CharacterData existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jObj = JObject.Load(reader);

        string id = (string)jObj["Id"];
        CharacterData data = DataTableManager.CharacterTable.Get(id).Clone();

        if (data != null && jObj["Items"] != null)
        {
            // 역직렬화
            var items = jObj["Items"].ToObject<Dictionary<ItemTypes, SaveItemData>>(serializer);

            // null 체크
            data.EquippedItems = items ?? new Dictionary<ItemTypes, SaveItemData>();                
        }

        return data;
    }

    public override void WriteJson(JsonWriter writer, CharacterData value, JsonSerializer serializer)
    {
        writer.WriteStartObject();      // 중괄호 열기
        writer.WritePropertyName("Id");
        writer.WriteValue(value.Id);
        writer.WritePropertyName("Items");
        serializer.Serialize(writer, value.EquippedItems);
        writer.WriteEndObject();        // 중괄호 닫기
    }
}