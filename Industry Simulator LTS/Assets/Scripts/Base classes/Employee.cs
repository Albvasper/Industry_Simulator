using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Employee : MonoBehaviour {

    protected string agentName;
    [SerializeField] protected NavMeshAgent navMeshAgent;
    protected Player player;

    protected virtual void Start() {
        player = Player.Instance;
        player.AddTeamSize();
    }

    protected virtual void Update() {
        
    }

    public void MoveAgent(Vector3 destination) {
        navMeshAgent.SetDestination(destination);
    }
}
