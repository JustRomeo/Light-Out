using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerAndWinCondition : MonoBehaviour
{
    private int items = 0;

    [SerializeField]
    private int numberOfItemsToWin;

    public void addItemAndCheckItemsAmount() {
        items += 1;
        if (items == numberOfItemsToWin)
            print("You Win !(find door to escape)");
    }
}
