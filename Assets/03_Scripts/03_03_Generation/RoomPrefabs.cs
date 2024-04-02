using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[CreateAssetMenu(menuName = "Génération/Pièce")]
public class RoomPrefabs : ScriptableObject
{
    public BiomePrefabs biome;

    public float spawnRate;
    public GameObject floorPrefab;

    public RoomPrefabs[] allowedNeighbours;
    public int[] allowedNeighbourPosition;


}
