using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public int hiScore = 0;
    private int gmScore;
    public GameManager gameManager;
    public TextMeshProUGUI hiScoreText;

    private void Update()
    {
        gmScore = gameManager.score;

        if (gmScore > hiScore)
        {
            hiScore = gmScore;
            hiScoreText.text = "HIGH SCORE: " + hiScore;
            PlayerPrefs.SetInt("hiScore", hiScore);
        }

    }

    private void Awake()
    {
        hiScore = PlayerPrefs.GetInt("hiScore", 0);
        hiScoreText.text = "HIGH SCORE: " + hiScore;
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
