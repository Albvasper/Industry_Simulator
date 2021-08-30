using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptionist : Character {

    [SerializeField] private GameObject projectManagerDesk;

    protected override void Start() {
        base.Start();
        #region  Dialogs
            dialogs.Enqueue("You're the new project manager right? \nFollow me.");
        #endregion
    }

    protected override void Update() {
        base.Update();
    }

    public void Talk() {
        if (dialogs.Count > 0) {
            GameManager.Instance.InitDialog("Receptionist", dialogs.Dequeue());
        }
    }

    public void WalkToProjectManagerDesk() {
        MoveAgent(projectManagerDesk.transform.position);
    }
}
