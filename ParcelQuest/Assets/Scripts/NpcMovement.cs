using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class NpcMovement : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D myRigidbody;

    public bool isWalking;

    public Vector2 facing;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;

    public Collider2D walkZone;
    private bool hasWalkZone;

    public bool canMove;
    private DialogueManager theDm;

    public Animator anim;
    public Vector2 lastMove;



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theDm = FindObjectOfType<DialogueManager>();
        
       


        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!theDm.dialogActive)
        {
            canMove = true;
        }

        if(!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
           
            return;
        }

        if(isWalking == false)
        {
            facing.x = 0;
            facing.y = 0;
        }

        if(isWalking == true)
        {
            walkCounter -= Time.deltaTime;

            switch(WalkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    facing.y = 1;
                    facing.x = 0;
                    lastMove = new Vector2(0f, 1f);
                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    facing.y = 0;
                    facing.x = 1;
                    lastMove = new Vector2(1f, 0f);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    facing.y = -1;
                    facing.x = 0;
                    lastMove = new Vector2(0f, -1f);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    facing.y = 0;
                    facing.x = -1;
                    lastMove = new Vector2(-1f, 0f);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }

        else
        {
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;
            
            if(waitCounter < 0)
            {
                ChooseDirection() ;
            }
        }
        anim.SetFloat("MoveX", facing.x);
        anim.SetFloat("MoveY", facing.y);
        anim.SetBool("NpcMoving", isWalking);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    public void ChooseDirection ()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }

    public void Interact()
    {
        Vector3 directionToPlayer = playerTransform.position - transform.position;

        if (Mathf.Abs(directionToPlayer.x) > Mathf.Abs(directionToPlayer.y))
        {
            if(directionToPlayer.x > 0)
            {
                lastMove = new Vector2(1f, 0f);
            }
            else if (directionToPlayer.x < 0)
            {
                lastMove = new Vector2(-1f, 0f);
            }
           
        
        }
        else
        {
            if (directionToPlayer.y > 0)
            {
                lastMove = new Vector2(0f, 1f);
            }
            else if (directionToPlayer.y < 0)
            {
                lastMove = new Vector2(0f, -1f);
            }
        }
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }


}
