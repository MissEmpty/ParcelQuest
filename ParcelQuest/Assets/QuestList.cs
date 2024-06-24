using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestList : MonoBehaviour, ISavable
{
   public List<Quest> quests = new List<Quest>();

    QuestUI questUI;

    public event Action OnUpdated;

    public void AddQuest(Quest quest)
    {
        if (!quests.Contains(quest))
            quests.Add(quest);

        OnUpdated?.Invoke();
    }

    public List<Quest> Quests
    {
        get { return quests; }
        set
        {
            quests = value;
            OnUpdated?.Invoke();
        }
    }
    public bool IsStarted(string questName)
    {
        var questStatus = quests.FirstOrDefault(q => q.Base.Name == questName)?.Status;
        return questStatus == QuestStatus.Started || questStatus == QuestStatus.Completed;
    }

    public bool IsCompleted(string questName)
    {
        var questStatus = quests.FirstOrDefault(q => q.Base.Name == questName)?.Status;
        return questStatus == QuestStatus.Completed;
    }

    public static QuestList GetQuestList()
    {
        return FindObjectOfType<PlayerController>().GetComponent<QuestList>();
    }

    public object CaptureState()
    {
        return quests.Select(q => q.GetSaveData()).ToList();
    }

    public void RestoreState(object state)
    {
        var saveData = state as List<QuestSaveData>;
        if (saveData != null)
        {
            quests = saveData.Select(q => new Quest(q)).ToList();
            OnUpdated?.Invoke();
        }
    }
    public void QuestsUpdated()
    {
        OnUpdated?.Invoke();
    }

    public void RemoveQuest(Quest quest)
    {
  
        foreach (Quest questi in quests)
        {
          
        }

        if (quests.Contains(quest))
        { quests.Remove(quest);
                  
        }

        OnUpdated?.Invoke();
    }

}


