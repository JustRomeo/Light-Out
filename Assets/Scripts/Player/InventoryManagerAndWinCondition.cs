using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class InventoryManagerAndWinCondition : MonoBehaviour
{
    private int items = 0;

    [SerializeField]
    private int numberOfItemsToWin;

    [SerializeField]
    private Transform trapTransform;
    [SerializeField]
    private BoxCollider trapboxCollider;

    public void addItemAndCheckItemsAmount() {
        items += 1;
        if (items == numberOfItemsToWin) {
            trapTransform.Rotate(90, 0, 0);
            trapboxCollider.enabled = true;
        }
    }

    public void PlayerWin() {
        print("Player Succesful Escape");
        PlayerPrefs.SetInt("isLost", 0);
        SceneManager.LoadScene("Assets/Scenes/EndScreen.unity", LoadSceneMode.Single);
    }
}
