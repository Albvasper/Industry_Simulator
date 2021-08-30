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
    private bool initBuilding;
    private bool building;
    private int prefabLayer;
    [SerializeField] private NavMeshSurface navMeshSurface;

    private void Start() {
        placeableObj = null;
        mainCam = Camera.main;
        initBuilding = false;
        building = false;
        objectPooler = ObjectPooler.Instance;
    }
    
    private void Update() {
        BuildStructure();
    }

    public void InitBuilding(GameObject go) {
        prefabLayer = go.layer;
        placeableObjPreview = go;
        initBuilding = true;
    }

    private void TrackMouse() {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            float prefabYpos = placeableObj.transform.position.y;
            placeableObj.transform.position = BuildingGrid.Instance.GetGridPoint(hit.point);
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

    public void BuildStructure() {
        if (initBuilding == true) {
            if (placeableObj == null) {
                placeableObj = objectPooler.SpawnFromPool("Floor", new Vector3(0, 0, 0), Quaternion.identity);
                placeableObj.layer = 2;
            }
        }
        if (placeableObj != null) {
            TrackMouse();
            Build();
        }
    }

    private void Build() {
        if (Input.GetMouseButtonDown(0)) {
            placeableObj.layer = prefabLayer;
            placeableObj = null;
            building = true;
            // Quit building mode
            navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);
            initBuilding = false;
        }
    }
}
