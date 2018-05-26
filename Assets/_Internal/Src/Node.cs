using UnityEngine;

public class Node : MonoBehaviour {

    public Node next;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position, 0.2f);
        if (this.next) {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(this.transform.position, this.next.transform.position);
        }
    }
}
