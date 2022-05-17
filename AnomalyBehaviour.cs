using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyBehaviour : MonoBehaviour {

    private Rigidbody _rb;
    private DataPersistance data;

    void Start() {
        data = GameObject.Find("_utilityScripts").GetComponent<DataPersistance>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name.Contains("Play")) {
            data.score += 2.5f;
            Destroy(gameObject);
        }
    }
}
