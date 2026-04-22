using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public Image icon;

    public LocalizationText_Answer textName;
    public LocalizationText_Answer textDesc;
    public LocalizationText_Answer textAttack;
    public LocalizationText_Answer textDeffense;

    public TextMeshProUGUI textAttackStat;
    public TextMeshProUGUI textDeffenseStat;

    public SaveCharacterData currentSaveCharacterData;

    public UiInvenSlot[] uiEquipedSlots;

    private void Start()
    {
        if (currentSaveCharacterData.CharacterData == null)
        {
            SetEmpty();
        }
    }

    public void SetEmpty()
    {
        icon.sprite = null;
        textName.id = string.Empty;
        textDesc.id = string.Empty;
        textAttack.id = string.Empty;
        textDeffense.id = string.Empty;

        textName.text.text = string.Empty;
        textDesc.text.text = string.Empty;
        textAttack.text.text = string.Empty;
        textDeffense.text.text = string.Empty;
        textAttackStat.text = string.Empty;
        textDeffenseStat.text = string.Empty;
    }

    //public void SetCharacterData(string characterId)
    //{
    //    CharacterData data = DataTableManager.CharacterTable.Get(characterId);
    //    SetCharacterData(data);
    //}

    public void SetCharacterData(SaveCharacterData saveCharacterData)
    {
        currentSaveCharacterData = saveCharacterData;
        CharacterData data = currentSaveCharacterData.CharacterData;
        icon.sprite = data.SpriteIcon;
        textName.id = data.Name;
        textDesc.id = data.Desc;
        textAttack.id = data.KeyAttack;
        textDeffense.id = data.KeyDeffense;

        textAttackStat.text = data.FinalAttack.ToString();
        textDeffenseStat.text = data.FinalDeffense.ToString();

        textName.OnChangedId();
        textDesc.OnChangedId();
        textAttack.OnChangedId();
        textDeffense.OnChangedId();

        //textAttack.text.text.

        //textAttack.OnChangedId();
        //textDeffense.OnChangedId();
        var equippedItems = currentSaveCharacterData.CharacterData.EquippedItems;

        if (equippedItems.ContainsKey(ItemTypes.Weapon))
        {
            uiEquipedSlots[0].SetItem(equippedItems[ItemTypes.Weapon]);
        }
        else
        {
            uiEquipedSlots[0].SetEmpty();
        }

        if (equippedItems.ContainsKey(ItemTypes.Equip))
        {
            uiEquipedSlots[1].SetItem(equippedItems[ItemTypes.Equip]);
        }
        else
        {
            uiEquipedSlots[1].SetEmpty();
        }

    }

    public void UpdateCharacterData()
    {
        SetCharacterData(currentSaveCharacterData);
    }
}
