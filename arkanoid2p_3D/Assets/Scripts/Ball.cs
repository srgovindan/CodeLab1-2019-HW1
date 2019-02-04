using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 velocity;
    private float speed = 20f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _RandomInitVelocity();
    }

    void Update()
    {
        // weight velocity towards the player 
        var normalizedVelocity = rb.velocity.normalized;
        rb.velocity = normalizedVelocity * speed;
        CheckAllBricks();
    }

    private void _RandomInitVelocity()
    {    
        velocity.x = Random.Range(-1f,1f);
        velocity.y = Random.Range(-.5f,.5f);
        rb.velocity = velocity;
    }
    void CheckAllBricks()
    {
        if (Services.BrickContainer.transform.GetChild(0) == null)
        {
            Debug.Log("Game Won");
            Services.Game.GameWon();
        }
    }
}
