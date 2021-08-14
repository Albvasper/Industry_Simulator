using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Singleton Pattern
        private static GameManager instance;
        public static GameManager Instance { 
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

    private string gameStudioName = "COOL STUDIO!";

    private void Start() {
        GameProject.Instance.InitProjectCreation();
    }

    private void Update() {
        
    }

    public string GetGameStudioName() {
        return gameStudioName;
    }
}
