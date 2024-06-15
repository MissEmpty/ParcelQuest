using GDE.GenericSelectionUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JournalUI : SelectionUI<TextSlot>
{
    private void Start()
    {
        SetItems(GetComponentsInChildren<TextSlot>().ToList());
    }
}
