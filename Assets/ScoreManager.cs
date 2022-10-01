using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreLabel;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreLabel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore()
    {
        return score;       
    }

    public void SetScore(int  newScore)
    {
        score = newScore;
        UpdateScoreLabel();
    }

    public void AddPoint(int point)
    {
        score += point;
        UpdateScoreLabel();
    }

    public void UpdateScoreLabel()
    {
        scoreLabel.text = $"Score: {score}";
    }
}
