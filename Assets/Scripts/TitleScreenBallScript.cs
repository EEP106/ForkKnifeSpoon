using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenBallScript : MonoBehaviour
{
    [SerializeField] int ballLimit = 6;

    private void Awake()
    {
        int numberOfBalls = FindObjectsOfType<TitleScreenBallScript>().Length;

        if (SceneManager.GetActiveScene().buildIndex > 3)
        {
            Destroy(gameObject);
        }

        if (numberOfBalls > ballLimit)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    [SerializeField] Rigidbody2D rigidBody2D;

    float lastXPos;
    float lastYPos;

    int ballDirectionSeed;
    Vector2 startingVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        BallVelocityReset();
        
        transform.position = new Vector2(Random.Range(-8, 8), Random.Range(-6, 6));
        LastPositionUpdate();
    }

    // Constantly checks if the Ball is stuck on a wall
    void Update()
    {
        LastPositionUpdate();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (lastXPos == gameObject.transform.position.x)
        {
            BallVelocityReset();
        }
        if (lastYPos == gameObject.transform.position.y)
        {
            BallVelocityReset();
        }
    }

    //Randomly choses a diagonal vector for the ball
    void BallVelocityReset()
    {
        ballDirectionSeed = Random.Range(1, 4);

        switch (ballDirectionSeed)
        {
            case 1:
                startingVelocity = new Vector2(1, 1).normalized * 5;

                break;

            case 2:
                startingVelocity = new Vector2(-1, 1).normalized * 5;

                break;

            case 3:
                startingVelocity = new Vector2(1, -1).normalized * 5;

                break;

            case 4:
                startingVelocity = new Vector2(-1, -1).normalized * 5;

                break;
        }

        rigidBody2D.velocity = startingVelocity;
    }

    //logs the last position of the ball
    void LastPositionUpdate()
    {
        lastXPos = gameObject.transform.position.x;
        lastYPos = gameObject.transform.position.y;
    }
}
