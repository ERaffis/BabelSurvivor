using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : Entity
{
    [Range(0,1)]    public float spawnRate;
    public GameObject enemyPrefab;
    [SerializeField] protected NavMeshAgent navMeshAgent;
    [SerializeField] protected GameObject player;
    
    void Awake() {
        navMeshAgent.speed = movementSpeed;
    }

    void Update(){
        navMeshAgent.destination = player.transform.position;
    }

    public void SetPlayerReference(GameObject player)
    {
        this.player = player;
    }
}
