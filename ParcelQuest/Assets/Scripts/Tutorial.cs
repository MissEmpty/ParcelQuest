using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            
            tutorial.gameObject.SetActive(false);
            audioManager.PlaySFX(audioManager.text);
        }
    }
}
