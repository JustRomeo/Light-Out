using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerViewItemsAndSwitchsDetector : MonoBehaviour
{
    public float sightRange;
    RaycastHit detection;
    public Color rayColor;

    [SerializeField]
    private GameObject pickUpText;
    [SerializeField]
    private GameObject turnOffText;
    [SerializeField]
    private GameObject turnOnText;
    [SerializeField]
    private GameObject backgroundText;

    void FixedUpdate() {
        Debug.DrawRay(transform.position, transform.forward * sightRange, rayColor);

        if(Physics.Raycast(transform.position, transform.forward, out detection, sightRange)) {
            if(detection.collider.tag == "Item") {
                pickUpText.SetActive(true);
                backgroundText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F)) {
                    Destroy(detection.transform.gameObject);
                }
            }
            else if(detection.collider.tag == "SwitchOn") {
                turnOffText.SetActive(true);
                backgroundText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F)) {
                    SwitchLight switchLight = detection.collider.gameObject.GetComponent<SwitchLight>();
                    if (switchLight != null)
                        switchLight.switchLightOff();
                }
            }
            else if(detection.collider.tag == "SwitchOff") {
                turnOnText.SetActive(true);
                backgroundText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F)) {
                    SwitchLight switchLight = detection.collider.gameObject.GetComponent<SwitchLight>();
                    if (switchLight != null)
                        switchLight.switchLightOn();
                }
            }
        } else {
            pickUpText.SetActive(false);
            turnOffText.SetActive(false);
            turnOnText.SetActive(false);
            backgroundText.SetActive(false);
        }
    }
}
