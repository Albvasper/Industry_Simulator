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

    [SerializeField] private GameObject milestoneSummaryScreen;

    private void Start() {
        milestoneSummaryScreen.SetActive(false);
    }

    private void UpgradeMilestone() {
        // Call method when the player hires someone
        switch (Player.Instance.GetCurrentMilestone()) {
            case "Planning": 
                //if (/*Condition*/) {
                    Player.Instance.SetCurrentMilestone("Pre Production");
                //}
            break;
            case "Pre Production": 
                //if (/*Condition*/) {
                    Player.Instance.SetCurrentMilestone("Production");
                //}
            break;
            case "Production": 
                //if (/*Condition*/) {
                    Player.Instance.SetCurrentMilestone("Testing");
                //}
            break;
            case "Testing": 
                //if (/*Condition*/) {
                    Player.Instance.SetCurrentMilestone("Pre Launch");
                //}
            break;
            case "Pre Launch": 
                //if (/*Condition*/) {
                    Player.Instance.SetCurrentMilestone("Launch");
                //}
            break;
            case "Launch": 
                //if (/*Condition*/) {
                    Player.Instance.SetCurrentMilestone("Post Production");
                //}
            break;
        }
    }
}
