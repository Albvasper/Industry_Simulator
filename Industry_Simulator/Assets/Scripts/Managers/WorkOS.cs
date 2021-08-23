using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkOS : MonoBehaviour {

    #region Singleton Pattern
        private static WorkOS instance;
        public static WorkOS Instance { 
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

    private void SendMessageToTeam() {

    }
}