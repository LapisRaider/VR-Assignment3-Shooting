using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score = 0;
    private float timeStarted;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        timeStarted = Time.time;
    }

    public void IncrementScore(int val)
    {
        score += val;
    }

    public string GetScoreText()
    {
        if (score >= 9)
        {
            return "All cats fed! <3";
        }
        
        return score + " cats fed";
    }

    public string GetTimeText()
    {
        return TimeToString(Time.time - timeStarted);
    }

    public string TimeToString(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds - minutes * 60);
        return string.Format("{0:00} : <mspace=0.5em>{1:00}", minutes, seconds);
    }
}