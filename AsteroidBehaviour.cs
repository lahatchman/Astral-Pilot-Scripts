using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour {

    [SerializeField]
    private GameObject playerVelocity;
    private Rigidbody _rb, pVelocity;

    void Start() {
        _rb = this.GetComponent<Rigidbody>();
        pVelocity = playerVelocity.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name.Contains("Play")) {
            //_rb.AddForce(pVelocity.velocity.normalized * 2, ForceMode.VelocityChange);
           // WinAndFailScreens.fail = true;
            //other.gameObject.SetActive(false);
        }
    }
}
