using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public enum Type { OnStart, OnEnter, OnExit }
    public Type type;
    public TriggerHandler triggerHandler;

    public string[] scenesToLoad;
    public string[] scenesToUnload;
    public string sceneToSetActive;
    public string sceneToHardLoad;

    private bool hasActivate = false;

    void Start()
    {
        switch (this.type)
        {
            case Type.OnStart: Process(); break;
            case Type.OnEnter: this.triggerHandler.onEnter += Process; break;
            case Type.OnExit: this.triggerHandler.onExit += Process; break;
        }
    }

    private void Process()
    {
        if (this.hasActivate) return;
        this.StartCoroutine(this._Process());
        this.hasActivate = true;
    }

    private IEnumerator _Process() {
        if (!string.IsNullOrEmpty(this.sceneToHardLoad)) {
            SceneManager.LoadScene(this.sceneToHardLoad);
            yield break;
        }
        foreach (string scene in this.scenesToLoad)
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        if (!string.IsNullOrEmpty(this.sceneToSetActive)) {
            yield return new WaitUntil(() => SceneManager.GetSceneByName(this.sceneToSetActive).isLoaded);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(this.sceneToSetActive));
        }
        foreach (string scene in this.scenesToUnload)
            SceneManager.UnloadSceneAsync(scene);
    }
}
