using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour {

    public enum Type { OnEnter, OnExit }
    public Type type;
    public TriggerHandler triggerHandler;

    public GameObject[] goToEnable;
    public GameObject[] goToDisable;
    public GameObject[] goToDestory;
    public Behaviour[] bhvToEnable;
    public Behaviour[] bhvToDisable;
    public Behaviour[] bhvToDestory;

    private bool activate = false;

    void Start () {
        switch(this.type) {
            case Type.OnEnter: this.triggerHandler.onEnter += Process; break;
            case Type.OnExit: this.triggerHandler.onExit += Process; break;
        }
    }

    private void Process() {
        if (this.activate) return;
        this.activate = true;
        foreach (GameObject go in this.goToEnable)
            go.SetActive(true);
        foreach (GameObject go in this.goToDisable)
            go.SetActive(false);
        foreach (GameObject go in this.goToDestory)
            Destroy(go);
        foreach (Behaviour bhv in this.bhvToEnable)
            bhv.enabled = true;
        foreach (Behaviour bhv in this.bhvToDisable)
            bhv.enabled = false;
        foreach (Behaviour bhv in this.bhvToDestory)
            Destroy(bhv);
    }
}
