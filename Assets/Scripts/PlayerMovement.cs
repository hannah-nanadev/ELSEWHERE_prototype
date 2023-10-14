using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D body;
    private Vector2 moveDirection;
    private Animator anim;
    private bool facingDown = true;
    private bool facingRight = false;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    // FixedUpdate is called once per fixed framerate frame
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        float moveSpeed;

        //Compensation for move speed increase when moving diagonally
        if((moveX!=0)&&(moveY!=0)){
            moveSpeed = speed*0.75f;
        }
        else{
            moveSpeed = speed;
        }

        moveDirection = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    void Move()
    {
        body.velocity = moveDirection;
    }

}
