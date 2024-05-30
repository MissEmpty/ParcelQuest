using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsState : State<GameController>
{
    [SerializeField] OptionsUI optionsUI;

   public static OptionsState i {  get; private set; }


    private void Awake()
    {
        i = this;
    }
    GameController gameController;
    public override void Enter(GameController owner)
    {
       
       gameController = owner;
      
       optionsUI.gameObject.SetActive(true);
       optionsUI.OnBack += OnBack;
    }
    public override void Execute()
    {
        optionsUI.HandleUpdate();
    }

    public override void Exit()
    {
        optionsUI.gameObject.SetActive(false);
        optionsUI.OnBack -= OnBack;
    }
    void OnItemSelected()
    {

    }
    void OnBack()
    {
        gameController.StateMachine.Pop();
    }
}
