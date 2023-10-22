using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]    
    public float movementSpeed = 10f;

    [Header("Gameplay Information")]
    public bool isLeader = false;

    [Header("Other")]
    public Rigidbody2D body;
    public BattleSystem battleController;
    private Vector2 moveDirection;
    private Animator anim; //TODO figure out how to use this

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //Update is called once per frame
    void Update()
    {
        ProcessInputs(); //Input processing is done separately from actual execution to make movement speed consistent across framerates
    }

    // FixedUpdate is called once per fixed framerate frame
    void FixedUpdate()
    {
        Move(); //Moves character based on input
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized; //"normalized" because otherwise moving diagonally ends up faster

        //Set booleans for direction facing if moving (hold last if not moving)

        if(checkMoving(moveX, moveY)){
            setDirection(moveX, moveY);
        }
    }

    void Move()
    {  
        if(!battleController.inBattle)
        {
        body.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed); //Applies speed to normalized vector
        }        
    }

    bool checkMoving(float moveX, float moveY){       
        if(moveX==0&&moveY==0)
            return false;
        else
            return true;
    }

    void setDirection(float x, float y){
        //Horizontal directions
        if(x<0)
            anim.SetInteger("leftOrRight", -1);     
        else if(x>0)
            anim.SetInteger("leftOrRight", 1);
        else
            anim.SetInteger("leftOrRight", 0);

        //Vertical directions
        if(y<0)
            anim.SetInteger("upOrDown", -1);     
        else if(y>0)
            anim.SetInteger("upOrDown", 1);
        else
            anim.SetInteger("upOrDown", 0);
    }

}
