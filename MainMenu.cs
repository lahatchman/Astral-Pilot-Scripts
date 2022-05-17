using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using System;

public class MainMenu : MonoBehaviour 
{

    [SerializeField]
    private GameObject gameTitle, mainMenu, tutorialMenu, controlsMenu, scoreMenu, creditsMenu, missionSelectMenu, scoreGameObjects, controltutorialGameObjects;
    private GameObject previousMenu;
    private float mission1Score, mission2Score, mission3Score;
    [SerializeField]
    private TextMeshProUGUI level1HighScoreTxt, level2HighScoreTxt, level3HighScoreTxt;

    [Serializable]
    public struct HighScore
    {
        public float level1HighScore;
        public float level2HighScore;
        public float level3HighScore;
    }

    void Start() 
    {
        LoadPlayerScore();
        previousMenu = mainMenu;
    }

    void Update() 
    {
        UIUpdateHighScoreText();
    }

    public void MainMenuReturn() 
    {
        mainMenu.SetActive(true);
        missionSelectMenu.SetActive(false);
        tutorialMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Mission1() 
    {
        SceneManager.LoadScene(1);
    }

    public void Mission2()
    {
        SceneManager.LoadScene(2);
    }

    public void Mission3()
    {
        SceneManager.LoadScene(3);
    }

    public void TutorialMenu() 
    {
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(true);
    }

    public void ControlsMenu() 
    {
        gameTitle.SetActive(false);
        tutorialMenu.SetActive(false);
        controltutorialGameObjects.SetActive(true);
        controlsMenu.SetActive(true);
        previousMenu = controlsMenu;
    }

    public void TutorialReturn() 
    {
        gameTitle.SetActive(true);
        tutorialMenu.SetActive(true);
        scoreMenu.SetActive(false);
        scoreGameObjects.SetActive(false);
        controltutorialGameObjects.SetActive(false);
        previousMenu.SetActive(false);
        previousMenu = tutorialMenu;
    }

    public void ScoreMenu() 
    {
        tutorialMenu.SetActive(false);
        gameTitle.SetActive(false);
        scoreMenu.SetActive(true);
        scoreGameObjects.SetActive(true);
        previousMenu = scoreMenu;
    }

    public void CreditsMenu() 
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void MissionSelectionMenu() 
    {
        mainMenu.SetActive(false);
        missionSelectMenu.SetActive(true);
        previousMenu = missionSelectMenu;
    }

    void LoadPlayerScore() 
    {
        if (File.Exists(Application.persistentDataPath + "/playerScore.dat")) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerScore.dat", FileMode.Open); //persistantDataPath
            WinAndFailScreens.Score masterScore = (WinAndFailScreens.Score)bf.Deserialize(file);
            WinAndFailScreens.Score score = new WinAndFailScreens.Score
            {
                level1Score = masterScore.level1Score,
                level2Score = masterScore.level2Score,
                level3Score = masterScore.level3Score
            };
            file.Close();
            if (score.level1Score > mission1Score)
            {
                mission1Score = score.level1Score;
            }
            if (score.level2Score > mission2Score)
            {
                mission2Score = score.level2Score;
            }
            if (score.level3Score > mission3Score)
            {
                mission3Score = score.level3Score;
            }
        }
    }

    public void SavePlayerHighScore()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = File.Create(Application.persistentDataPath + "/playerHighScore.dat");
        HighScore highScore = new HighScore
        {
            level1HighScore = mission1Score,
            level2HighScore = mission2Score,
            level3HighScore = mission3Score
        };
        bf.Serialize(stream, highScore);
        stream.Close();
    }

    public void LoadPlayerHighScore()
    {
        if (File.Exists(Application.persistentDataPath + "/playerHighScore.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerHighScore.dat", FileMode.Open); //persistantDataPath
            HighScore masterHighScore = (HighScore)bf.Deserialize(file);
            HighScore highScore = new HighScore
            {
                level1HighScore = masterHighScore.level1HighScore,
                level2HighScore = masterHighScore.level2HighScore,
                level3HighScore = masterHighScore.level3HighScore
            };
            file.Close();
            mission1Score = highScore.level1HighScore;
            mission2Score = highScore.level2HighScore;
            mission3Score = highScore.level3HighScore;
            UIUpdateHighScoreText();
        }
    }

    void UIUpdateHighScoreText()
    {
        level1HighScoreTxt.text = "Personal Best: " + mission1Score.ToString();
        level2HighScoreTxt.text = "Personal Best: " + mission2Score.ToString();
        level3HighScoreTxt.text = "Personal Best: " + mission3Score.ToString();
    }
}

