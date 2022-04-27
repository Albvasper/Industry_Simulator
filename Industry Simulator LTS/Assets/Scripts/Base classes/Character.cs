using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Employee  {

    protected Queue<string> dialogs = new Queue<string>();
    protected GameManager gameManager;

    protected override void Start() {
        base.Start();
        gameManager = GameManager.Instance;
    }

    protected override void Update() {
        base.Update();
    }
}
