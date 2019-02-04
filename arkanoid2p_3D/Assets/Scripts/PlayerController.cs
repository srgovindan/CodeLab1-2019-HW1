using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    // key inputs
    public KeyCode InputUp;
    public KeyCode InputDown;

    private float PaddleSpeed = 30f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    

    void MovePaddle()
    {
        Vector2 newVelocity = new Vector2();
        if (Input.GetKey(InputUp))
        {
            // add up velocity
            newVelocity.y += PaddleSpeed;
        }
        else if (Input.GetKey(InputDown))
        {
            // add down velocity
            newVelocity.y -= PaddleSpeed;
        }
        // output velocity
        rb.velocity = newVelocity;
    }
}
