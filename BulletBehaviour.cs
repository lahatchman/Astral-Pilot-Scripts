using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour{

    private Rigidbody _rb;
    [SerializeField]
    private float destroyDelay;
    private float force;
    private DataPersistance data;

    void Start(){
        _rb = GetComponent<Rigidbody>();
        data = GameObject.Find("_utilityScripts").GetComponent<DataPersistance>();
#if (UNITY_EDITOR)
        force = 0.05f;
#endif
#if (UNITY_ANDROID)
        force = 1.0f;
#endif
    }

    void Update(){
        applyForce();
        destroyBullet();
    }

    void applyForce(){
        _rb.AddForce(-transform.up * force, ForceMode.Impulse);
    }

    void destroyBullet(){
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other){
        if (other.name.Contains("Ast")){
            Destroy(gameObject);
        }
        if (other.name.Contains("Ene")){
            Destroy(gameObject);
        }
    }
}
