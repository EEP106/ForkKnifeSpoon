using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreDisplay;

    int score = 0;

    //Checks if another Scoremanager is present and destroys itself is there is
    private void Awake()
    {
        int numberOfScoreManagers = FindObjectsOfType<ScoreManager>().Length;

        if (numberOfScoreManagers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        DisplayUpdate();
    }

    public void ResetScore()
    {
        score = 0;

        DisplayUpdate();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        DisplayUpdate();
    }

    void DisplayUpdate()
    {
        scoreDisplay.text = score.ToString();
    }
}
