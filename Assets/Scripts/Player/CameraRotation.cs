using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float cameraSensitivity = 8.0f;
    private float cameraRotationX = 0.0f;
    private float cameraRotationY = 0.0f;
    private float cameraRotationXClamp = 0.0f;
    [SerializeField] private Transform playerBody;

    void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        cameraRotationX = cameraSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        cameraRotationY = cameraSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;
        cameraRotationXClamp += cameraRotationY;

        if (cameraRotationXClamp > 90.0f) {
            cameraRotationXClamp = 90.0f;
            cameraRotationY = 0.0f;
            ClampXRotationToValue(270.0f);
        } else if (cameraRotationXClamp < -90.0f) {
            cameraRotationXClamp = -90.0f;
            cameraRotationY = 0.0f;
            ClampXRotationToValue(90.0f);
        }
        transform.Rotate(Vector3.left * cameraRotationY);
        playerBody.Rotate(Vector3.up * cameraRotationX);
    }

    private void ClampXRotationToValue(float value) {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
