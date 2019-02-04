using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Services
{
    public static GameController Game;
    public static PlayerController P1;
    public static PlayerController P2;
    public static GameObject[] Balls;

    public static Transform SpawnLeft;
    public static Transform SpawnRight;
    public static Transform BoundsLeft;
    public static Transform BoundsRight;

    public static GameObject BrickContainer;
    
    public static int Lives;
}
