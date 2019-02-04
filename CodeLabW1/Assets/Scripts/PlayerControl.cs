using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float xMoveForce = 1f;
    public float yMoveForce = 1f;

    // input keycodes
    public KeyCode InputUp;
    public KeyCode InputDown;
    public KeyCode InputLeft;
    public KeyCode InputRight;

    public int PlayerScore;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerScore = 0;
    }

    void Update()
    {
        Move();
    }

    // moves player using forces
    public void Move()
    {
        // create new vector to hold forces
        Vector2 moveForce = new Vector2();
             // move up
            if (Input.GetKey(InputUp))
            {
                moveForce.y += yMoveForce;
            }
            // move left
            if (Input.GetKey(InputLeft))
            {
                moveForce.x -= xMoveForce;
            }
            // move down
            if (Input.GetKey(InputDown))
            {
                moveForce.y -= yMoveForce;
            }   
            // move right
            if (Input.GetKey(InputRight))
            {
                moveForce.x += xMoveForce;
            }
        // add forces 
        rb.AddForce(moveForce);
    }
    
    
    
    
}


