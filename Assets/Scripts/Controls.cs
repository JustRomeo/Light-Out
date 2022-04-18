using UnityEngine;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

public class Controls : MonoBehaviour {
    public float speed = 10f;

    private Rigidbody rb;
    private Vector3 oldmousepositions;

    void Start() {
        rb = GetComponent<Rigidbody>();
        oldmousepositions = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
    }
    void Update() {
        keycontrols();
        viewcontrol();
        correction();
    }

    void keycontrols() {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(xMove, rb.velocity.y, zMove) * speed;
    }
    void viewcontrol() {
        Vector3 mousePos = Input.mousePosition;

        if (oldmousepositions.x - mousePos.x > 3) // Left
            transform.Rotate(0f, -2.5f, 0f, Space.Self);
        else if (oldmousepositions.x - mousePos.x < -3) // Right
            transform.Rotate(0f, 2.5f, 0f, Space.Self);
        else {
            if (oldmousepositions.y - mousePos.y > 3) // Down
                transform.Rotate(2.5f, 0f, 0F, Space.Self);
            else if (oldmousepositions.y - mousePos.y < -3) // Up
                transform.Rotate(-2.5f, 0f, 0f, Space.Self);
        }
        oldmousepositions = new Vector3(mousePos.x, mousePos.y, 0);
    }
    void correction() {
        if (transform.position.y < 0)
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);

        // if (transform.rotation.y < -90)
        //     transform.Rotate(90f, 0f, 0F, Space.Self);
    }

    float valueabs(float value) {return value > 0 ? value : value * -1;}
}
