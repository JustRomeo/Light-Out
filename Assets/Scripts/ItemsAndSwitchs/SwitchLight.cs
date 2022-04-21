using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    [SerializeField]
    private Transform transformRotationPoint;
    [SerializeField]
    private Light light;

    public void switchLightOn() {
        transformRotationPoint.Rotate(new Vector3(40f, 0f, 0f));
        light.intensity = 1;
        transform.gameObject.tag = "SwitchOn";
    }

    public void switchLightOff() {
        transformRotationPoint.Rotate(new Vector3(-40f, 0f, 0f));
        light.intensity = 0;
        transform.gameObject.tag = "SwitchOff";
    }
}
