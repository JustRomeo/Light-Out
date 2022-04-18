using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;


public class Chase : MonoBehaviour {

    private GameObject player;
    private NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        agent.SetDestination(player.transform.position);
        // agent.SetDestination(new Vector3(0, 0, 0));
    }
}
