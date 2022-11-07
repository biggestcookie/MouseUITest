using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
  Dictionary<int, SelectableItem> selectedItems = new Dictionary<int, SelectableItem>();

  [SerializeField] TextMeshPro textMesh;

  void Awake()
  {
    SelectableItem.ItemSelectEvent += OnSelectedItem; // Call OnSelectedItem whenever ItemSelectEvent is triggered
    SelectableItem.ItemDeselectEvent += OnDeselectedItem;
  }

  // Called on ItemSelectEvent.Invoke()
  void OnSelectedItem(SelectableItem selectedItem)
  {
    selectedItems.Add(selectedItem.GetInstanceID(), selectedItem);
    WriteMessage(selectedItem);
  }

  void OnDeselectedItem(SelectableItem selectedItem)
  {
    selectedItems.Remove(selectedItem.GetInstanceID());
    Debug.Log("Deselected item: " + selectedItem.itemType);
    Debug.Log("There are " + selectedItems.Count + " selected items now.");
    WriteMessage(selectedItem);
  }

  void WriteMessage(SelectableItem selectedItem)
  {
    string message = "Last clicked item: " + selectedItem.itemType + "\nThere are " + selectedItems.Count + " selected items now.";
    textMesh.text = message;
    Debug.Log(message);
  }
}
