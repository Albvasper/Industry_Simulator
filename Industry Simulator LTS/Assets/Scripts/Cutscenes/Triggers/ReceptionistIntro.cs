using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionistIntro : CutsceneTrigger {
    
    protected override void Start() {
        base.Start();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            gameManager.WelcomeIntro();
        }
    }
}
    