using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class Quest
{
    public QuestBase Base { get; private set; }
    public QuestStatus Status { get; private set; }

    NPCController npcController;


   public bool canBeCompleted;

    public Quest(QuestBase _base)
    {
        Base = _base;
    }

    public Quest(QuestSaveData saveData)
    {
        Base = QuestDB.GetObjectByName(saveData.name);
        Status = saveData.status;
    }

    public QuestSaveData GetSaveData()
    {
        var saveData = new QuestSaveData()
        {
            name = Base.name,
            status = Status
        };
        return saveData;
    }

    public IEnumerator StartQuest()
    {
        Status = QuestStatus.Started;

        yield return DialogManager.Instance.ShowDialog(Base.StartDialogue);
        
        var questList = QuestList.GetQuestList();
        questList.AddQuest(this);

      
    }

    public IEnumerator CompleteQuest(Transform player)
    {
        var questList = QuestList.GetQuestList();

        questList.AddQuest(this);

        Status = QuestStatus.Completed;


        Debug.Log("CompleteQuestAngekommen");
      

        yield return DialogManager.Instance.ShowDialog(Base.CompletedDialogue);
       
        var inventory = Inventory.GetInventory();
        if (Base.RequiredItem != null)
        {
            inventory.RemoveItem(Base.RequiredItem);
        }

        if (Base.RewardItem != null)
        {
            inventory.AddItem(Base.RewardItem);

            AudioManager.i.PlaySfx(AudioId.ItemObtained, pauseMusic: true);
            yield return DialogManager.Instance.ShowDialogText($"Cylia received {Base.RewardItem.Name}.");
            
        }


      
        questList.RemoveQuest(this);

    }

    public bool CanBeCompleted()
    {
      
        var inventory = Inventory.GetInventory();
       
        if (Base.RequiredItem != null)
        {
            if (!inventory.HasItem(Base.RequiredItem))
            {
                canBeCompleted = false;
                return false;
                
            }

            else
            {
                return true;
            }
                 
        }
        return false;
       
    }

    public override bool Equals(object other)
    {
        return (other as Quest).Base.name == Base.name;
    }


}

[System.Serializable]
public class QuestSaveData
{
    public string name;
    public QuestStatus status;
}

public enum QuestStatus { None, Started, Completed }




