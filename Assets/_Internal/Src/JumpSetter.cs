using UnityEngine;

[RequireComponent(typeof(Collider))]
public class JumpSetter : MonoBehaviour {

    public float jumpSpeed;

    private float originalJumpSpeed;

    private void OnTriggerEnter(Collider other) {
        this.originalJumpSpeed = other.GetComponent<StandardFPC>().jumpSpeed;
        other.GetComponent<StandardFPC>().jumpSpeed = this.jumpSpeed;
    }

    private void OnTriggerExit(Collider other) {
        other.GetComponent<StandardFPC>().jumpSpeed = this.originalJumpSpeed;
    }
}
