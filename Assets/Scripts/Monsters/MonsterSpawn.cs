using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawn : MonoBehaviour {
    public AudioClip clip;
    public float volume = 10;

    private float rspawn = 0;
    private float sspawn = 0;
    private Transform player;
    private float last_clock = 0;
    private bool spawned = false;
    private float[] stay = {5, 10};        // Temps de presence après spawn
    private float[] spawn_time = {10, 40}; // Temps d'attente du spawn

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        despawn();
    }
    void Update() {
        spawnmovement();
    }

    void spawnmovement() {
        float delay = Time.realtimeSinceStartup - last_clock;

        if (!spawned && delay > rspawn)
            spawn(delay);
        else if (spawned && delay > sspawn)
            despawn();
    }
    void spawn(float delay) {
        Vector3 deltapos = new Vector3(0, 0, 0);

        deltapos.x = Random.Range(player.position.x - 20, player.position.x + 20);
        deltapos.y = 0; // player.position.y;
        deltapos.z = Random.Range(player.position.z - 20, player.position.z + 20);
        deltapos.x = deltapos.x < -4 ? -3 : (deltapos.x >  86 ?  85 : deltapos.x);
        deltapos.z = deltapos.z < -6 ? -5 : (deltapos.z > 102 ? 101 : deltapos.z);

        last_clock = Time.realtimeSinceStartup;
        sspawn = Random.Range(stay[0], stay[1]);
        transform.position = deltapos;
        spawned = true;

        GetComponent<NoMovementsScript>().reset();
        GetComponent<NoMovementsScript>().enabled = true;
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
        // GameObject.FindGameObjectWithTag("NoMoveMonster").GetComponent<Animator>().Play("Attack(1)");
    }
    public void despawn() {
        spawned = false;
        last_clock = Time.realtimeSinceStartup;
        rspawn = Random.Range(spawn_time[0], spawn_time[1]);
        transform.position = new Vector3(transform.position.x, -200, transform.position.z);
        GetComponent<NoMovementsScript>().enabled = false;
    }
}
