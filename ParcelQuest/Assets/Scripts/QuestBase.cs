using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Create a new quest")]
public class QuestBase : ScriptableObject
{
    [SerializeField] public string name;
    [SerializeField] string description;

    [SerializeField] Dialog startDialogue;
    [SerializeField] Dialog inProgressDialogue;
    [SerializeField] Dialog completedDialogue;


    [SerializeField] ItemBase requiredItem;
    [SerializeField] ItemBase rewardItem;

  


    public string Name => name;
    public string Description => description;

    public Dialog StartDialogue => startDialogue;
    public Dialog InProgressDialogue => inProgressDialogue;
    public Dialog CompletedDialogue => completedDialogue;


    public ItemBase RequiredItem => requiredItem;
    public ItemBase RewardItem => rewardItem;

    public override bool Equals(object other)
    {
        return (other as  QuestBase).name == name;
    }
}
