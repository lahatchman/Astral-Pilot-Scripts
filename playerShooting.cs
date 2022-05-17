using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class playerShooting : MonoBehaviour{

    [SerializeField]
    private GameObject bullet, bulletSP;

    void Start() {
       
    }

    void Update() {

    }

    public void Shooting() {
        Instantiate(bullet, bulletSP.transform.position, bulletSP.transform.rotation);
    }
}

