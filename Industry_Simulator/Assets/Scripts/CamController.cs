using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    #region Singleton Pattern
        private static CamController instance;
        public static CamController Instance { 
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

    private ProjectManager projectManager;
    private Player player;
    // Camera settings
    private Camera mainCam;
    [Range(0.01f, 1.0f)]
    [SerializeField] private float smoothFactor = 0.1f;
    private Vector3 cameraOffset;
    private float camVel = 0.5f;
    private int zoomBounds = 5;
    private float zoomRate = 4.0f;
    private Vector2 mousePos = Vector2.zero;

    private void Start() {
        mainCam = Camera.main;
        player = Player.Instance;
        projectManager = ProjectManager.Instance;
        cameraOffset = mainCam.transform.position - projectManager.transform.position;
    }

    private void Update() {
        if (player.GetCanMove() == true) {
            // If the player is off the desk
            if (projectManager.GetIfOnDesk() == false) {
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                mainCam.fieldOfView = 40;
                if (Input.GetMouseButtonDown(1)) {
                    if (Physics.Raycast(ray, out hit)) {
                        if (hit.collider.tag == "Desk") {
                            projectManager.SitOnDesk();
                        }
                        projectManager.MoveAgent(hit.point);
                    }
                }
                // If the player is seated
            } else {
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
                // Camera zoom in 
                if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
                    if (zoomBounds > 1) {
                        mainCam.fieldOfView -= 5;
                        //mainCam.transform.position += new Vector3(0, zoomRate, -zoomRate);
                        zoomBounds--;
                    } 
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
                    // Camera zoom out
                    if (zoomBounds < 14) {
                        mainCam.fieldOfView += 5;
                        //mainCam.transform.position += new Vector3(0, -zoomRate, zoomRate);
                        zoomBounds++;
                    } 
                }
            }
        }
    }

    private void LateUpdate() {
        if (projectManager.GetIfOnDesk() == false) {
            Vector3 newPos = projectManager.transform.position + cameraOffset;
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, newPos, smoothFactor);
        }
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
}
