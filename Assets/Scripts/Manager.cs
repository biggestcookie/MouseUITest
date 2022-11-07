using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
  Dictionary<int, SelectableItem> selectedItems = new Dictionary<int, SelectableItem>();

  void Awake()
  {
    // Call OnSelectedItem whenever ItemSelectEvent is triggered
    SelectableItem.ItemSelectEvent += OnSelectedItem;
    SelectableItem.ItemDeselectEvent += OnDeselectedItem;
  }

  void OnSelectedItem(SelectableItem selectedItem)
  {
    selectedItems.Add(selectedItem.GetInstanceID(), selectedItem);

    Debug.Log("Selected item: " + selectedItem.name);
    Debug.Log("There are " + selectedItems.Count + " selected items now.");
  }

  void OnDeselectedItem(SelectableItem selectableItem)
  {
    selectedItems.Remove(selectableItem.GetInstanceID());
    Debug.Log("Deselected item: " + selectableItem.name);
    Debug.Log("There are " + selectedItems.Count + " selected items now.");
  }
}
