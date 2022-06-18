using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLampManager : MonoBehaviour
{
    public AudioClip clip;
    public float volume = 10;

    [SerializeField]
    private Light lamp;
    [SerializeField]
    private Light batteryLight;
    [SerializeField]
    private float battery = 20;
    private float batteryMax;

    private int batteryLvl = 3;

    public List<Transform> raycastsTransform;
    public float sightRange;
    RaycastHit detection;
    public Color rayColor;
    private bool raycastActiveLowBattery = true;

    void Start() {
        batteryMax = battery;
    }

    void Update() {
        UpdateLamp();
        UpdateLampBattery();
        UpdateRayCast();
    }

    void UpdateRayCast() {
        for (int i = 0; i < raycastsTransform.Count; i++) {
            if (lamp.enabled == true && raycastActiveLowBattery == true) {
                Debug.DrawRay(raycastsTransform[i].position, raycastsTransform[i].forward * sightRange, rayColor);

                if (Physics.Raycast(raycastsTransform[i].position, raycastsTransform[i].forward, out detection, sightRange)) {
                    if (detection.collider.tag == "Chaser") {
                        Chase chase = detection.collider.gameObject.GetComponent<Chase>();
                        if (chase != null)
                            chase.setLampOnIt(true);
                    }
                }
            }
        }
    }

    void UpdateLampBattery() {
        int newBatteryLvl = getBatteryLvl();
        if (newBatteryLvl != batteryLvl) {
            batteryLvl = newBatteryLvl;
            changeBatterySpotColor();
        }
    }

    void UpdateLamp() {
        if (lamp.enabled == true) {
            battery -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                lamp.enabled = false;
                AudioSource.PlayClipAtPoint(clip, transform.position, volume);
            }
            if (batteryLvl == 1) {
                LowBatteryLampEffect();
            }
        } else {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                lamp.enabled = true;
                AudioSource.PlayClipAtPoint(clip, transform.position, volume);
            }
        }
        if (battery <= 0f) {
            lamp.enabled = false;
        }
    }

    void LowBatteryLampEffect() {
        int random = Random.Range(1, 100);

        if (lamp.intensity == 1.2f && random > 94) {
            lamp.intensity = 0;
            raycastActiveLowBattery = false;
        }
        else if (lamp.intensity == 0 && random > 94) {
            lamp.intensity = 1.2f;
            raycastActiveLowBattery = true;
        }
    }

    void changeBatterySpotColor() {
        if (batteryLvl == 3) {
            batteryLight.intensity = 1;
            batteryLight.color = Color.green;
        } else if (batteryLvl == 2) {
            batteryLight.intensity = 1;
            batteryLight.color = Color.yellow;
        } else if (batteryLvl == 1) {
            batteryLight.intensity = 1;
            batteryLight.color = Color.red;
        } else {
            batteryLight.intensity = 0;
        }
    }

    int getBatteryLvl() {
        if (battery >= batteryMax * 0.66f) {
            return (3);
        } else if (battery >= batteryMax * 0.33f) {
            return (2);
        } else if (battery > 0) {
            return (1);
        } else {
            return (0);
        }
    }

    public void ChargeBatteryLamp() {
        if (battery < batteryMax) {
            battery += (Time.deltaTime * 4);
        }
    }
}
