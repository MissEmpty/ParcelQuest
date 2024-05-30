using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuState : State<GameController>
{
    [SerializeField] MenuController menuController;
  //  AudioManager audioManager;

    public static GameMenuState i { get; private set; }
    private void Awake()
    {
        i = this;
      //  audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    GameController gc;
    public override void Enter(GameController owner)
    {
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
        menuController.gameObject.SetActive(false);
        menuController.OnSelected -= onMenuItemSelected;
        menuController.OnBack -= OnBack;
    }

    void onMenuItemSelected(int selection)
    {
        if(selection == 0) //Options
        {
           // audioManager.PlaySFX(audioManager.text);
            gc.StateMachine.Push(OptionsState.i);
        }

       else if (selection == 1) //MainMenu
        {
           // audioManager.PlaySFX(audioManager.text);
            SceneManager.LoadScene("StartScreen");
        }

        else if (selection == 2) //Quit
        {
          //  audioManager.PlaySFX(audioManager.text);
            Application.Quit();
        }


    }

    void OnBack()
    {
        gc.StateMachine.Pop();
    }
}
