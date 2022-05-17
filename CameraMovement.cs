using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    private GameObject cameraStop, playerVelocity, player;
    private Rigidbody _rb, _prb;

    void Start() {
        _rb = GetComponent<Rigidbody>();
        _prb = player.GetComponent<Rigidbody>();
    }

    void Update() {
        if (_rb.transform.position.x < cameraStop.transform.position.x){
            _rb.transform.position = new Vector3(playerVelocity.transform.position.x + 7, 0, 0);
        }
        if(_rb.transform.position.x >= cameraStop.transform.position.x) {
            _prb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
