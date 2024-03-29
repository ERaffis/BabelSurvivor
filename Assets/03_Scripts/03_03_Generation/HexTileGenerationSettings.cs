using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "TileGen/GenerationSettings")]
public class HexTileGenerationSettings : ScriptableObject
{
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
        Room_Empty
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
    [LabelText("Spawn Rate")] [ShowIf("Rooms", TileType.Room_Empty)] public float roomEmpty_chanche;
    [LabelText("Prefab")] [ShowIf("Rooms", TileType.Room_Empty)] public GameObject roomEmpty;
    
    public GameObject GetTile(TileType tileType)
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
            case TileType.Room_Empty:
                return roomEmpty;
        }

        return null;
    }
    
    
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
    
    
}
