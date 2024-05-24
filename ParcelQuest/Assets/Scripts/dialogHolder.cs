using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dMan;
    //Checks if Player entered dialogArea
    private bool playerEnter;
    // Start is called before the first frame update

    public string[] dialogLines;
    public int currLine;

    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //Handles Button Presses
        if (Input.GetKeyUp(KeyCode.E) && playerEnter && !dMan.dialogActive)
        {
            dMan.ShowBox(dialogLines[currLine]);
            ++currLine;
        }
        else if (Input.GetKeyUp(KeyCode.E) && playerEnter && dMan.dialogActive)
        {
            if (currLine >= dialogLines.Length)
            {
                dMan.HideBox();
                currLine = 0;
            }
            else
            {
                dMan.ShowBox(dialogLines[currLine]);
                ++currLine;
            }
        }
    }
    // OnTriggerEnter2D: Run fxn the instance player enters the collider
    // OnTriggerStay2D: Run fxn when the player is in the collider
    // OnTriggerExit2D: Run fxn when player leaves
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            dMan.HideBox();
            playerEnter = false;
            currLine = 0;
        }
    }
}
