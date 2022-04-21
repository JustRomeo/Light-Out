using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;
    private CharacterController characterController;
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    private bool isJumping;
    [SerializeField] private Vector3 respawnPoint;

    void Awake() {
        characterController = GetComponent<CharacterController>();
        respawnPoint = this.transform.position;
    }

    void Update() {
        Movement();
        JumpInput();
        if (this.transform.position.y < -4) {
            this.transform.position = respawnPoint;
        }
    }

    private void Movement() {
        float horizontalInput = Input.GetAxis("Horizontal") * movementSpeed;
        float verticalInput = Input.GetAxis("Vertical") * movementSpeed;
        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        characterController.SimpleMove(forwardMovement + rightMovement);
    }

    private void JumpInput() {
        if (Input.GetKeyDown("space") && !isJumping) {
            isJumping = true;
            StartCoroutine(jumpEvent());
        }
    }

    private IEnumerator jumpEvent() {
        float timeInAir = 0.0f;

        characterController.slopeLimit = 90.0f;
        do {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            characterController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while(!characterController.isGrounded && characterController.collisionFlags != CollisionFlags.Above);
        isJumping = false;
        characterController.slopeLimit = 45.0f;
    }
}
