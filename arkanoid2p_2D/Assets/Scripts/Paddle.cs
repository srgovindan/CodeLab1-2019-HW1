using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public KeyCode UpKey;
    public KeyCode DownKey;

    public float PaddleSpeed = 10f;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        MovePaddle();
    }


    void MovePaddle()
    {
        Vector2 paddleVelocity = new Vector2();
        if (Input.GetKey(UpKey))
        {
            paddleVelocity += Vector2.up * PaddleSpeed;
        }
        else if (Input.GetKey(DownKey))
        {
            paddleVelocity += Vector2.down * PaddleSpeed;
        }
        rb.velocity = paddleVelocity;
    }
}
