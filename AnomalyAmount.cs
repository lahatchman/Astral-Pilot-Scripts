using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyAmount : MonoBehaviour {

    [SerializeField]
    private GameObject[] numberOfAnomalies;
    [SerializeField]
    private GameObject Anomaly;
    private bool spawning = true;

    void Start() {

    }

    void Update() {
        spawnAnomaly();
    }

    void spawnAnomaly() {
        if (spawning) {
            for (int i = 0; i < numberOfAnomalies.Length; i++) {
                Instantiate(Anomaly, numberOfAnomalies[i].transform.position, numberOfAnomalies[i].transform.rotation);
            }
            spawning = false;
        }
    }
}
