using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    #region Singleton Pattern
        private static ObjectPooler instance;
        public static ObjectPooler Instance { 
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

    [System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    [SerializeField] private Dictionary<string, Queue<GameObject>> dictionaryPool;
    [SerializeField] private List<Pool> pools;
    
    private void Start() {
        dictionaryPool = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools) {
            Queue<GameObject> objPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objPool.Enqueue(obj);
            }
            dictionaryPool.Add(pool.tag, objPool);
        }    
    }
        
    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rot) {
        if (dictionaryPool.ContainsKey(tag)) {
            GameObject objToSpawn = dictionaryPool[tag].Dequeue();
            objToSpawn.SetActive(true);
            objToSpawn.transform.position = pos;
            objToSpawn.transform.rotation = rot;
            dictionaryPool[tag].Enqueue(objToSpawn);
            return objToSpawn;
        } else {
            Debug.Log("Pool with tag " + tag + " doesnt exist!");
            return null;
        }
    }
}
