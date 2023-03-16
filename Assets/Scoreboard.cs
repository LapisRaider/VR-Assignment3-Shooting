using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    void Update()
    {
        scoreText.text = scoreManager.GetScoreText();
        timeText.text = scoreManager.GetTimeText();
    }
}
