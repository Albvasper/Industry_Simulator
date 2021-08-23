using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilestoneManager : MonoBehaviour {

    #region Singleton Pattern
        private static MilestoneManager instance;
        public static MilestoneManager Instance { 
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

    private Player player;
    private UiManager uiManager;

    private void Start() {
        player = Player.Instance;
        uiManager = UiManager.Instance;
    }

    public void CheckMilestone() {
        Debug.Log("Player team size is: " + player.GetTeamSize().ToString());
        // Call method when the player hires someone
        switch (player.GetCurrentMilestone()) {
            case "Planning": 
                if (player.GetTeamSize() == 2) {
                    uiManager.ShowMilestonePanel();
                    player.SetCurrentMilestone("Pre Production");
                }
            break;
            case "Pre Production": 
                //if (/*Condition*/) {
                    uiManager.ShowMilestonePanel();
                    player.SetCurrentMilestone("Production");
                //}
            break;
            case "Production": 
                //if (/*Condition*/) {
                    uiManager.ShowMilestonePanel();
                    player.SetCurrentMilestone("Testing");
                //}
            break;
            case "Testing": 
                //if (/*Condition*/) {
                    uiManager.ShowMilestonePanel();
                    player.SetCurrentMilestone("Pre Launch");
                //}
            break;
            case "Pre Launch": 
                //if (/*Condition*/) {
                    uiManager.ShowMilestonePanel();
                    player.SetCurrentMilestone("Launch");
                //}
            break;
            case "Launch": 
                //if (/*Condition*/) {
                    uiManager.ShowMilestonePanel();
                    player.SetCurrentMilestone("Post Production");
                //}
            break;
        }
    }
}
