using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedMove : MonoBehaviour {

    public enum Type { OneWay, Loop, Turn }
    public Type type;

    public Transform target;
    public float speed;

    private float reachDist = 0.1f;
    private Vector3 originalPos;
    private Vector3 currentTarget;

    private void Awake()
    {
        this.originalPos = this.transform.position;
    }

    void Update () {
        switch(this.type)
        {
            case Type.OneWay:
                if ((this.transform.position - this.target.position).magnitude < this.reachDist)
                    this.enabled = false;
                this.MoveTo(this.target.position);
                break;
            case Type.Loop:
                if ((this.transform.position - this.target.position).magnitude < this.reachDist)
                    currentTarget = this.originalPos;
                if ((this.transform.position - this.originalPos).magnitude < this.reachDist)
                    currentTarget = this.target.position;
                this.MoveTo(currentTarget);
                break;
            case Type.Turn:
                this.transform.Rotate(this.transform.up, this.speed * Time.deltaTime);
                break;
        }
	}

    private void MoveTo(Vector3 pos)
    {
        this.transform.position = 
            Vector3.Lerp(this.transform.position, pos,
                                 this.speed * Time.deltaTime);
    }
}
