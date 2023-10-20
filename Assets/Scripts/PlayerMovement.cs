using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]    
    public float speed = 10f;

    [Header("Other")]
    public Rigidbody2D body;
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
            //Horizontal directions
            if(moveX<0)
                anim.SetInteger("leftOrRight", -1);     
            else if(moveX>0)
                anim.SetInteger("leftOrRight", 1);
            else
                anim.SetInteger("leftOrRight", 0);

            //Vertical directions
            if(moveY<0)
                anim.SetInteger("upOrDown", -1);     
            else if(moveY>0)
                anim.SetInteger("upOrDown", 1);
            else
                anim.SetInteger("upOrDown", 0);
        }
    }

    void Move()
    {
        body.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed); //Applies speed to normalized vector
        
    }

    bool checkMoving(float moveX, float moveY){
        bool isMoving;        
        if(moveX==0&&moveY==0)
            return false;
        else
            return true;
    }

}
