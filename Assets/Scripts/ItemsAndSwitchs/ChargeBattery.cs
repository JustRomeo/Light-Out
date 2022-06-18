using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBattery : MonoBehaviour
{
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            PlayerLampManager playerLamp = collider.gameObject.transform.Find("Lamp").GetComponent<PlayerLampManager>();
            if (playerLamp != null) {
                playerLamp.ChargeBatteryLamp();
            }
        }
    }
}
