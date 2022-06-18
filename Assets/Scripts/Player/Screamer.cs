using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Screamer : MonoBehaviour {

    public GameObject screen;

    private GameObject chaser;

    void Start() {
        chaser = GameObject.FindGameObjectWithTag("Chaser");
    }
    void Update() {
        // If chaser it's null it mean we're already in EndMenu
        if (chaser) {
            float delta1 = Vector3.Distance(chaser.transform.position, transform.position);

            if (delta1 < 2.5) {
                PlayerPrefs.SetInt("isLost", 1);
                SceneManager.LoadScene("Assets/Scenes/EndScreen.unity", LoadSceneMode.Single);
            }
        }
    }

    public void screamer() {
        // Stop the player on the screamer screen
        transform.rotation = Quaternion.Euler(0, 0, 0);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraRotation>().enabled = false;

        // Active Screamer
        screen.SetActive(true);
    }
}
