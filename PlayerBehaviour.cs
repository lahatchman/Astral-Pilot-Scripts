using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerBehaviour : MonoBehaviour{

    [SerializeField]
    private GameObject playerVelocity;
    private Rigidbody pVelocity;


    void Start() {
        pVelocity = playerVelocity.GetComponent<Rigidbody>();

    }

    void Update(){

    }

    private void OnTriggerEnter(Collider other) {
        if (other.name.Contains("Ast")) {
            Rigidbody _ab = other.GetComponent<Rigidbody>();
            _ab.AddForce(pVelocity.velocity.normalized * 2, ForceMode.VelocityChange);
            WinAndFailScreens.fail = true;
            this.gameObject.SetActive(false);
        }
        if (other.name.Contains("Ene")) {
            this.gameObject.SetActive(false);
            WinAndFailScreens.fail = true;
        }
    }
}

