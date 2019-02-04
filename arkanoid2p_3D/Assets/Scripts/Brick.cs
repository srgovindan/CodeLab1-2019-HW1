using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int brickHP;

    private void Start()
    {
        brickHP = 1;
    }
    
    void OnCollisionEnter(Collision other)
    {
        CollidedWithBrick(other);
    }

    void CollidedWithBrick(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            brickHP -= 1;
        }
        if (brickHP == 0)
        {
            Destroy(gameObject);
        }
    }
}
