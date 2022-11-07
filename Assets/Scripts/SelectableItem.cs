using System;
using UnityEngine;

public enum ItemType
{
  Square,
  Circle,
  Triangle
}

[RequireComponent(typeof(SpriteRenderer))]
public class SelectableItem : MonoBehaviour
{
  // https://github.com/Habrador/Unity-Programming-Patterns#3-observer
  public static event Action<SelectableItem> ItemSelectEvent = delegate { };
  public static event Action<SelectableItem> ItemDeselectEvent = delegate { };

  public ItemType itemType;

  bool isSelected = false;
  SpriteRenderer spriteRenderer;
  Color originalColor;

  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    originalColor = spriteRenderer.color;
  }

  // Only triggered when GameObject has a Collider with Trigger enabled.
  // https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseDown.html
  void OnMouseDown()
  {
    isSelected = !isSelected;
    if (isSelected)
    {
      spriteRenderer.color = Color.blue;
      ItemSelectEvent.Invoke(this); // Trigger event listener in Manager script
    }
    else
    {
      spriteRenderer.color = originalColor;
      ItemDeselectEvent.Invoke(this);
    }
  }
}
