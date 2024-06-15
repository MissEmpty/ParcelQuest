using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { FreeRoam, Battle, Dialog, Menu, Cutscene, Paused, Options }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Camera worldCamera;
    [SerializeField] OptionsUI optionsUI;


    public static GameController gameController;

    GameState state;
    GameState prevState;

    public StateMachine<GameController> StateMachine {  get; private set; }

    public SceneDetails CurrentScene { get; private set; }
    public SceneDetails PrevScene { get; private set; }



    MenuController menuController;

    public static GameController Instance { get; private set; }
    private void Awake()
    {
        Instance = this;

        menuController = GetComponent<MenuController>();
    }

    private void Start()
    {
        StateMachine = new StateMachine<GameController>(this);
        StateMachine.ChangeState(FreeRoamState.i);

        DialogManager.Instance.OnShowDialog += () =>
        {
            StateMachine.Push(DialogueState.i);
        };

        DialogManager.Instance.OnCloseDialog += () =>
        {
            StateMachine.Pop();       
        };

    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
           StateMachine.Push(PauseState.i);
        }
        else
        {
            StateMachine.Pop();
        }
    }

   

    private void Update()
    {
        StateMachine.Execute();

        if (state == GameState.Cutscene)
        {
            playerController.Character.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        
    }

    public void SetCurrentScene(SceneDetails currScene)
    {
        PrevScene = CurrentScene;
        CurrentScene = currScene;
    }

  
    //private void OnGUI()
    //{
        //var style = new GUIStyle();
      //  style.fontSize = 24;

       // GUILayout.Label("STATE STACK", style);
       // foreach (var state in StateMachine.StateStack)
        //{
        //    GUILayout.Label(state.GetType().ToString(), style);
        //}
    //}

    public GameState State => state;
}


