using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectableItem
{
    void init();
    void OnSelectionChanged(bool selected);
}
