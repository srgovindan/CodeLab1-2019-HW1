using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int MaxNumberOfCubes;
    public float ScreenSize;


    private void Awake()
    {
        MaxNumberOfCubes = 3;
    }


    private void Start()
    {
        InvokeRepeating("SpawnCube",3,1.5f);
    }


    public void SpawnCube()
    {   
            GameObject newPrize = Instantiate(Resources.Load<GameObject>("Prefabs/PrizeCube"));
            float randomX = Random.Range(-ScreenSize,ScreenSize);
            float randomY = Random.Range(-ScreenSize,ScreenSize);
            Vector2 randomPos = new Vector2(randomX,randomY);
            newPrize.transform.position = randomPos;
    }
}
