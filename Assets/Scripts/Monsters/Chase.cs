using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Chase : MonoBehaviour {
    private Animation _anim;
    private GameObject player;
    private Renderer renderer;
    private NavMeshAgent agent;
    private bool lampOnIt = false;

    void Start() {
        renderer = GetComponent<Renderer>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        _anim = GameObject.FindGameObjectWithTag("Chaser").GetComponent<Animation>();
    }

    void Update() {
        if (lampOnIt == true) {
            agent.enabled = false;
            lampOnIt = false;
            _anim.Stop();
        } else {
            agent.enabled = true;
            _anim.Play("Run");
            agent.SetDestination(player.transform.position);
        }
    }

    public void setLampOnIt(bool status) {
        lampOnIt = status;
    }

    float mathABS(float value) {return value > 0 ? value : value * -1;}
}
