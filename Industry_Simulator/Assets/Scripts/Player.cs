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
    
    private Camera mainCam;
    private string gameStudioName = "COOL STUDIO!";
    private string currentMilestone = "Planning";
    // Resources
    private int money = 0;
    private int code = 0;
    private int design = 0;
    private int team = 0;
    // Camera settings
    private float camVel = 0.5f;
    private int zoomBounds = 5;
    private float zoomRate = 4.0f;
    private Vector2 mousePos = Vector2.zero;

    private void Start() {
        mainCam = Camera.main;
    }

    private void Update() {
        #region Player movement
        // If the player is off the desk
        if (ProjectManager.Instance.GetIfOnDesk() == false) {



            // BUG: This is being called every frame, only make it do it one time


            
            UiManager.Instance.HideHUD();
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetMouseButtonDown(1)) {
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.tag == "Desk") {
                        ProjectManager.Instance.SitOnDesk();
                    }
                    ProjectManager.Instance.MoveAgent(hit.point);
                }
            }
            // If the player is seated
        } else {
            UiManager.Instance.ShowHUD();
            if (Input.GetKey(KeyCode.W)) {
                //Move Up
                MoveCamera("up");
            }
            else if (Input.GetKey(KeyCode.S)) {
                //Move Down
                MoveCamera("down");
            }
            if (Input.GetKey(KeyCode.A)) {
                //Move Left
                MoveCamera("left");
            }
            else if (Input.GetKey(KeyCode.D)) {
                //Move Right
                MoveCamera("right");
            }
        #endregion
        #region Camera movement
            // Camera zoom in 
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
                if (zoomBounds > 1){
                    mainCam.transform.position += new Vector3(0, zoomRate, -zoomRate);
                    zoomBounds--;
                } 
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
                // Camera zoom out
                if (zoomBounds < 14){
                    mainCam.transform.position += new Vector3(0, -zoomRate, zoomRate);
                    zoomBounds++;
                } 
            }
        }
        #endregion
    }

    private void MoveCamera(string input) {
        switch (input) {
            case "up":
                mainCam.transform.position += new Vector3(0, 0, camVel);
            break;

            case "down":
                mainCam.transform.position += new Vector3(0, 0, -camVel);
            break;

            case "left":
                mainCam.transform.position += new Vector3(-camVel, 0, 0);
            break;

            case "right":
                mainCam.transform.position += new Vector3(camVel, 0, 0);
            break;
        }
    }

    public string GetCurrentMilestone() {
        return currentMilestone;
    }

    public void SetCurrentMilestone(string newMilestone) {
        currentMilestone = newMilestone;
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
}
