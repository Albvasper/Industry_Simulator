using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CutsceneTrigger : MonoBehaviour {

    protected GameManager gameManager;
    
    protected virtual void Start() {
        gameManager = GameManager.Instance;
    }
}
