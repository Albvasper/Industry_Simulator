using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildingManager : MonoBehaviour {

    #region Singleton Pattern
        private static BuildingManager instance;
        public static BuildingManager Instance { 
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
    
    private ObjectPooler objectPooler;
    private GameObject placeableObj;
    private GameObject placeableObjPreview;
    private Vector3 offset;
    private Camera mainCam;
    private bool building;
    private int prefabLayer;
    private BuildingGrid buildingGrid;
    [SerializeField] private NavMeshSurface navMeshSurface;

    private void Start() {
        mainCam = Camera.main;
        objectPooler = ObjectPooler.Instance;
        buildingGrid = BuildingGrid.Instance;
        building = false;
        placeableObj = null;
    }
    
    private void Update() {
        if (building == true) {
            if (placeableObj == null) {
                placeableObj = placeableObjPreview;
                placeableObj.layer = 2;
            }
            if (placeableObj != null) {
                TrackMouse();
                Build();
            }
        }
    }

    public void InitBuilding(GameObject go) {
        prefabLayer = go.layer;
        placeableObjPreview = go;
        building = true;
    }

    private void TrackMouse() {
        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            float prefabYpos = placeableObj.transform.position.y;
            placeableObj.transform.position = buildingGrid.GetGridPoint(hit.point);
            placeableObj.transform.position = new Vector3(placeableObj.transform.position.x, prefabYpos, placeableObj.transform.position.z);
            //placeableObj.transform.position = new Vector3(hit.point.x, placeableObj.transform.position.y, hit.point.z);
            if (Input.GetKeyDown(KeyCode.R)) {
                // Rotate structure
                float r = 0.0f;
                r += 90f;
                placeableObj.transform.Rotate(placeableObj.transform.rotation.x, r, placeableObj.transform.rotation.z);
            }
        }
    }

    private void Build() {
        if (Input.GetMouseButtonDown(0)) {
            placeableObj.layer = prefabLayer;
            placeableObj = null;
            navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);
            // Quit building mode
            building = false;
        }
    }
}
