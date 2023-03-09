using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    [SerializeField] private int time;

    private int score = 0;

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
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        while (time >= 0)
        {
            timeText.text = "Time Left: " + time;
            time--;
            yield return new WaitForSeconds(1);
        }
    }

    public void IncrementScore(int val)
    {
        if (time > 0)
        {
            score += val;
            scoreText.text = "Score: " + score;
        }
    }
}