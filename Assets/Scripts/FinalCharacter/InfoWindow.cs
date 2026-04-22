using UnityEngine;

public class InfoWindow : MonoBehaviour
{
    public UiPanelInventory inventory;
    public CharacterInfo characterInfo;
    public System.Action OnCloseEvent;

    public void Open(SaveCharacterData data)
    {
        if (data == null)
        {
            Debug.Log("SaveCharacterData가 Null임");
            return;
        }

        gameObject.SetActive(true);

        if (characterInfo == null)
        {
            Debug.Log("characterInfo가 Null임");
            return;
        }
        characterInfo.SetCharacterData(data);
    }

    public void Close()
    {
        inventory.OnSave();
        gameObject.SetActive(false);
        OnCloseEvent?.Invoke();
    }
}
