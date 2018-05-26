using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardFPC : MonoBehaviour {

    public float forwardSpeed = 6f;
    public float jumpSpeed = 8f;
    public float rotationSpeed = 1f;
    public bool applyGravity = true;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController cc;
    private Transform camTransform;

    private void Awake() {
        this.cc = this.GetComponent<CharacterController>();
        this.camTransform = this.GetComponentInChildren<Camera>().transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate() {
        this.transform.Rotate(this.transform.up, Input.GetAxis("Mouse X") * this.rotationSpeed);
        this.camTransform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * this.rotationSpeed);
        if (this.cc.isGrounded) {
            this.moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            this.moveDirection = transform.TransformDirection(this.moveDirection);
            this.moveDirection *= this.forwardSpeed;
            if (Input.GetButton("Jump"))
                this.moveDirection.y = jumpSpeed;

        } else {
            this.moveDirection.y += (applyGravity) ? Physics.gravity.y * Time.deltaTime : 0f;
        }
        this.cc.Move(this.moveDirection* Time.deltaTime);
    }
}
