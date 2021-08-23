using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptionist : Character {

    protected override void Start() {
        base.Start();
        dialogs.Enqueue("You're the new project manager right?");
    }

    protected override void Update() {
        base.Update();
    }

    public void Talk() {
        if (dialogs.Count > 0) {
            GameManager.Instance.InitDialog("Receptionist",dialogs.Dequeue());
        }
    }
}
