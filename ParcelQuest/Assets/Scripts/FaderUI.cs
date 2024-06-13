using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaderUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasgroup;

    private bool _fadein;
    private bool _fadeout;

    public float TimeToFade;
    public float TimeToChangeScene;
    [SerializeField] public string sceneName;

   

    // Update is called once per frame
    void Update()
    {
        if(_fadein)
        {
            if(canvasgroup.alpha < 1)
            {
                canvasgroup.alpha += TimeToFade * Time.deltaTime;
                if(canvasgroup.alpha >= 1 )
                {
                    _fadein = false;
                }
            }
        }
        if(_fadeout)
        {
            if (canvasgroup.alpha >= 0) 
            {
                canvasgroup.alpha -= TimeToFade * Time.deltaTime;
                if (canvasgroup.alpha == 0 )
                {
                    _fadeout = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        _fadein = true;
    }

    public void FadeOut()
    {
        _fadeout = true;
    }

    public void ChangeScene ()
    {
        StartCoroutine(FadeOnSceneChange());
    }

    IEnumerator FadeOnSceneChange()
    {
        FadeOut();
        yield return new WaitForSeconds(TimeToChangeScene);
        SceneManager.LoadScene(sceneName);
    }
}
