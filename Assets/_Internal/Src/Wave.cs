using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    public bool zDirection = false;
    public bool xDirection = false;
    public float height = 1f;
    public float frequenecy = 1f;
    public float initSpeed = 1f;

    private Transform[] children;
    private Vector3[] xzValues;
    private float time;

	void Start () {
        this.children = this.GetComponentsInChildren<Transform>();
        this.xzValues = new Vector3[this.children.Length];
    }
	
	void Update () {
        Vector3 pos;
        for(int i = 0; i < this.children.Length; i++) {
            Transform child = this.children[i];
            if (child == this.transform) continue;
            pos = child.transform.localPosition;
            xzValues[i].x = Mathf.Lerp(xzValues[i].x, pos.x, Time.deltaTime * this.initSpeed);
            xzValues[i].z = Mathf.Lerp(xzValues[i].z, pos.z, Time.deltaTime * this.initSpeed);
            pos.y = this.height * Mathf.Sin(this.frequenecy * this.time
                + ((xDirection) ? this.xzValues[i].x : 0f) 
                + ((zDirection) ? this.xzValues[i].z : 0f));
            child.transform.localPosition = pos;
        }
        this.time += Time.deltaTime;
	}
}