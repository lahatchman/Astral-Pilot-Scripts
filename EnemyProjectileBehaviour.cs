using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehaviour : MonoBehaviour{

    private Rigidbody _rb;
    [SerializeField]
    private GameObject bullletSP;
    [SerializeField]
    private float force, resetDelay;
    private Vector3 originalPos;
    private bool startCoroutine = true;


    void Start(){
        _rb = GetComponent<Rigidbody>();
    }

    void Update(){
        shooting();
    }

    void shooting(){
        _rb.AddForce(transform.up * force, ForceMode.Impulse);
        if (startCoroutine){
            StartCoroutine(resetTime());
            startCoroutine = false;
        }
    }

    IEnumerator resetTime() {
        yield return new WaitForSeconds(resetDelay);
        resetProjectile();
        startCoroutine = true;
    }

    void resetProjectile() {
        _rb.velocity = Vector3.zero;
        _rb.transform.position = bullletSP.transform.position;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name.Contains("Ast")) {
            resetProjectile();
        }
        if (other.name.Contains("Player")) {
            Destroy(gameObject);
        }
        if (other.name.Contains("Ene")) {
            resetProjectile();
        }
        if (other.name.Contains("Bul")) {
            resetProjectile();
        }
    }
}

