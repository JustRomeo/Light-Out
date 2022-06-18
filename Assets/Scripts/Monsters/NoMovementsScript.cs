using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoMovementsScript : MonoBehaviour {
    public GameObject screen;

    private float last_clock;
    private GameObject player;
    private float startat = 0;
    private float range_mvt = 5; // Bewteen 0 and 9
    private bool touched = false;
    private float range_see = 15;
    private GameObject mvtmonster;
    private bool isJumpScareActive = false;
    private Vector3 oldplayer = new Vector3(0, 0, 0);
    private Quaternion oldrotation = Quaternion.Euler(0, 0, 0);

    void Start() {
        touched = false;
        range_mvt /= 1000;
        oldplayer = player.transform.position;
        last_clock = Time.realtimeSinceStartup;
        player = GameObject.FindGameObjectWithTag("Player");
        mvtmonster = GameObject.FindGameObjectWithTag("NoMoveMonster");
    }
    void Update() {
        float delay = Time.realtimeSinceStartup - last_clock;

        if (delay < 4);
        else if (touched) {
            if (!isJumpScareActive) {
                // Active the jumpscare
                isJumpScareActive = true;
                startat = Time.realtimeSinceStartup;
                screen.SetActive(true);

                // Force the player to watch the Screamer
                oldrotation = player.transform.rotation;
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraRotation>().enabled = false;
            }
        } else if (doISeeYou()) {
            touched = doPlayerMove();
            oldplayer = player.transform.position;
        }

        if (isJumpScareActive && Time.realtimeSinceStartup - startat > 1.5) {
            isJumpScareActive = false;
            screen.SetActive(false);

            // Allow player to move again
            player.transform.rotation = oldrotation;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraRotation>().enabled = true;

            // The monster run away just after to not hit the player again
            gameObject.GetComponent<MonsterSpawn>().despawn();
        }
    }

    bool doISeeYou() {
        player = GameObject.FindGameObjectWithTag("Player");
        if (mathABS(player.transform.position.x - transform.position.x) < range_see)
            if (mathABS(player.transform.position.y - transform.position.y) < range_see)
                if (mathABS(player.transform.position.z - transform.position.z) < range_see)
                    return true;
        return false;
    }
    bool doPlayerMove() {
        if (mathABS(oldplayer.x - player.transform.position.x) > range_mvt)
            return true;
        else if (mathABS(oldplayer.z - player.transform.position.z) > range_mvt)
            return true;
        return false;
    }

    float mathABS(float value) {return value > 0 ? value : value * -1;}
    public void reset() {
        player = GameObject.FindGameObjectWithTag("Player");

        touched = false;
        oldplayer = player.transform.position;
        last_clock = Time.realtimeSinceStartup;
    }
}
