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
    public bool facingDown = true;
    public bool facingRight = false;

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

        //Set booleans for direction facing
        if(moveX<0)
            facingRight = false;        
        else if(moveX>0)
            facingRight = true;
        

        if(moveY<0)
            facingDown = true;        
        else if(moveY>0)
            facingDown = false;

    }

    void Move()
    {
        body.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed); //Applies speed to normalized vector
        
    }

}
