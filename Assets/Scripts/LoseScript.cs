using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScript : MonoBehaviour
{
    [SerializeField]SceneLoader sceneLoader;

    [SerializeField] int loseSceneIndex = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<ScoreManager>().ResetScore();
        
        sceneLoader.LoadScene(loseSceneIndex);
    }
}
