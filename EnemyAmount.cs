using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmount : MonoBehaviour{

    [SerializeField]
    private GameObject[] numberOfEnemies;
    [SerializeField]
    private GameObject enemy;
    private bool spawning = true;

    void Start(){

    }

    void Update(){
        spawnEnemy();
    }

    void spawnEnemy() {
        if (spawning) {
            for (int i = 0; i < numberOfEnemies.Length; i++) {
                Instantiate(enemy, numberOfEnemies[i].transform.position, numberOfEnemies[i].transform.rotation);
            }
            spawning = false;
        }
    }
}

