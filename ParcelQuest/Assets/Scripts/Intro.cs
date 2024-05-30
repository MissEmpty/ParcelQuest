using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            audioManager.PlaySFX(audioManager.text);
            StartCoroutine(_PlayGame());
        }

        

    }
    private IEnumerator _PlayGame()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadSceneAsync("Gameplay");
    }
}
