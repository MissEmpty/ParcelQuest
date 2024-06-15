using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuState : State<GameController>
{
    [SerializeField] MenuController menuController;
    [SerializeField] QuestUI questUI;
   

    public static GameMenuState i { get; private set; }
    private void Awake()
    {
        questUI.Init();
        i = this;
        
    }

    GameController gc;
    public override void Enter(GameController owner)
    {
       
        AudioManager.i.PlaySfx(AudioId.PauseGame);
        gc = owner;
        menuController.gameObject.SetActive(true);
        menuController.OnSelected += onMenuItemSelected;
        menuController.OnBack += OnBack;
    }

    public override void Execute()
    {
        menuController.HandleUpdate();

        
    }

    public override void Exit()
    {
        AudioManager.i.PlaySfx(AudioId.UnpauseGame);
        menuController.gameObject.SetActive(false);
        menuController.OnSelected -= onMenuItemSelected;
        menuController.OnBack -= OnBack;
    }

    void onMenuItemSelected(int selection)
    {
        if (selection == 0) //Journal
        {
            AudioManager.i.PlaySfx(AudioId.UISelect);
            questUI.SetQuestData();
            gc.StateMachine.Push(JournalState.i);
        }

        if (selection == 1) //Options
        {
            AudioManager.i.PlaySfx(AudioId.UISelect);
            gc.StateMachine.Push(OptionsState.i);
        }

       else if (selection == 2) //MainMenu
        {
            AudioManager.i.PlaySfx(AudioId.UISelect);
            SceneManager.LoadScene("StartScreen");
        }

        else if (selection == 3) //Quit
        {
            AudioManager.i.PlaySfx(AudioId.UISelect);
            Application.Quit();
        }


    }

    void OnBack()
    {
        gc.StateMachine.Pop();
    }
}
