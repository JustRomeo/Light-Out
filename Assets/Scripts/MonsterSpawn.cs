using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawn : MonoBehaviour {

    private float rspawn = 0;
    private float last_clock = 0;
    private float[] spawn_rang = {0, 100}; // Spawn Distance
    private float[] spawn_stay = {10, 20}; // Temps de présence après le spawn
    private float[] spawn_time = {10, 20}; // Temps d'attente du spawn

    void Start() {}
    void Update() {
        float delay = Time.realtimeSinceStartup - last_clock;

        if (delay > rspawn) {
            last_clock = Time.realtimeSinceStartup;
            rspawn = Random.Range(spawn_time[0], spawn_time[1]);
            transform.position = new Vector3(Random.Range(spawn_rang[0], spawn_rang[1]), 1, Random.Range(spawn_rang[0], spawn_rang[1]));
        }
    }
}
