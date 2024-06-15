using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalState : State<GameController>
{
    [SerializeField] JournalUI journalUI;

    public static JournalState i { get; private set; }


    private void Awake()
    {
        i = this;
    }
    GameController gameController;
    public override void Enter(GameController owner)
    {

        gameController = owner;

        journalUI.gameObject.SetActive(true);
        journalUI.OnBack += OnBack;
    }
    public override void Execute()
    {
        journalUI.HandleUpdate();
    }

    public override void Exit()
    {
        journalUI.gameObject.SetActive(false);
        journalUI.OnBack -= OnBack;
    }
    void OnItemSelected()
    {

    }
    void OnBack()
    {
        gameController.StateMachine.Pop();
    }
}

