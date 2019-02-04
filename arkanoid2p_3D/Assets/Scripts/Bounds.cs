using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public bool LeftSpawner;
    public bool RightSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Services.Game.OutOfBounds(other.gameObject);
            if (LeftSpawner){Services.Game.CreateBall(Services.SpawnLeft);}
            if (RightSpawner){Services.Game.CreateBall(Services.SpawnRight);}

        }
    }
}
