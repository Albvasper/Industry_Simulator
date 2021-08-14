using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour {

    protected string agentName;
    [SerializeField] protected NavMeshAgent navMeshAgent;

    protected virtual void Start() {
        
    }

    protected virtual void Update() {
        
    }

    public void MoveAgent(Vector3 destination) {
        navMeshAgent.SetDestination(destination);
    }
}
