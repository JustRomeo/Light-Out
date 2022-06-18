using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    public GameObject Player;
    public GameObject screen;

    private float startat = 0;

    void Start() {
        if (PlayerPrefs.GetInt("isLost") == 1) {
            Player.GetComponent<Screamer>().screamer();
            startat = Time.realtimeSinceStartup;
        }
    }
    void Update() {
        if (Time.realtimeSinceStartup - startat > 1.3) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraRotation>().enabled = true;
            screen.SetActive(false);
        }
    }

    public void leaveGame() {Application.Quit();}
    public void playAgain() {
        PlayerPrefs.SetInt("isLost", -1);
        SceneManager.LoadScene("Assets/Scenes/GameScene.unity", LoadSceneMode.Single);
    }
}
