using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSlotUI : MonoBehaviour
{
    [SerializeField] Text descriptionText;

    Quest _questSlot; 

    public Text DescriptionText => descriptionText;

    public void Init(Quest slot)
    {
        _questSlot = slot;
        UpdateData();
    }

    void UpdateData()
    {
       
        descriptionText.text = _questSlot.Base.Description;
    }
}
