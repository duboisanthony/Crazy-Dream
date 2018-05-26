using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSetter : MonoBehaviour {

    public Node node;
    public StandardNPC npc;

	void Start () {
        this.npc.SetCurrentNode(node);
	}
}
