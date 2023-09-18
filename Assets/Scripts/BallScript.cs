using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class BallScript : MonoBehaviour
{
    [SerializeField] AudioClip paddleSound;
    [SerializeField] AudioClip blockSound;
    [SerializeField] AudioClip perimitorSound;
    [SerializeField] AudioClip barrierSound;

    [SerializeField] float comboHitPitch = 1.2f;
    [SerializeField] float PitchCap = 2f;
    [SerializeField] const float minBallAxisVelocity = 0.2f;

    AudioSource audioSource;
    Rigidbody2D rigidBody2D;
    PaddleScript paddleScript;

    int combo;
    float currentHitPitch;

    int velocityPositiveX;
    int velocityPositiveY;

    bool velocityChangeNeededX;
    bool velocityChangeNeededY;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        paddleScript = FindObjectOfType<PaddleScript>();
        paddleScript = paddleScript.GetComponent<PaddleScript>();
        
    }

    private void PlaySound(AudioClip Soundtoplay)
    {
        audioSource.clip = Soundtoplay;
        audioSource.Play();
    }

    void ComboIncrease()
    {
        combo++;
        currentHitPitch = combo * comboHitPitch + 1;
        if (currentHitPitch >= PitchCap)
        {
            currentHitPitch = 1;
            combo = 0;
        }
        audioSource.pitch = currentHitPitch;
    }

    void ComboBreak()
    {
        combo = 0;
        currentHitPitch = comboHitPitch;
        audioSource.pitch = 1;
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        

        if (other.gameObject.CompareTag("Block"))
        {
            PlaySound(blockSound);
            ComboIncrease();
        }
        else if (other.gameObject.CompareTag("Barrier"))
        {
            audioSource.pitch = 1;
            PlaySound(barrierSound);
        }
        else if (other.gameObject.CompareTag("Paddle"))
        {
            ComboBreak();
            PlaySound(paddleSound);
        }
        else if (other.gameObject.CompareTag("Perimitor"))
        {
            audioSource.pitch = 1;
            PlaySound(perimitorSound);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Vector2 ballVelocityVector2 = rigidBody2D.velocity;

        Debug.Log(ballVelocityVector2);

        if (ballVelocityVector2.x > 0)
        {
            velocityPositiveX = 1;
        }
        else
        {
            velocityPositiveX = -1;
        }

        if (ballVelocityVector2.y > 0)
        {
            velocityPositiveY = 1;
        }
        else
        {
            velocityPositiveY = -1;
        }

        switch (ballVelocityVector2.x)
        {
            case < minBallAxisVelocity:
                velocityChangeNeededX = false;

                break;

            case > -minBallAxisVelocity:
                velocityChangeNeededX = false;

                break;

            default:
                velocityChangeNeededX = true;

                break;
        }
        switch (ballVelocityVector2.y)
        {
            case < minBallAxisVelocity:
                velocityChangeNeededY = false;

                break;

            case > -minBallAxisVelocity:
                velocityChangeNeededY = false;

                break;

            default:
                velocityChangeNeededY = true;

                break;
        }
        /*
        if (velocityChangeNeededX == true)
            {
                switch (velocityPositiveX)
                {

                    case 1:
                        rigidBody2D.velocity = new Vector2(1,velocityPositiveY);

                        break;

                    case -1:
                        rigidBody2D.velocity = new Vector2(-1,velocityPositiveY).normalized * ;

                        break;

                }
            }
        else if (velocityChangeNeededY == true)
            {

            }*/

    }
}
