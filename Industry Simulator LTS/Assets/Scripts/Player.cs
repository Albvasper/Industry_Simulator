using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    #region Singleton Pattern
        private static Player instance;
        public static Player Instance { 
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
    private string currentMilestone = "Planning";
    private bool canMove;
    // Resources
    private int money = 0;
    private int code = 0;
    private int design = 0;
    private int team = 0;

    private void Start() {
        canMove = true;
    }

    public string GetCurrentMilestone() {
        return currentMilestone;
    }

    public void SetCurrentMilestone(string newMilestone) {
        currentMilestone = newMilestone;
    }

    public void AddTeamSize() {
        team++;
        MilestoneManager.Instance.CheckMilestone();
    }

    public int GetTeamSize() {
        return team;
    }

    public string GetGameStudioName() {
        return gameStudioName;
    }
    
    public void SetGameStudioName(string newName) {
        gameStudioName = newName;
    }

    public bool GetCanMove() {
        return canMove; 
    }

    public void EnableMovement() {
        canMove = true;
    }

    public void DisableMovement() {
        canMove = false;
    }
}
