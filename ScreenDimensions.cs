using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDimensions : MonoBehaviour {

    public static float screenHeight, screenWidth;

    void Start() {
        
    }

    void Update() {
        
    }

    void Awake() {
        screenHeight = Camera.main.orthographicSize * 2;
        screenWidth = screenHeight * Screen.width / Screen.height;
    }
}
