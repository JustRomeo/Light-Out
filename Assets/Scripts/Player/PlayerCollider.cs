using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Item")) {
            Destroy(other.gameObject);
        }
    }
}
