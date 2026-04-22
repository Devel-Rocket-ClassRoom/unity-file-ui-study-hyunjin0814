using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterWindow : MonoBehaviour
{
    public UiCharacterSlotList uiCharacterSlotList;
    public InfoWindow infoWindow;
    public CharacterInfo characterInfo;

    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public Button createWarriorButton;
    public Button createTankerButton;
    public Button createThiefButton;
    public Button RemoveCharacterButton;
    public Button saveCharactersButton;

    private void Awake()
    {
        createWarriorButton.onClick.AddListener(OnCreateWarrior);
        createTankerButton.onClick.AddListener(OnCreateTanker);
        createThiefButton.onClick.AddListener(OnCreateThief);
        RemoveCharacterButton.onClick.AddListener(OnRemoveCharacter);
    }

    void Start()
    {
        OnLoad();
    }

    public void OnCreateWarrior()
    {
        uiCharacterSlotList.AddWarrior();
    }

    public void OnCreateTanker()
    {
        uiCharacterSlotList.AddTanker();
    }

    public void OnCreateThief()
    {
        uiCharacterSlotList.AddThief();
    }

    public void OnChangeSorting(int index)
    {
        uiCharacterSlotList.Sorting = (UiCharacterSlotList.SortingOptions)index;
    }

    public void OnChangeFiltering(int index)
    {
        uiCharacterSlotList.Filtering = (UiCharacterSlotList.FilteringOptions)index;
    }

    public void OnRemoveCharacter()
    {
        uiCharacterSlotList.RemoveCharacter();
    }

    public void OnClickCenter()
    {
        infoWindow.Open(characterInfo.currentSaveCharacterData);
    }

    //public void OnSaveCharacters()
    //{

    //}
    public void OnSave()
    {
        SaveLoadManager.Data.CharacterList = uiCharacterSlotList.GetSaveCharacterDataList();
        SaveLoadManager.Save();
    }

    public void OnLoad()
    {
        SaveLoadManager.Load();
        uiCharacterSlotList.SetSaveCharacterDataList(SaveLoadManager.Data.CharacterList);
        uiCharacterSlotList.UpdateUi();
    }
}
