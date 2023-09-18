using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;

    [SerializeField] Sprite[] damageStage;

    [SerializeField] int damagedScoreGain = 50;
    [SerializeField] int destroyedScoreGain = 150;

    int damageIndex = 0;

    SpriteRenderer spriteRenderer;
    LevelController levelController;
    ScoreManager scoreManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelController = FindObjectOfType<LevelController>();
        scoreManager = FindObjectOfType<ScoreManager>();

        levelController.AddBlock();
    }

    //Visually damages the block or destroys it on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);

        damageIndex++;

        if(damageIndex < damageStage.Length)
        {
            spriteRenderer.sprite = damageStage[damageIndex];
            
            scoreManager.AddScore(damagedScoreGain);
        }
        else
        {
            Destroy(gameObject);
            levelController.RemoveBlock();
            
            scoreManager.AddScore(destroyedScoreGain);
        }
    }
}
