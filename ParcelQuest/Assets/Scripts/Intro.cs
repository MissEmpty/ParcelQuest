using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    Fader fader;

    private void Start()
    {
        fader = FindObjectOfType<Fader>();
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
           
            StartCoroutine(_PlayGame());
        }

       

    }
    private IEnumerator _PlayGame()
    {
       
        yield return new WaitForSeconds(0.2f);        
       SceneManager.LoadSceneAsync("Gameplay");
        
    }
}
