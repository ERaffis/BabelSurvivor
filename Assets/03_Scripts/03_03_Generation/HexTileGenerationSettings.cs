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
        //Corridor_E_O,
        //Corridor_NE_SO,
        //Corridor_NO_SE
    }
    
    public GameObject Room_1,Room_2,Room_3,Room_4,Room_5,Room_6,Room_7,Room_8,Room_9,Room_10;
    public GameObject Corridor_E_O,Corridor_NE_SO,Corridor_NO_SE ;

    public GameObject GetTile(TileType tileType)
    {
        switch (tileType)
        {
            case TileType.Room_1:
                return Room_1;
            case TileType.Room_2:
                return Room_2;
            case TileType.Room_3:
                return Room_3;
            case TileType.Room_4:
                return Room_4;
            case TileType.Room_5:
                return Room_5;
            case TileType.Room_6:
                return Room_6;
            case TileType.Room_7:
                return Room_7;
            case TileType.Room_8:
                return Room_8;
            case TileType.Room_9:
                return Room_9;
            case TileType.Room_10:
                return Room_10;
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
