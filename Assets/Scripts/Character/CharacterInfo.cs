using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public Image icon;

    public LocalizationText_Answer textName;
    public LocalizationText_Answer textDesc;
    public LocalizationText_Answer textAttack;
    public LocalizationText_Answer textDeffense;
    public LocalizationText_Answer textAttackStat;
    public LocalizationText_Answer textDeffenseStat;

    public void SetEmpty()
    {
        icon.sprite = null;
        textName.id = string.Empty;
        textDesc.id = string.Empty;
        textAttack.id = string.Empty;
        textDeffense.id = string.Empty;
        textAttackStat.id = string.Empty;
        textDeffenseStat.id = string.Empty;

        textName.text.text = string.Empty;
        textDesc.text.text = string.Empty;
        textAttack.text.text = string.Empty;
        textDeffense.text.text = string.Empty;
        textAttackStat.text.text = string.Empty;
        textDeffenseStat.text.text = string.Empty;
    }

    public void SetCharacterData(string characterId)
    {
        CharacterData data = DataTableManager.CharacterTable.Get(characterId);
        SetCharacterData(data);
    }

    public void SetCharacterData(CharacterData data)
    {
        icon.sprite = data.SpriteIcon;
        textName.id = data.Name;
        textDesc.id = data.Desc;
        textAttack.id = data.KeyAttack;
        textDeffense.id = data.KeyDeffense;

        textAttackStat.text.text = data.Attack.ToString();
        textDeffenseStat.text.text = data.Deffense.ToString();

        textAttackStat.Describe();
        textDeffenseStat.Describe();

        textName.OnChangedId();
        textDesc.OnChangedId();
        textAttack.OnChangedId();
        textDeffense.OnChangedId();

        //textAttack.text.text.

        //textAttack.OnChangedId();
        //textDeffense.OnChangedId();
    }
}
