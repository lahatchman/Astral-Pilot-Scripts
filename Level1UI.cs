using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1UI : MonoBehaviour {

    private DataPersistance data;
    [SerializeField]
    private TextMeshProUGUI scoreUI;

    void Start() {
        data = GameObject.Find("_utilityScripts").GetComponent<DataPersistance>();
    }

    void Update() {
        UITextUpdate();
    }

    void UITextUpdate() {
        scoreUI.text = "Score: " + data.score.ToString();
    }
}

