using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;
    

    public event Action OnShowDialog;
    public event Action OnCloseDialog;

    public static DialogManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;

    }

    public bool IsShowing { get; private set; }

    public IEnumerator ShowDialogText(string text, bool waitForInput = true, bool autoClose = true)
    {
        OnShowDialog?.Invoke();

        IsShowing = true;
        dialogBox.SetActive(true);


        //AudioManager.i.PlaySfx(AudioId.UISelect);
        yield return TypeDialog(text);
        if (waitForInput)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }

        if (autoClose)
        {
           
            CloseDialog();
        }
    }

    public void CloseDialog()
    {
        dialogBox.SetActive(false);
        IsShowing = false;
        OnCloseDialog?.Invoke();
    }

    public IEnumerator ShowDialog(Dialog dialog) 
    {
        yield return new WaitForEndOfFrame();

        OnShowDialog?.Invoke();
        IsShowing = true;
        dialogBox.SetActive(true);

        foreach (var line in dialog.Lines)
        {
            //AudioManager.i.PlaySfx(AudioId.UISelect);
            yield return TypeDialog(line);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }
        
        dialogBox.SetActive(false);
        IsShowing = false;
        OnCloseDialog?.Invoke();
    }

    public void HandleUpdate()
    {

    }

    public IEnumerator TypeDialog(string line)
    {
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            AudioManager.i.PlaySfx(AudioId.Text);
            
            dialogText.text += letter;
            yield return new WaitForSeconds(1.2f / lettersPerSecond);
        }
    }
}
