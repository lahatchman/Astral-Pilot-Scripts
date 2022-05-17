using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    [SerializeField]
    private GameObject player;
    private Rigidbody _rb, _bsp;
    private float force;
    [SerializeField]
    private GameObject bulletSP;

    void Start(){
        _rb = GetComponent<Rigidbody>();
        _bsp = bulletSP.GetComponent<Rigidbody>();
#if (UNITY_EDITOR)
        force = 5.0f;
#endif
#if (UNITY_ANDROID)
        force = 5.0f;
#endif
    }

    void Update(){
        _bsp.position = new Vector3(_rb.position.x + 0.85f, _rb.position.y, _rb.position.z);
        movement();
    }

    private void movement(){
        if (player.activeSelf) {
#if (UNITY_EDITOR)
            if (Input.GetKeyDown(KeyCode.Space)) {
                _rb.AddForce(transform.up * force, ForceMode.Impulse);
            }
#endif
#if (UNITY_ANDROID)
            if(Input.touchCount > 0) {
                if (Input.GetTouch(0).phase == TouchPhase.Began) {
                    _rb.AddForce(transform.up * force, ForceMode.Impulse);
                }
            }
#endif
        }
    }
}
