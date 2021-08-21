using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    #region Singleton Pattern
        private static ShopManager instance;
        public static ShopManager Instance { 
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
    private BuildingManager buildingManager;
    // Prefabs
    [SerializeField] private GameObject Floor;
    
    private void Start() {
        objectPooler = ObjectPooler.Instance;
        buildingManager = BuildingManager.Instance;
    }

    public void PlaceFloor() {
        buildingManager.InitBuilding(Floor);
        UiManager.Instance.CloseMainWindow();
    }

    public void HireEmployee() {
        objectPooler.SpawnFromPool("Employee", new Vector3(0, 0, 0), Quaternion.identity);
    }
}
