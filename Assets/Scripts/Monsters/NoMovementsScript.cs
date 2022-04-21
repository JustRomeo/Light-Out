using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoMovementsScript : MonoBehaviour {
    private float last_clock;
    private Transform player;
    private bool touched = false;
    private float range_see = 15;
    private float range_mvt = 5; // Bewteen 0 and 9
    private Vector3 oldplayer = new Vector3(0, 0, 0);

    void Start() {
        touched = false;
        last_clock = Time.realtimeSinceStartup;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        oldplayer = player.position;
        range_mvt /= 1000;
    }
    void Update() {
        float delay = Time.realtimeSinceStartup - last_clock;

        if (delay < 4);
            // print("Delay: " + delay);
        else if (touched);
        else if (doISeeYou()) {
            touched = doPlayerMove();
            oldplayer = player.position;
        }
    }

    bool doISeeYou() {
        if (mathABS(player.position.x - transform.position.x) < range_see)
            if (mathABS(player.position.y - transform.position.y) < range_see)
                if (mathABS(player.position.z - transform.position.z) < range_see)
                    return true;
        return false;
    }
    bool doPlayerMove() {
        if (mathABS(oldplayer.x - player.position.x) > range_mvt) {
            print("Player Moved (DeltaX: " + mathABS(oldplayer.x - player.position.x) + ")");
            return true;
        }
        // else if (mathABS(oldplayer.y - player.position.y) > range_mvt) {
        //     print("Player Jumped (DeltaY: " + mathABS(oldplayer.y - player.position.y) + ")");
        //     return true;
        // }
        else if (mathABS(oldplayer.z - player.position.z) > range_mvt) {
            print("Player Moved (DeltaZ: " + mathABS(oldplayer.z - player.position.z) + ")");
            return true;
        }
        return false;
    }

    float mathABS(float value) {return value > 0 ? value : value * -1;}
    public void reset() {
        touched = false;
        oldplayer = player.position;
        last_clock = Time.realtimeSinceStartup;
    }
}
