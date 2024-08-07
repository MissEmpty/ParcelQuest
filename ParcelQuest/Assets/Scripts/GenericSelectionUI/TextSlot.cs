using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSlot : MonoBehaviour, ISelectableItem
{
    [SerializeField] Text text;

    Color originalColor;
    public void init()
    {
        originalColor = text.color;
    }

    public void OnSelectionChanged(bool selected)
    {
        text.color = (selected) ? GlobalSettings.i.HighlightedColor : originalColor;
    }
}
