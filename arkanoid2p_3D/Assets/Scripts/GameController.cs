using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;

public class GameController : MonoBehaviour
{
    [HeaderAttribute("Set In Inspector")]
    public Transform SpawnLeft;
    public Transform SpawnRight;
    public Transform BoundsLeft;
    public Transform BoundsRight;
    public GameObject BrickContainer;
    
    [HeaderAttribute("Fake UI")]
    public TextMesh LivesUI;
    public TextMesh GameUI;
    
    // private vars
    private GameObject ballPrefab;
    private GameObject brickPrefab;

    private void Awake()
    {
        _InitializeServices();
        ballPrefab = Resources.Load<GameObject>("Prefabs/Ball");
        brickPrefab = Resources.Load<GameObject>("Prefabs/Brick");
    }

    void Start()
    {
        CreatePlayers();
        CreateBall(SpawnLeft);
        CreateBall(SpawnRight);
        _CreateBricks();
        RefreshLivesUI();
    }

    private void _InitializeServices()
    {
        Services.Game = this;
        Services.Lives = 3;
        Services.SpawnLeft = SpawnLeft;
        Services.SpawnRight = SpawnRight;
        Services.BoundsLeft = BoundsLeft;
        Services.BoundsRight = BoundsRight;
        Services.BrickContainer = BrickContainer;
    }

    public void CreatePlayers()
    {
        var player1 = Resources.Load<GameObject>("Prefabs/P1");
        Services.P1 = Instantiate(player1).GetComponent<PlayerController>();
        
        var player2 = Resources.Load<GameObject>("Prefabs/P2");
        Services.P2 = Instantiate(player2).GetComponent<PlayerController>();
    }

    public void OutOfBounds(GameObject toDestroy)
    {
        Destroy(toDestroy);
        if (Services.Lives > 0)
        {
            Services.Lives -= 1;
        }
        else if (Services.Lives == 0)
        {
            GameOver();
        }
        RefreshLivesUI();
    }

    public void GameOver()
    {
        Destroy(BrickContainer);
        GameUI.text = "GAME OVER! Press 'R' to restart.";
    }

    public void GameWon()
    {
        Services.Lives = -1;
        GameUI.text = "YOU BOTH WIN! CELEBRATE WITH A BUBBLE TEA.";
    }

    public void CreateBall(Transform spawnTransform)
    {
        Debug.Log("Creating ball at " + spawnTransform);   
        var ball = Instantiate(ballPrefab);
        ball.transform.position = spawnTransform.position;
    }

    public void RefreshLivesUI()
    {
        LivesUI.text = "Lives remaining: " + Services.Lives;
    }
    
    private void _CreateBricks()
    {
        Debug.Log("Creating bricks");
        int numPatterns = 3;
        switch (Random.Range(0,numPatterns))
        {
            // debug single brick
            case 0:
                var brick0 = Instantiate(brickPrefab);   
                brick0.transform.position = new Vector3(0,0,0);
                brick0.transform.parent = BrickContainer.transform;
                break;
            
            // grid
            case 1:
                for (int i = -10; i < 10; i  += 3)
                {
                    for (int j = -8; j < 12; j += 4)
                    {
                        // * add code to randomly spawn special bricks
                        var brick1 = Instantiate(brickPrefab);
                        brick1.transform.position = new Vector3((float)i,(float)j,0f);
                        brick1.transform.parent = BrickContainer.transform;
                    } 
                }
                break;
            
            // columns
            case 2:
                for (int i = -15; i < 15; i  += 4)
                {
                    for (int j = -8; j < 10; j += 2)
                    {
                        // * add code to randomly spawn special bricks
                        var brick2 = Instantiate(brickPrefab);
                        brick2.transform.position = new Vector3((float)i,(float)j,0f);
                        brick2.transform.parent = BrickContainer.transform;
                    } 
                }
                break;
            
            default:
                Debug.Log("ERROR: Could not create Bricks.");
                break;                
        } 
    }
}
