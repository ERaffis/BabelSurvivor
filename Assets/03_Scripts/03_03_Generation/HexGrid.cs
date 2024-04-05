using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;

public class HexGrid : MonoBehaviour
{
    [Header("Grid Settings")] 
    public Vector2Int gridSize;
    [Tooltip("Taille d'une pièce")] public float size = 1f;
    public BiomePrefabs settings;

    public float startX;
    public float startY;

    public delegate void LayoutEvents();
    public static event LayoutEvents OnLayoutFinished;

    public void Clear()
    {
        List<GameObject> children = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            children.Add(child);
        }

        foreach (var child in children)
        {
            DestroyImmediate(child,true);
        }

    }

    private void Start()
    {
        LayoutGrid();
    }

    [Button("Generate Layout")]
    public void LayoutGrid()
    {
        if (GetComponent<MeshFilter>().sharedMesh !=null)
        {
            GetComponent<TileMeshCombiner>().ClearMesh();
        }
        Clear();
        for (int y = 0; y < gridSize.y; y++)
        {   
            if (y % 2 == 0)
            {
                for (int x = 0; x < gridSize.x; x++)
                {
                    
                        GameObject tile = new GameObject($"Hex {x},{y}");

                        HexTile hextile = tile.AddComponent<HexTile>();
                        
                        hextile.settings = settings;
                        hextile.RollTileType();
                        
                        if (hextile.tileType.isEmptyRoom)
                        {
                            DestroyImmediate(tile);
                        }
                        else
                        {
                            //Assign its offset coordinates for human parsing (Colum, Row)
                            hextile.offsetCoordinate = new Vector2Int(x, y);
                    
                            //Assing/convert these to cube coordinates for navigation
                            hextile.cubeCoordinate = OffsetToCube(hextile.offsetCoordinate);

                            hextile.transform.position = GetPositionForHexFromCoordinates(hextile.offsetCoordinate);
                            tile.transform.parent = this.transform;
                        }
                }
            }
            else
            {
                for (int x = 0; x < gridSize.x + 1; x++)
                {
                    
                    GameObject tile = new GameObject($"Hex {x},{y}");

                    HexTile hextile = tile.AddComponent<HexTile>();
                    hextile.settings = settings;
                    hextile.RollTileType();
                    
                    if (hextile.tileType.isEmptyRoom)
                    {
                        DestroyImmediate(tile);
                    }
                    else
                    {
                        
                        //Assign its offset coordinates for human parsing (Colum, Row)
                        hextile.offsetCoordinate = new Vector2Int(x, y);
                    
                        //Assing/convert these to cube coordinates for navigation
                        hextile.cubeCoordinate = OffsetToCube(hextile.offsetCoordinate);

                        hextile.transform.position = GetPositionForHexFromCoordinates(hextile.offsetCoordinate);
                        tile.transform.parent = this.transform;
                    }
                }
            }
        }
        
        TileManager tileManager = GetComponent<TileManager>();
        //Check here all the connections to see if problems
        if (OnLayoutFinished != null)
        {
            OnLayoutFinished();
        }
        

        /*Cette ligne doit être présente pour l'instant car je test la génération sans être en play mode. Si on est en play mode le if juste au dessus fait la bonne chose*/
        if (!EditorApplication.isPlaying)
        {
            tileManager.CalculateNeighbours();
            tileManager.CheckForConnection();
        }

        
        
        

    }

    public Vector3 GetPositionForHexFromCoordinates(Vector2Int coords)
    {
        int column = coords.x;
        int row = coords.y;
        float width;
        float height;
        float xPosition;
        float yPosition;
        bool shouldOffset;
        float horizontalDistance;
        float verticalDistance;
        float offset;

        shouldOffset = (row % 2) == 0;
        width = (float) Math.Sqrt(3) * size/2;
        height = size;

        horizontalDistance = width;
        verticalDistance = height * (3f / 4f);

        offset = (shouldOffset) ? width / 2 : 0;

        xPosition = (column * (horizontalDistance)) + offset + startX;
        yPosition = (row * verticalDistance) + startY;
        
        return new Vector3(xPosition,0,-yPosition);
    }

    public static Vector3Int OffsetToCube(Vector2Int offset)
    {
        var q = offset.x - (offset.y + (offset.y % 2)) / 2;
        var r = offset.y;
        return new Vector3Int(q, r, -q - r);
    }
}
