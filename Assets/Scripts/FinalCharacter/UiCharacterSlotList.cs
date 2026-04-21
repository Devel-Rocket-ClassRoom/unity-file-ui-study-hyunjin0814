using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiCharacterSlotList : MonoBehaviour
{
    public enum SortingOptions
    {
        NameAsce,
        NameDesc,
        AttackAsce,
        AttackDesc,
        DeffenseAsce,
        DeffenseDesc,
    }

    public enum FilteringOptions
    {
        None,
        Attacker,
        Deffenser,
    }

    public readonly System.Comparison<SaveCharacterData>[] comparisons =
    {
        (lhs, rhs) => lhs.CharacterData.Name.CompareTo(rhs.CharacterData.Name),
        (lhs, rhs) => rhs.CharacterData.Name.CompareTo(lhs.CharacterData.Name),
        (lhs, rhs) => lhs.CharacterData.Attack.CompareTo(rhs.CharacterData.Attack),
        (lhs, rhs) => rhs.CharacterData.Attack.CompareTo(lhs.CharacterData.Attack),
        (lhs, rhs) => lhs.CharacterData.Deffense.CompareTo(rhs.CharacterData.Deffense),
        (lhs, rhs) => rhs.CharacterData.Deffense.CompareTo(lhs.CharacterData.Deffense),
    };

    public readonly System.Func<SaveCharacterData, bool>[] filterings =
    {
        (x) => true,
        (x) => (x.CharacterData.Attack >= x.CharacterData.Deffense),
        (x) => (x.CharacterData.Deffense > x.CharacterData.Attack),
    };

    public UiCharacterSlot prefab;
    public ScrollRect scrollRect;

    private List<UiCharacterSlot> uiSlotList = new List<UiCharacterSlot>();
    private List<SaveCharacterData> saveCharacterDataList = new List<SaveCharacterData>();

    private SortingOptions sorting = SortingOptions.NameAsce;
    private FilteringOptions filtering = FilteringOptions.None;

    public SortingOptions Sorting
    {
        get => sorting;
        set
        {
            if (sorting != value)
            {
                sorting = value;
                UpdateSlots();
            }
        }
    }

    public FilteringOptions Filtering
    {
        get => filtering;
        set
        {
            if (filtering != value)
            {
                filtering = value;
                UpdateSlots();
            }
        }
    }

    private int selectedSlotIndex = -1;

    public UnityEvent onUpdateSlots;
    public UnityEvent<SaveCharacterData> onSelectSlot;

    private void UpdateSlots()
    {
        var list = saveCharacterDataList.Where(filterings[(int)filtering]).ToList();
        list.Sort(comparisons[(int)sorting]);

        if (uiSlotList.Count < list.Count)
        {
            for (int i = uiSlotList.Count; i < list.Count; i++)
            {
                var newSlot = Instantiate(prefab, scrollRect.content);
                newSlot.slotIndex = i;
                newSlot.SetEmpty();
                newSlot.gameObject.SetActive(false);

                newSlot.button.onClick.AddListener(() =>
                {
                    selectedSlotIndex = newSlot.slotIndex;
                    onSelectSlot.Invoke(newSlot.SaveCharacterData);
                });

                uiSlotList.Add(newSlot);
            }
        }

        // 현재 uiSlot들을 보여질 만큼만 갱신
        for (int i = 0; i < uiSlotList.Count; i++)
        {
            if (i < list.Count)
            {
                uiSlotList[i].gameObject.SetActive(true);
                uiSlotList[i].SetItem(list[i]);
            }
            else
            {
                uiSlotList[i].gameObject.SetActive(false);
                uiSlotList[i].SetEmpty();
            }
        }

        selectedSlotIndex = -1;
        onUpdateSlots?.Invoke();
    }

    public void AddWarrior()
    {
        SaveCharacterData warrior = new SaveCharacterData();
        warrior.CharacterData = DataTableManager.CharacterTable.Get("Character1");
        saveCharacterDataList.Add(warrior);

        UpdateSlots();
    }

    public void AddTanker()
    {
        SaveCharacterData tanker = new SaveCharacterData();
        tanker.CharacterData = DataTableManager.CharacterTable.Get("Character3");
        saveCharacterDataList.Add(tanker);

        UpdateSlots();
    }

    public void AddThief()
    {
        SaveCharacterData thief = new SaveCharacterData();
        thief.CharacterData = DataTableManager.CharacterTable.Get("Character2");
        saveCharacterDataList.Add(thief);

        UpdateSlots();
    }

    public void RemoveCharacter()
    {
        if (selectedSlotIndex == -1)
        {
            return;
        }

        saveCharacterDataList.Remove(uiSlotList[selectedSlotIndex].SaveCharacterData);
        UpdateSlots();
    }
}
