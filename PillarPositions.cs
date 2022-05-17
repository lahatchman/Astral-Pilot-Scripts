using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPositions : MonoBehaviour {

    private Vector3 pillarStartPos;
    [SerializeField]
    public enum dimensions { Roof, Floor };
    public dimensions pillars;

    void Start() {
        SetPillarPos();
    }

    void Update() {

    }

    void Awake() {
        pillarStartPos = transform.position;
    }

    void SetPillarPos() {
        if (pillars == dimensions.Roof) {
            pillarStartPos.y += (ScreenDimensions.screenHeight / 2) - 1.2f;
            transform.position = pillarStartPos;
        }
        else if (pillars == dimensions.Floor) {
            pillarStartPos.y -= ScreenDimensions.screenHeight / 2;
            transform.position = pillarStartPos;
        }
    }
}
