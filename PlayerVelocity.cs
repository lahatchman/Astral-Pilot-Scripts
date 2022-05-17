using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVelocity : MonoBehaviour {

    [SerializeField]
    private GameObject goal;
    private Rigidbody _rb;
    private float forward;

    void Start() {
        _rb = GetComponent<Rigidbody>();
        forward = 5.0f;
    }

    void Update() {
        if(_rb.transform.position.x < goal.transform.position.x) {
            _rb.velocity = new Vector3(forward, 0, 0);
        }
        if (_rb.transform.position.x >= goal.transform.position.x) {
            _rb.velocity = new Vector3(0, 0, 0);
        }
        if (WinAndFailScreens.fail) {
            _rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
