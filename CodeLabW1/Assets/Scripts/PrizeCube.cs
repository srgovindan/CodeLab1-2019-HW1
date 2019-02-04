using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeCube : MonoBehaviour
{
    
    // 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // for quicker/Game Jam-y solution, use other.name.Contains("Player");
        {
           other.gameObject.GetComponent<PlayerControl>().PlayerScore++;
           Destroy(gameObject);
        }
    }

    public void CreatePrizeCube()
    {
        // create a prize cube random spawn
    }
}
