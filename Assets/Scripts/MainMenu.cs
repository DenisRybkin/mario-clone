using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private int currentLevel = 0;
    private int score = 0;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI? titileText;
    public TextMeshProUGUI? buttonTextPlay;

    public Button firstlevelBtn;
    public Button secondlevelBtn;
    public Button thirdlevelBtn;
    public Button fourthlevelBtn;
    public Button fifthLlevelBtn;

    public void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        currentLevel = PlayerPrefs.GetInt("level", 1);
        var isGameOver = (GetCurrentLevel() == SceneManager.sceneCountInBuildSettings - 3);
        if (isGameOver && buttonTextPlay)
        {
            if(titileText) titileText.text = "Game over!";
            buttonTextPlay.text = "Restart";
        }
        currentLevelText.text = "Level: " + (
            isGameOver
                ? "Is last" 
                : currentLevel.ToString()
            );
        scoreText.text = "Score:" + score.ToString();

        Debug.Log(PlayerPrefs.GetInt("level", 1).ToString() + "");
        if (currentLevel < 2) Destroy(secondlevelBtn.gameObject);
        if (currentLevel < 3) Destroy(thirdlevelBtn.gameObject);
        if (currentLevel < 4) Destroy(fourthlevelBtn.gameObject);
        if (currentLevel < 5) Destroy(fifthLlevelBtn.gameObject);
    }

    public int GetScore()
    {
        return PlayerPrefs.GetInt("score", score);
    }


    public void PlayFromStart()
    {
        score = 0;
        currentLevel = 1;
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(3);
    }


    public void Play(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void PlayNextLevel()
    {
        var isGameOver = (GetCurrentLevel() == SceneManager.sceneCountInBuildSettings - 2) || currentLevel == 5; 
        if (isGameOver )
        {
            PlayFromStart();
            return;
        }
        PlayerPrefs.SetInt("level", GetCurrentLevel() + 1);
        SceneManager.LoadScene(currentLevel + 3);
    }

    public void Restart()
    {
        //currentLevel = 0;
        score = 0;
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(GetCurrentLevel() + 2);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public int GetCurrentLevel() {
        return PlayerPrefs.GetInt("level", currentLevel);
    }

    public void IncrementLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("level", currentLevel);
    }

    public void SetLevel(int value)
    {
        PlayerPrefs.SetInt("level", value);
        currentLevel = value;
    }

    public void PlayFirstLevel()
    {
        score = 0;
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("level", 3);
        SceneManager.LoadScene(3);
    }

    public void PlaySecondLevel()
    {
        score = 0;
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("level", 4);
        SceneManager.LoadScene(4);
    }

    public void PlayThirdLevel()
    {
        score = 0;
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("level", 5);
        SceneManager.LoadScene(5);
    }

    public void PlayFourthLevel()
    {
        score = 0;
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("level", 6);
        SceneManager.LoadScene(6);
    }

    public void PlayFifthLevel()
    {
        score = 0;
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("level", 7);
        SceneManager.LoadScene(7);
    }
}
