using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager INSTANCE;
    private string userName;
    private HighScore currentHighScore;
    
    private void Awake()
    {
        if (INSTANCE != null)
        {
            Destroy(gameObject);
            return;
        }

        INSTANCE = this;
        DontDestroyOnLoad(gameObject);
    }

    public string GetUserName()
    {
        return userName;
    }

    public void SetUserName(string newUserName)
    {
        userName = newUserName;
    }

    public HighScore GetCurrentHighScore()
    {
        return currentHighScore;
    }

    public bool RecordScore(int score)
    {

        if (currentHighScore == null || currentHighScore.score < score)
        {
            Debug.Log("Recording score: " + score + " for user: " + GetUserName());
            SetNewHighScore(score);
            return true;
        }

        return false;
    }

    private void SetNewHighScore(int score)
    {
        currentHighScore = new HighScore(GetUserName(), score);
    }

    [Serializable]
    public class HighScore
    {
        public string userName;
        public int score;

        public HighScore(string userName, int score)
        {
            this.userName = userName;
            this.score = score;
        }
    }
}
