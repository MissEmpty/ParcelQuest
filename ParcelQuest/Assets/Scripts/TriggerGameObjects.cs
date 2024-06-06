using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameObjects : MonoBehaviour
{

    public GameObject G1;
    private PlayerController player;
    private bool _isStay;

    // Start is called before the first frame update
    void Start()
    {
       G1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStay)
        {
            if (G1.activeInHierarchy)
            {
                G1.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            _isStay = true;
        }
    }
}
