using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D body;
    BattleManager battleSystem;

    public float movementRange = 2.5f;
    private bool canChangeDirection = true;


    // Awake starts on object initalisation
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Fixed Update is called once per fixed framerate frame
    void FixedUpdate()
    {
        Move();
    }

    //Enemy movement - Paused if in battle
    void Move()
    {
        if(canChangeDirection)
        {       
            Vector2 direction = new Vector2(Random.Range(-movementRange, movementRange), Random.Range(-movementRange, movementRange));
            body.velocity = direction;
            StartCoroutine(StopAndWait());
        }
    }

    IEnumerator StopAndWait()
    {
        canChangeDirection = false;
        yield return new WaitForSeconds(0.5f);
        body.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(1f);
        canChangeDirection = true;
    }
}
