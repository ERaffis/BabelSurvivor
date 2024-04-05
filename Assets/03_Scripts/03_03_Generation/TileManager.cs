using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
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
        HexGrid.OnLayoutFinished  += CheckForConnection;
        HexGrid.OnLayoutFinished  += CalculateNeighbours;
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

    private void OnEnable()
    {
        HexGrid.OnLayoutFinished  += CheckForConnection;
        HexGrid.OnLayoutFinished  += CalculateNeighbours;
    }

    [Button("Calculate Neighbours")]
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
            if (hexTile.neighbours.Count == 0)
            {
                hexTile.DestroyTile();
            }
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
    
    [Button("Check For Connections")]
    public void CheckForConnection()
    {
        foreach (HexTile hexTile in hexTiles)
        {
            int i = 0;
            //Checking for connection NE
            if (hexTile.tileType.connectionNE)
            {
                if (hexTile.hasNeighbourNE)
                {
                    if (!hexTile.neighbourNE.tileType.connectionSO)
                    {
                        i++;
                        hexTile.SetDoor("NE");
                    }
                }
                else
                {
                    i++;
                    hexTile.SetDoor("NE");
                }
            }
            else
            {
                i++;
            }
            //Checking for connection E
            if (hexTile.tileType.connectionE)
            {
                if (hexTile.hasNeighbourE)
                {
                    if (!hexTile.neighbourE.tileType.connectionO)
                    {
                        i++;
                        hexTile.SetDoor("E");
                    }
                }
                else
                {
                    i++;
                    hexTile.SetDoor("E");
                }
            }
            else
            {
                i++;
            }
            //Checking for connection SE
            if (hexTile.tileType.connectionSE)
            {
                if (hexTile.hasNeighbourSE)
                {
                    if (!hexTile.neighbourSE.tileType.connectionNO)
                    {
                        i++;
                        hexTile.SetDoor("SE");
                    }
                }
                else
                {
                    i++;
                    hexTile.SetDoor("SE");
                }
            }
            else
            {
                i++;
            }
            //Checking for connection SO
            if (hexTile.tileType.connectionSO)
            {
                if (hexTile.hasNeighbourSO)
                {
                    if (!hexTile.neighbourSO.tileType.connectionNE)
                    {
                        i++;
                        hexTile.SetDoor("SO");
                    }
                }
                else
                {
                    i++;
                    hexTile.SetDoor("SO");
                }
            }
            else
            {
                i++;
            }
            //Checking for connection O
            if (hexTile.tileType.connectionO)
            {
                if (hexTile.hasNeighbourO)
                {
                    if (!hexTile.neighbourO.tileType.connectionE)
                    {
                        i++;
                        hexTile.SetDoor("O");
                    }
                }
                else
                {
                    i++;
                    hexTile.SetDoor("O");
                }
            }
            else
            {
                i++;
            }
            //Checking for connection NO
            if (hexTile.tileType.connectionNO)
            {
                if (hexTile.hasNeighbourNO)
                {
                    if (!hexTile.neighbourNO.tileType.connectionSE)
                    {
                        i++;
                        hexTile.SetDoor("NO");
                    }
                }
                else
                {
                    i++;
                    hexTile.SetDoor("NO");
                }
            }else
            {
                i++;
            }
            
            if (i == 6)
            {
                ChangeTile(hexTile);
                CheckForConnection();
            }
        }
    }

    public void ChangeTile(HexTile tile, HexTile neighbour)
    {
        Debug.Log("Should change " + tile + " because no connections at : " + neighbour);
    }
    public void ChangeTile(HexTile tile)
    {
        tile.RespawnTile();
    }
}
/*
            //version 1
            if (hexTile.neighbourNE != null)
            {
                if (hexTile.tileType.connectionNE) continue;
                if (hexTile.tileType.connectionNE != hexTile.neighbourNE.tileType.connectionSO)
                {
                    shouldChangeTile = true;
                }
                else
                {
                    return;
                }
            }
            if (hexTile.neighbourE != null)
            {
                if (hexTile.tileType.connectionE) continue;
                if (hexTile.tileType.connectionE != hexTile.neighbourE.tileType.connectionO)
                {
                    shouldChangeTile = true;
                }
                else
                {
                    return;
                }
            }
            if (hexTile.neighbourSE != null)
            {
                if (hexTile.tileType.connectionSE) continue;
                if (hexTile.tileType.connectionSE != hexTile.neighbourSE.tileType.connectionNO)
                {
                    shouldChangeTile = true;
                }
                else
                {
                    return;
                }
            }
            if (hexTile.neighbourSO != null)
            {
                if (hexTile.tileType.connectionSO) continue;
                if (hexTile.tileType.connectionSO != hexTile.neighbourSO.tileType.connectionNE)
                {
                    shouldChangeTile = true;
                }
                else
                {
                    return;
                }
            }
            if (hexTile.neighbourO != null)
            {
                if (hexTile.tileType.connectionO) continue;
                if (hexTile.tileType.connectionO != hexTile.neighbourO.tileType.connectionE)
                {
                    shouldChangeTile = true;
                }
                else
                {
                    return;
                }
            }
            if (hexTile.neighbourNO != null)
            {
                if (hexTile.tileType.connectionNO) continue;
                if (hexTile.tileType.connectionNO != hexTile.neighbourNO.tileType.connectionSE)
                {
                    shouldChangeTile = true;
                }
                else
                {
                    return;
                }
            }

            if (shouldChangeTile)
            {
                ChangeTile(hexTile);
            }
            
            //version 2 
            if (hexTile.hasNeighbourNE)
            {
                if (!hexTile.neighbourNE.tileType.connectionSO || !hexTile.tileType.connectionNE) shouldChangeTile = true;
                else return;
            }
            if (hexTile.hasNeighbourE)
            {
                if (!hexTile.neighbourE.tileType.connectionO || !hexTile.tileType.connectionE) shouldChangeTile = true;
                else return;
            }
            if (hexTile.hasNeighbourSE)
            {
                if (!hexTile.neighbourSE.tileType.connectionNO || !hexTile.tileType.connectionSE) shouldChangeTile = true;
                else return;
            }
            if (hexTile.hasNeighbourSO)
            {
                if (!hexTile.neighbourSO.tileType.connectionNE || !hexTile.tileType.connectionSO) shouldChangeTile = true;
                else return;
            }
            if (hexTile.hasNeighbourO)
            {
                if (!hexTile.neighbourO.tileType.connectionE || !hexTile.tileType.connectionO) shouldChangeTile = true;
                else return;
            }
            if (hexTile.hasNeighbourNO)
            {
                if (!hexTile.neighbourNO.tileType.connectionSE || !hexTile.tileType.connectionNO) shouldChangeTile = true;
                else return;
            }
            
            if (shouldChangeTile) ChangeTile(hexTile);
            
*/