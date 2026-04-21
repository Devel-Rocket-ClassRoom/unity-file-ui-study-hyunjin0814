using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiCharacterSlot : MonoBehaviour
{
    public int slotIndex = -1;

    public Image imageIcon;
    public TextMeshProUGUI textName;
    public Button button;
    public SaveCharacterData SaveCharacterData { get; private set; }

    public void SetEmpty()
    {
        imageIcon.sprite = null;
        textName.text = string.Empty;
        SaveCharacterData = null;
    }

    public void SetItem(SaveCharacterData data)
    {
        SaveCharacterData = data;
        imageIcon.sprite = SaveCharacterData.CharacterData.SpriteIcon;
        textName.text = SaveCharacterData.CharacterData.StringName;
    }
}
