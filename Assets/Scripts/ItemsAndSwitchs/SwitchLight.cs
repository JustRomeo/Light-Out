using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> gameObjectSwitchs;
    [SerializeField]
    private List<Light> lights;

    public void switchLightOn() {
        foreach (var gameObjectSwitch in gameObjectSwitchs) {
            gameObjectSwitch.transform.GetChild(0).gameObject.transform.Rotate(new Vector3(40f, 0f, 0f));
            gameObjectSwitch.tag = "SwitchOn";
        }
        foreach (var light in lights) {
            light.intensity = 1;
        }
    }

    public void switchLightOff() {
        foreach (var gameObjectSwitch in gameObjectSwitchs) {
            gameObjectSwitch.transform.GetChild(0).gameObject.transform.Rotate(new Vector3(-40f, 0f, 0f));
            gameObjectSwitch.tag = "SwitchOff";
        };
        foreach (var light in lights) {
            light.intensity = 0;
        }
    }
}
