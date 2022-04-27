using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectManager : Character {

    #region Singleton Pattern
        private static ProjectManager instance;
        public static ProjectManager Instance { 
            get { 
                return instance; 
            } 
        }
        
        private void Awake() {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(this);
            }
        }
    #endregion
    
    private bool onDeskFirstTime = false;
    private bool onDesk = false;
    private UiManager uiManager;

    protected override void Start() {
        base.Start();
        uiManager = UiManager.Instance;
    }
    
    protected override void Update() {
        base.Update();
    }

    public bool GetIfOnDesk() {
        return onDesk;
    }

    public void SitOnDesk() {
        if (onDeskFirstTime == false) {
            gameManager.InitProjectCreation();
            onDeskFirstTime = true;
        }
        uiManager.ShowHUD();
        onDesk = true;
    }

    public void GetOffDesk() {
        uiManager.HideHUD();
        onDesk = false;
    }
}
