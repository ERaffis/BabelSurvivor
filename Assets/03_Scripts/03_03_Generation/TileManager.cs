using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Permet de trouver les voisins d'une tuile
public class TileManager : MonoBehaviour
{
    public TileManager instance;
    public Dictionary<Vector3Int, HexTile> tiles;
    public HexTile[] hexTiles;
    private void Awake()
    {
        instance = this;
        tiles = new Dictionary<Vector3Int, HexTile>{};

        HexTile[] hexTiles = gameObject.GetComponentsInChildren<HexTile>();
        
        foreach(HexTile hexTile in hexTiles)
        {
            RegisterTile(hexTile);
        }
        foreach(HexTile hexTile in hexTiles)
        {
            List<HexTile> neighbours = GetNeighbours(hexTile);
            hexTile.neighbours = neighbours;
        }
    }

    public void CalculateNeighbours()
    {
        instance = this;
        tiles = new Dictionary<Vector3Int, HexTile>{};
        
        hexTiles = gameObject.GetComponentsInChildren<HexTile>();
        
        foreach(HexTile hexTile in hexTiles)
        {
            RegisterTile(hexTile);
        }
        foreach(HexTile hexTile in hexTiles)
        {
            List<HexTile> neighbours = GetNeighbours(hexTile);
            hexTile.neighbours = neighbours;
        }
    }

    public void RegisterTile(HexTile tile)
    {
        tiles.Add(tile.cubeCoordinate, tile);
    }
    
    private List<HexTile> GetNeighbours(HexTile tile)
    {
        List<HexTile> neighbours = new List<HexTile>();

        Vector3Int[] neighbourCoords = new Vector3Int[]
        {
            new Vector3Int(1, -1, 0),
            new Vector3Int(1, 0, -1),
            new Vector3Int(0, 1, -1),
            new Vector3Int(-1, 1, 0),
            new Vector3Int(-1, 0, 1),
            new Vector3Int(0, -1, 1),
        };

        foreach (Vector3Int neighbourCoord in neighbourCoords)
        {
            Vector3Int tileCoord = tile.cubeCoordinate;

            if (tiles.TryGetValue(tileCoord + neighbourCoord, out HexTile neighbour))
            {
                neighbours.Add(neighbour);
                
                if (neighbourCoord == new Vector3Int(1, -1, 0))
                {
                    tile.hasNeighbourNE = true;
                    tile.neighbourNE = neighbour;
                }
                else if (neighbourCoord == new Vector3Int(1, 0, -1))
                {
                    tile.hasNeighbourE = true;
                    tile.neighbourE = neighbour;
                }
                else if (neighbourCoord == new Vector3Int(0, 1, -1))
                {
                    tile.hasNeighbourSE = true;
                    tile.neighbourSE = neighbour;
                }
                else if (neighbourCoord == new Vector3Int(-1, 1, 0))
                {
                    tile.hasNeighbourSO = true;
                    tile.neighbourSO = neighbour;
                }
                else if (neighbourCoord == new Vector3Int(-1, 0, 1))
                {
                    tile.hasNeighbourO = true;
                    tile.neighbourO = neighbour;
                }
                else if (neighbourCoord == new Vector3Int(0, -1, 1))
                {
                    tile.hasNeighbourNO = true;
                    tile.neighbourNO = neighbour;
                }
                
            }
        }

        return neighbours;
    }
}
