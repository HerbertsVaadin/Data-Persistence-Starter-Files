using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private Text HighScoreText;
    
    private void Start()
    {
        UpdateHighScoreText();
    }

    private void UpdateHighScoreText()
    {
        if (HighScoreText == null)
        {
            return;
        }
        
        HighScoreManager.HighScore highScore = HighScoreManager.INSTANCE.GetCurrentHighScore();

        if (highScore == null)
        {
            HighScoreText.text = "Best Score: None";
        }
        else
        {
            HighScoreText.text = "Best Score : " + highScore.userName + " : " + highScore.score;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void UpdateUserName(string userName)
    {
        HighScoreManager.INSTANCE.SetUserName(userName);
    }
}
