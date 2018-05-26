using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardNPC : MonoBehaviour {

    public Node node;
    public float speed;

    private Node currentNode;
    private float reachDist = 1f;

    private void Start() {
        this.currentNode = this.node;
    }

    void Update () {
        if ((this.currentNode.transform.position - this.transform.position).magnitude < this.reachDist) {
            if (this.currentNode.next) {
                this.currentNode = this.currentNode.next;
            }
        }
        else {
            this.transform.position =
                Vector3.Lerp(this.transform.position, this.currentNode.transform.position, this.speed * Time.deltaTime);
        }
	}

    public void SetCurrentNode(Node node)
    {
        this.currentNode = node;
    }
}
