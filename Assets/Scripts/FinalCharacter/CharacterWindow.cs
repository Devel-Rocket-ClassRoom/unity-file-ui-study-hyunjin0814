using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterWindow : MonoBehaviour
{
    public UiCharacterSlotList uiCharacterSlotList;

    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public Button createWarriorButton;
    public Button createTankerButton;
    public Button createThiefButton;
    public Button RemoveCharacterButton;

    private void Awake()
    {
        createWarriorButton.onClick.AddListener(OnCreateWarrior);
        createTankerButton.onClick.AddListener(OnCreateTanker);
        createThiefButton.onClick.AddListener(OnCreateThief);
        RemoveCharacterButton.onClick.AddListener(OnRemoveCharacter);
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
}
