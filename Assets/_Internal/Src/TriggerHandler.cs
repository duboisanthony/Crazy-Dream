using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerHandler : MonoBehaviour {

    public delegate void Trigger();
    public Trigger onEnter;
    public Trigger onExit;
    public Trigger onStay;

    private void OnTriggerEnter(Collider other)
    {
        if (this.onEnter != null) this.onEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.onExit != null) this.onExit();
    }

    private void OnTriggerStay(Collider other)
    {
        if (this.onStay != null) this.onStay();
    }
}