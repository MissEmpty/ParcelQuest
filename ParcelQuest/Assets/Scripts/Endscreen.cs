using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endscreen : MonoBehaviour
{
   

    private void Awake()
    {
       
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
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadSceneAsync("Credits");
    }
}
