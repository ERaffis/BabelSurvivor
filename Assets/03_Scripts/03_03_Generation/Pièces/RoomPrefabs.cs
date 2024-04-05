using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[CreateAssetMenu(menuName = "Génération/Pièce")]
public class RoomPrefabs : ScriptableObject
{
    public BiomePrefabs biome;

    [Tooltip("Chande d'être sélectionné (%)")]
    public float spawnRate;
    public bool isEmptyRoom;
   
    [DisableIf("isEmptyRoom")][PreviewField(ObjectFieldAlignment.Left)]
    public GameObject floorPrefab;

   
    
    //public RoomPrefabs[] allowedNeighbours;
    public bool connectionNE,connectionE,connectionSE,connectionSO,connectionO,connectionNO;


}
