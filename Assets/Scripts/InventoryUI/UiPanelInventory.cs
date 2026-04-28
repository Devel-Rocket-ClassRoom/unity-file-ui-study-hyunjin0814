using TMPro;
using UnityEngine;

public class UiPanelInventory : MonoBehaviour
{
    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public UiInvenSlotList uiInvenSlotList;
    public CharacterInfo characterInfo;

    private string[] sortId = 
    {         
        "CreationTimeAsscding",
        "CreationTimeDeccending",
        "NameAccending",
        "NameDeccending",
        "CostAccending",
        "CostDeccending",
        "ValueAccending",
        "ValudDeccending",
    };
    private string[] filterId =
    {
        "None",
        "Weapon",
        "Equip",
        "Consumable",
        "NonConsumable"
    };

    private void OnEnable()
    {
        OnLoad();
    }


    public void OnChangeSorting(int index)
    {
        uiInvenSlotList.Sorting = (UiInvenSlotList.SortingOptions)index;
    }

    public void OnChangeFiltering(int index)
    {
        uiInvenSlotList.Filtering = (UiInvenSlotList.FilteringOptions)index;
    }

    public void OnSave()
    {
        SaveLoadManager.Data.ItemList = uiInvenSlotList.GetSaveItemDataList();
        SaveLoadManager.Data.filterIndex = (UiInvenSlotList.FilteringOptions)filtering.value;
        SaveLoadManager.Data.sortIndex = (UiInvenSlotList.SortingOptions)sorting.value;
        SaveLoadManager.Save();
    }

    public void OnLoad()
    {
        SaveLoadManager.Load();

        filtering.value = (int)SaveLoadManager.Data.filterIndex;
        sorting.value = (int)SaveLoadManager.Data.sortIndex;

        //OnChangeFiltering(filtering.value);
        //OnChangeSorting(sorting.value);
        uiInvenSlotList.SetSaveItemDataList(SaveLoadManager.Data.ItemList);
    }

    public void OnCreateItem()
    {
        uiInvenSlotList.AddRandomItem();
    }

    public void OnRemoveItem()
    {
        uiInvenSlotList.RemoveItem();
    }

    public void OnEquipItem()
    {
        SaveItemData item = uiInvenSlotList.EquipItem();

        if (item == null)
            return;

        // 이미 장착된 장비가 있을 경우
        if (characterInfo.currentSaveCharacterData.CharacterData.EquippedItems.ContainsKey(item.ItemData.Type))
        {
            // 장착된 장비를 인벤토리에 추가
            uiInvenSlotList.AddItem(characterInfo.currentSaveCharacterData.CharacterData.EquippedItems[item.ItemData.Type]);
            characterInfo.currentSaveCharacterData.CharacterData.EquippedItems.Remove(item.ItemData.Type);
        }
        
        // 장비를 장착
        characterInfo.currentSaveCharacterData.CharacterData.EquippedItems.Add(item.ItemData.Type, item);
        characterInfo.UpdateCharacterData();
    }

    public void OnUnEquipItem()
    {
        // 장착중인 장비 모두 인벤토리로 해제
        foreach (var value in characterInfo.currentSaveCharacterData.CharacterData.EquippedItems.Values)
        {
            uiInvenSlotList.AddItem(value);
        }

        // 장비 딕셔너리 초기화
        characterInfo.currentSaveCharacterData.CharacterData.EquippedItems.Clear();
        characterInfo.UpdateCharacterData();
    }
}
