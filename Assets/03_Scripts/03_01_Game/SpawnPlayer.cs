using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    public TileManager tileManager;

    [Header("Nombre de tuile avant ou après le centre où le joueur peut spawner")]
    public int min = -5;
    public int max = 5;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PlacePlayerInLevel()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (tileManager.hexTiles != null && tileManager.hexTiles.Length != 0)
        {
            player.transform.position = tileManager.hexTiles[(tileManager.hexTiles.Length / 2) + Random.Range(min,max)].transform.position + new Vector3(0,1,0);
        }
    }
}
