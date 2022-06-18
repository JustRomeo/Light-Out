using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    // public AudioClip clip;
    // public float volume = 5;

    private bool isMoving;
    private bool wasMoving;
    private bool isJumping;
    // private AudioSource soundsystem;
    private CharacterController characterController;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private Vector3 respawnPoint;
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private AnimationCurve jumpFallOff;

    void Start() {
        isMoving = false;
        wasMoving = false;
        isJumping = false;
        // soundsystem.clip = clip;
    }

    void Awake() {
        characterController = GetComponent<CharacterController>();
        respawnPoint = this.transform.position;
    }

    void Update() {
        Movement();
        JumpInput();
        if (this.transform.position.y < -4)
            this.transform.position = respawnPoint;
    }

    private void Movement() {
        float horizontalInput = Input.GetAxis("Horizontal") * movementSpeed;
        float verticalInput = Input.GetAxis("Vertical") * movementSpeed;
        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;
        Vector3 newmovement = forwardMovement + rightMovement;

        wasMoving = isMoving;
        characterController.SimpleMove(newmovement);
        if (!isMoving && (newmovement.x > 1 || newmovement.z > 1)) {
            //print("Movement: " + newmovement);
            isMoving = true;
            wasMoving = false;
        } else if (isMoving && newmovement.x < 0.5 && newmovement.z < 0.5)
            isMoving = false;

        //if (!wasMoving && isMoving)
        //    soundsystem.Play();
        //else if (wasMoving && !isMoving)
        //    soundsystem.Stop();
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
