using UnityEngine;

public class ControllerHeightSetter : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CharacterController>().height = 1f;
    }
}
