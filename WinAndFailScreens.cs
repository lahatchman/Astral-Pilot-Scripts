using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class WinAndFailScreens : MonoBehaviour {

    public static bool fail, win;
    [SerializeField]
    private GameObject failScreen, winScreen, uiScore, shootButton;
    private DataPersistance data;
    [SerializeField]
    private TextMeshProUGUI failScore, winScore;

    [Serializable]
    public struct Score 
    {
        public float level1Score;
        public float level2Score;
        public float level3Score;
    }

    void Start() 
    {
        data = GameObject.Find("_utilityScripts").GetComponent<DataPersistance>();
        fail = false;
        win = false;
    }

    void Update() {
        failScore.text = "Score: " + data.score.ToString();
        winScore.text = "Score: " + data.score.ToString();
        if (fail) {
            failScreen.SetActive(true);
            shootButton.SetActive(false);
            uiScore.SetActive(false);
        }
        if (win) {
            winScreen.SetActive(true);
            shootButton.SetActive(false);
            uiScore.SetActive(false);
            win = false;
        }
    }

    public void ReturnToMainMenu() {
        savePlayerScore();
        SceneManager.LoadScene(0);
    }

    void savePlayerScore() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = File.Create(Application.persistentDataPath + "/playerScore.dat");
        Score score = new Score
        {
            level1Score = data.score,
            level2Score = data.score,
            level3Score = data.score
        };
        bf.Serialize(stream, score);
        stream.Close();
    }
}

