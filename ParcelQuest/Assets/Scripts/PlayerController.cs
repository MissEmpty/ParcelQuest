using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // Creating a var for rigitbody2d
    public Rigidbody2D rd;
    // creating a var for animetor
    Animator anime;

    // for player animetion 
    bool PlayerMoving;
    Vector2 LastMove;

    public float speed = 5.0f;

    void Start()
    {
        // storing Rigitdhody2D in rd
        rd = GetComponent<Rigidbody2D>();

        // storing Animetor in anime
        anime = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Condition to tigger Player moving or not & seting lastmove Values
        if (x == -1 || x == 1 || y == -1 || y == 1)
        {
            PlayerMoving = true;
            LastMove = new Vector2(x, y);
            // Debug.Log("ok");
        }
        else
        {
            PlayerMoving = false;
        }

        // creating a Vector2 for position
        Vector2 move = new Vector2(x, y);

        //using rigidbody2d position to move and using + to add up values not just set values
        rd.position += move * speed * Time.deltaTime;


        // set MoveX & MoveY value as RD x & y value
        anime.SetFloat("MoveX", x);
        anime.SetFloat("MoveY", y);
        // seting Playermoving to bool PlayerMoving true or false
        anime.SetBool("PlayerMoving", PlayerMoving);
        //setting LastMove to animetor
        anime.SetFloat("LastMoveX", LastMove.x);
        anime.SetFloat("LastMoveY", LastMove.y);

    }
}
