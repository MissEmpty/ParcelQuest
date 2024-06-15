using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum QuestCategory { Quests}
public class QuestList : MonoBehaviour, ISavable
{

   public List<Quest> quests = new List<Quest>();

    QuestUI questUI;

    public event Action OnUpdated;

    bool isCompleted;

    public void AddQuest(Quest quest)
    {
       
 
        if (!quests.Contains(quest))
        {
            quests.Add(quest);
           
            OnUpdated?.Invoke();
        }

        
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

    private void Awake()
    {
    isCompleted = false;
    }

    public bool IsStarted(string questName)
    {
        var questStatus = quests.FirstOrDefault(q => q.Base.Name == questName)?.Status;
        return questStatus == QuestStatus.Started || questStatus == QuestStatus.Completed;
    }

    public bool IsCompleted(string questName)
    {
        var questStatus = quests.FirstOrDefault(q => q.Base.Name == questName)?.Status;
       
        return questStatus == QuestStatus.Completed && isCompleted == true;
        

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
        if (isCompleted == true)
        {
            quests.Remove(quest);

            OnUpdated?.Invoke();
        }
    }





}

