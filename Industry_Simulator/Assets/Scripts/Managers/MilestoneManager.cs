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

    private void UpgradeMilestone() {
        // Call method when the player hires someone
        switch (Player.Instance.GetCurrentMilestone()) {
            case "Planning": 
                //if (/*Condition*/) {
                    UiManager.Instance.ShowMilestonePanel();
                    Player.Instance.SetCurrentMilestone("Pre Production");
                //}
            break;
            case "Pre Production": 
                //if (/*Condition*/) {
                    UiManager.Instance.ShowMilestonePanel();
                    Player.Instance.SetCurrentMilestone("Production");
                //}
            break;
            case "Production": 
                //if (/*Condition*/) {
                    UiManager.Instance.ShowMilestonePanel();
                    Player.Instance.SetCurrentMilestone("Testing");
                //}
            break;
            case "Testing": 
                //if (/*Condition*/) {
                    UiManager.Instance.ShowMilestonePanel();
                    Player.Instance.SetCurrentMilestone("Pre Launch");
                //}
            break;
            case "Pre Launch": 
                //if (/*Condition*/) {
                    UiManager.Instance.ShowMilestonePanel();
                    Player.Instance.SetCurrentMilestone("Launch");
                //}
            break;
            case "Launch": 
                //if (/*Condition*/) {
                    UiManager.Instance.ShowMilestonePanel();
                    Player.Instance.SetCurrentMilestone("Post Production");
                //}
            break;
        }
    }
}
