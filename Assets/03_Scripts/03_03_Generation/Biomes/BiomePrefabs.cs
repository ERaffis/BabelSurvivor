using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Génération/Biome")]
public class BiomePrefabs : ScriptableObject
{
    public RoomPrefabs[] roomPrefabs;
    public RoomPrefabs basicRoom;
    
    public RoomPrefabs SpawnFloor()
    {
        foreach (RoomPrefabs room in roomPrefabs)
        {
            if (Random.value <= room.spawnRate / 100) 
            {
                return room;
            }
        }

        return roomPrefabs[0];
    }
   
}
