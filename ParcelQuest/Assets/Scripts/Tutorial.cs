using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
   

    void Start()
    {
       
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            AudioManager.i.PlaySfx(AudioId.UISelect);
            tutorial.gameObject.SetActive(false);
           
        }
    }
}
