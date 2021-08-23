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
    private MilestoneManager milestoneManager;
    [SerializeField] private Transform employeeSpawnPoint;
    // Prefabs
    [Header("Prefabs")]
    [Header("Structures")]
    [SerializeField] private GameObject Floor;
    [Header("Employees")]
    [SerializeField] private GameObject employee;

    private void Start() {
        objectPooler = ObjectPooler.Instance;
        buildingManager = BuildingManager.Instance;
        milestoneManager = MilestoneManager.Instance;
    }

    public void PlaceFloor() {
        buildingManager.InitBuilding(Floor);
        UiManager.Instance.CloseMainWindow();
    }

    public void HireDeveloper() {
        // Insted of "Employee" it should be for example: Developer, Artist, Designer, etc.
        objectPooler.SpawnFromPool("Developer", employeeSpawnPoint.position, Quaternion.identity);
        milestoneManager.CheckMilestone();
    }
}
