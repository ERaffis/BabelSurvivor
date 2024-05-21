using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawning : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float preventSpawnRadius;
    public GameObject[] enemies;
    public float timeBetweenSpawns;
    public float timer;

    public Transform enemyContainer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        preventSpawnRadius = player.GetComponent<Player>().preventSpawnSphere.radius;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            if (timeBetweenSpawns> 1) timeBetweenSpawns -= 0.1f;
            else timeBetweenSpawns = 1;
            SpawnWave();
        }
    }

    void SpawnWave()
    { 
        for (int i = 0; i < Random.Range((int) 5, (int) 15); i++){
           
            int directionX;
            if (Random.Range(0f,1f) > 0.5f) directionX = 1; else directionX = -1;
            int directionY;
            if (Random.Range(0f,1f) > 0.5f) directionY = 1; else directionY = -1;
            
            float spawnChance = Random.Range(0f,1f);
            foreach(GameObject enemy in enemies) {
                if (enemy.GetComponent<Enemies>().spawnRate > spawnChance)
                {
                    Instantiate
                    (
                    enemy, 
                    new Vector3(player.transform.position.x + (Random.Range(preventSpawnRadius,preventSpawnRadius + 10) * directionX),
                    1,
                    player.transform.position.z + (Random.Range(preventSpawnRadius,preventSpawnRadius + 10) * directionY)),
                    Quaternion.identity
                    );
                    break;
                } 
            }
        }
    }
}
