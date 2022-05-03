using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> positionList;
    [SerializeField]
    private int numberOfItems;
    
    public GameObject itemPrefab;

    void Awake() {
        for (int i = 0; i < numberOfItems; i++) {
            int random_index = Random.Range(1, positionList.Count);
            GameObject item = Instantiate(itemPrefab, positionList[random_index - 1].position, Quaternion.identity);
            item.transform.parent = GameObject.Find("Items").transform;
            positionList.RemoveAt(random_index - 1);
        }
    }
}
