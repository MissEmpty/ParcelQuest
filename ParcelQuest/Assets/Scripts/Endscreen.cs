using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endscreen : MonoBehaviour
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
           // audioManager.PlaySFX(audioManager.text);
            StartCoroutine(_PlayGame());
        }

    }
    private IEnumerator _PlayGame()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadSceneAsync("Credits");
    }
}
