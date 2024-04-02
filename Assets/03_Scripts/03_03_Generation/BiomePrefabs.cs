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
    
    [TitleGroup("Pièces")]
    public enum TileType
    {
        Room_1,
        Room_2,
        Room_3,
        Room_4,
        Room_5,
        Room_6,
        Room_7,
        Room_8,
        Room_9,
        Room_10,
        Room_11,
        Room_12,
        Room_13,
        Room_14,
        Room_15,
        Room_16,
        Room_17,
        Room_18,
        Room_19,
        Room_20,
        Room_21,
        Room_22,
        Room_Empty
    } 
    
    public enum BiomeType
    {
        Biome_1,
    } 
    
    [EnumPaging] public TileType Rooms;

    
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_1)] public float room1_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_1)] public GameObject room1;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_2)] public float room2_chanche;
    [LabelText("Prefab")] [ShowIf("Rooms", TileType.Room_2)] public GameObject room2;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_3)] public float room3_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_3)] public GameObject room3;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_4)] public float room4_chanche;
    [LabelText("Prefab")] [ShowIf("Rooms", TileType.Room_4)] public GameObject room4;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_5)] public float room5_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_5)] public GameObject room5;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_6)] public float room6_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_6)] public GameObject room6;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_7)] public float room7_chanche;
    [LabelText("Prefab")] [ShowIf("Rooms", TileType.Room_7)] public GameObject room7;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_8)] public float room8_chanche;
    [LabelText("Prefab")] [ShowIf("Rooms", TileType.Room_8)] public GameObject room8;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_9)] public float room9_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_9)] public GameObject room9;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_10)] public float room10_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_10)] public GameObject room10;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_11)] public float room11_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_11)] public GameObject room11;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_12)] public float room12_chanche;
    [LabelText("Prefab")] [ShowIf("Rooms", TileType.Room_12)] public GameObject room12;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_13)] public float room13_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_13)] public GameObject room13;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_14)] public float room14_chanche;
    [LabelText("Prefab")] [ShowIf("Rooms", TileType.Room_14)] public GameObject room14;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_15)] public float room15_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_15)] public GameObject room15;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_16)] public float room16_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_16)] public GameObject room16;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_17)] public float room17_chanche;
    [LabelText("Prefab")] [ShowIf("Rooms", TileType.Room_17)] public GameObject room17;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_18)] public float room18_chanche;
    [LabelText("Prefab")] [ShowIf("Rooms", TileType.Room_18)] public GameObject room18;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_19)] public float room19_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_19)] public GameObject room19;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_20)] public float room20_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_20)] public GameObject room20;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_21)] public float room21_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_21)] public GameObject room21;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_22)] public float room22_chanche;
    [LabelText("Prefab")][ShowIf("Rooms", TileType.Room_22)] public GameObject room22;
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_Empty)] public float roomEmpty_chanche;
    [LabelText("Prefab")] [ShowIf("Rooms", TileType.Room_Empty)] public GameObject roomEmpty;
    
    public GameObject GetTile(TileType tileType, TileType previousTile)
    {
        switch (tileType)
        {
            case TileType.Room_1:
                return room1;
            case TileType.Room_2:
                return room2;
            case TileType.Room_3:
                return room3;
            case TileType.Room_4:
                return room4;
            case TileType.Room_5:
                return room5;
            case TileType.Room_6:
                return room6;
            case TileType.Room_7:
                return room7;
            case TileType.Room_8:
                return room8;
            case TileType.Room_9:
                return room9;
            case TileType.Room_10:
                return room10;
            case TileType.Room_11:
                return room11;
            case TileType.Room_12:
                return room12;
            case TileType.Room_13:
                return room13;
            case TileType.Room_14:
                return room14;
            case TileType.Room_15:
                return room15;
            case TileType.Room_16:
                return room16;
            case TileType.Room_17:
                return room17;
            case TileType.Room_18:
                return room18;
            case TileType.Room_19:
                return room19;
            case TileType.Room_20:
                return room20;
            case TileType.Room_21:
                return room21;
            case TileType.Room_22:
                return room22;
            case TileType.Room_Empty:
                return roomEmpty;
        }

        return null;
    }

    public GameObject RoomSpawner(RoomPrefabs previousRoom)
    {
        foreach (RoomPrefabs room in roomPrefabs)
        {
            if (Random.value <= room.spawnRate)
            {
                foreach (RoomPrefabs allowedNeighbours in previousRoom.allowedNeighbours)
                {
                    if (room == allowedNeighbours)
                    {
                        return room.floorPrefab;
                    }
                }
            }
        }

        return roomPrefabs[0].floorPrefab;
    }
    
    public void RollTileType()
    {
        TileType tileType = (BiomePrefabs.TileType)Random.Range(0, Enum.GetNames(typeof(BiomePrefabs.TileType)).Length);
    }
    
    /*
    [TitleGroup("Corridor")]
    public enum CorridorType
    {
        Corridor_E_O,
        Corridor_NE_SO,
        Corridor_NO_SE
    }
    [EnumPaging] public CorridorType Corridors;
    [TabGroup("Corridor/Split/Tile Prefabs","Corridor Prefabs")]
    [ShowIf("Corridors", CorridorType.Corridor_E_O)]public GameObject corridor_E_O;
    [TabGroup("Corridor/Split/Tile Prefabs","Corridor Prefabs")]
    [ShowIf("Corridors", CorridorType.Corridor_NE_SO)]public GameObject corridor_NE_SO;
    [TabGroup("Corridor/Split/Tile Prefabs","Corridor Prefabs")]
    [ShowIf("Corridors", CorridorType.Corridor_NO_SE)]public GameObject corridor_NO_SE;
    */
    
}
