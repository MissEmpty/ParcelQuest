using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 
    public void StartGame () 
    {

        StartCoroutine(_PlayGame());

    }

    private IEnumerator _PlayGame()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Intro");
    }
    public void Options ()
    {

    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void PlaySound()
    {
        //AudioManager.i.PlaySfx(AudioId.UISelect);
    }
}
