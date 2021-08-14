using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectManager : Employee {

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
    
    private bool onDesk = false;

    protected override void Start() {
        base.Start();
    }
    
    protected override void Update() {
        base.Update();
    }

    public bool GetIfOnDesk() {
        return onDesk;
    }

    public void SitOnDesk() {
        onDesk = true;
    }

    public void GetOffDesk() {
        onDesk = false;
    }
}
