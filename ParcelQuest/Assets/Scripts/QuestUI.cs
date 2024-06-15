using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    QuestList questList;
    List<Quest> quests;
    QuestSlotUI[] questSlots;

   

    public void Start()
    {
        quests = questList.quests;
    }
    public void Init()
    {
        questSlots = GetComponentsInChildren<QuestSlotUI>(true);
      
        questList = QuestList.GetQuestList();
        SetQuestData();

        questList.OnUpdated += SetQuestData;
    }


    public void SetQuestData()
    {
        quests = questList.quests;

        for (int i = 0; i < questSlots.Length; i++)
        {
           
            if (i < quests.Count)
            {
                questSlots[i].gameObject.SetActive(true);
                questSlots[i].Init(quests[i]);
            }
            else
            {
                questSlots[i].gameObject.SetActive(false);
            }
           
        }
    }
}
