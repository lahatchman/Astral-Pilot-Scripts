using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour{

    private Rigidbody _rb;
    private Vector3 _spawnPosition;
    [SerializeField]
    private float speed, distance;
    [SerializeField]
    private GameObject bulletSP;
    private DataPersistance data;

    void Start() {
        data = GameObject.Find("_utilityScripts").GetComponent<DataPersistance>();
        _rb = GetComponent<Rigidbody>();
        _spawnPosition = _rb.transform.position;
    }

    void Update() {
        movement();
    }

    private void movement() {
        _rb.transform.position = _spawnPosition + transform.up * (Mathf.Sin(speed * Time.time) * distance);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name.Contains("Bul")) {
            data.score += 10;
            Destroy(gameObject);
        }
    }
}

