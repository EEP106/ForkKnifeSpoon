using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigidBody;

    [SerializeField] float paddleMaxHeight = 7;
    [SerializeField] float paddleheight = -3f;
    
    [SerializeField] float ballOffsetHeight = 0.5f;
    [SerializeField] float ballStartSpeed = 5f;
    [SerializeField] float ballDirectionSpanX = 10;

    bool ballReleased = false;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float paddlePosX = Mathf.Clamp(mousePos.x, -paddleMaxHeight, paddleMaxHeight);

        transform.position = new Vector2(paddlePosX, paddleheight);

        if (!ballReleased)
        {
            ReleaseBallOnClick();

            ballRigidBody.position = new Vector2(paddlePosX, paddleheight + ballOffsetHeight);
        }
        
    }

    //checks if the ball shoud be released
    void ReleaseBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballReleased = true;
            float ballStartingDirectionX = Random.Range(-ballDirectionSpanX, ballDirectionSpanX);
            ballRigidBody.velocity = new Vector2(ballStartingDirectionX, 1).normalized * ballStartSpeed;
        }
    }
        
    //Draws a cone to show inacuraccy 
    private void OnDrawGizmosSelected()
    {
        Vector2 ballPosition = new Vector2(transform.position.x, transform.position.y + ballOffsetHeight);

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(ballPosition, ballPosition + new Vector2(-ballDirectionSpanX, 1).normalized);
        Gizmos.DrawLine(ballPosition, ballPosition + new Vector2(ballDirectionSpanX, 1).normalized);
    }
}
