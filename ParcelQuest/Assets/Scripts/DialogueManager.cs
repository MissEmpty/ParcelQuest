using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;
    private float typingSpeed = 0.04f;

    private Coroutine displayLineCoroutine;

    public bool dialogActive;

    private PlayerController thePlayer;

    public bool canContinueToNextLine = false;

    private dialogHolder dialogHolder;

    private bool submitButtonPressedThisFrame = false;

    private NpcMovement npcMovement;

    

    

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        dialogHolder = FindObjectOfType<dialogHolder>();

       npcMovement = FindObjectOfType<NpcMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E)) 
        {
            
            submitButtonPressedThisFrame =true;
        }

        if(!dialogActive)
        {
            return;
        }

        if(canContinueToNextLine && submitButtonPressedThisFrame)
        {
            submitButtonPressedThisFrame = false;
            
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dText.text = "";

        canContinueToNextLine = false;

        foreach (char letter in line.ToCharArray())
        {
            if(submitButtonPressedThisFrame)
            {
                submitButtonPressedThisFrame = false;
                dText.text = line;
                break;
            }


            dText.text += letter;
            yield return  new WaitForSeconds(typingSpeed);
        }

        canContinueToNextLine=true;
    }

    public void ShowBox(string dialogue)
    {
        npcMovement.Interact();

        submitButtonPressedThisFrame = false;
        dialogActive = true;
        dBox.SetActive(true);
        if (displayLineCoroutine != null)
        {
            StopCoroutine(displayLineCoroutine);
        }
        displayLineCoroutine = StartCoroutine(DisplayLine(dialogue));
        thePlayer.canMove = false;
    }
    public void HideBox()
    {
        dialogActive = false;
        dBox.SetActive(false);
        thePlayer.canMove = true;
    }
}
