using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;


public class Chase : MonoBehaviour {

    private GameObject player;
    private Renderer renderer;
    private NavMeshAgent agent;

    void Start() {
        renderer = GetComponent<Renderer>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update() {
        float deltaX = mathABS(player.transform.position.x - transform.position.x);
        float deltaZ = mathABS(player.transform.position.z - transform.position.z);

        if (renderer.isVisible && deltaX < 25 && deltaZ < 25)
            agent.enabled = false;
        else {
            agent.enabled = true;
            agent.SetDestination(player.transform.position);
        }
    }

    float mathABS(float value) {return value > 0 ? value : value * -1;}
}
