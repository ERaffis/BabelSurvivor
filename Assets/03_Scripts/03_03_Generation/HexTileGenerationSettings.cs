using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TileGen/GenerationSettings")]
public class HexTileGenerationSettings : ScriptableObject
{
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
        Room_Empty,
        //Corridor_E_O,
        //Corridor_NE_SO,
        //Corridor_NO_SE
    }

    public TileType tiles;

    public void AddTileType()
    {
        
    }
    public void RemoveTileType()
    {
        
    }

    public float[] tileChanches = new float[Enum.GetNames(typeof(TileType)).Length];
    
    public GameObject[] tilePrefabs = new GameObject[Enum.GetNames(typeof(TileType)).Length];
    public GameObject[] corridorPrefabs = new GameObject[3];

    public GameObject GetTile(TileType tileType)
    {
        switch (tileType)
        {
            case TileType.Room_1:
                return tilePrefabs[0];
            case TileType.Room_2:
                return tilePrefabs[1];
            case TileType.Room_3:
                return tilePrefabs[2];
            case TileType.Room_4:
                return tilePrefabs[3];
            case TileType.Room_5:
                return tilePrefabs[4];
            case TileType.Room_6:
                return tilePrefabs[5];
            case TileType.Room_7:
                return tilePrefabs[6];
            case TileType.Room_8:
                return tilePrefabs[7];
            case TileType.Room_9:
                return tilePrefabs[8];
            case TileType.Room_10:
                return tilePrefabs[9];
            case TileType.Room_Empty:
                return tilePrefabs[10];
            /*
            case TileType.Corridor_E_O:
                return Corridor_E_O;
            case TileType.Corridor_NE_SO:
                return Corridor_NE_SO;
            case TileType.Corridor_NO_SE:
                return Corridor_NO_SE;
            */
        }

        return null;
    }
}
