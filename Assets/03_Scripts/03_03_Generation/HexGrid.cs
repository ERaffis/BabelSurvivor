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
    [LabelText("Taille de la grille")] public Vector2Int gridSize;
    [Tooltip("Taille d'une pièce")] [LabelText("Taille des tuiles")] public float size = 1f;
    [Tooltip("Biome utilisé pour la génération")] [LabelText("Biome")] public BiomePrefabs settings;

    [Tooltip("Coordoné x de la première tuile")] public float startX;
    [Tooltip("Coordoné y de la première tuile")] public float startY;


    [SerializeField] TileManager tileManager;
    [SerializeField] TileMeshCombiner tileMeshCombiner;

    public delegate void LayoutEvents();
    public static event LayoutEvents OnLayoutFinished;
    public static event LayoutEvents OnClearFinished;

    public void Awake()
    {

    }

    private void Start()
    {
        GenerateGrid();
    }

    [Button("Generate Grid")]
    public void GenerateGrid()
    {
        //Réinitialise la grille si elle a déjà été créée.
        ClearGrid();

        //Génération de la grille. Passe à travers toute les rangées (Y) et toute les colonnes (X) à l'intérieur
        for (int y = 0; y < gridSize.y; y++)
        {   
            for (int x = 0; x < gridSize.x; x++)
            {
                
                GameObject tile = new GameObject($"Tuile {x},{y}");

                HexTile hextile = tile.AddComponent<HexTile>();
                
                hextile.settings = settings;
                hextile.RollTileType();
                
                //Assign its offset coordinates for human parsing (Colum, Row)
                hextile.offsetCoordinate = new Vector2Int(x, y);
        
                //Assing/convert these to cube coordinates for navigation
                hextile.cubeCoordinate = OffsetToCube(hextile.offsetCoordinate);

                hextile.transform.position = GetPositionForHexFromCoordinates(hextile.offsetCoordinate);
                tile.transform.parent = this.transform;

            }
        }
        
        
        tileManager = GetComponent<TileManager>();
        tileMeshCombiner = GetComponent<TileMeshCombiner>();

        //Check here all the connections to see if problems
        if (OnLayoutFinished != null) OnLayoutFinished();
        

#if UNITY_EDITOR
        
           tileManager.CalculateNeighbours();
           tileManager.CheckForConnection();
           tileMeshCombiner.CombineMesh();
                  
#endif
    }


//     [Button("Generate Grid")]
//     public void LayoutGrid()
//     {
//         Clear();
//         for (int y = 0; y < gridSize.y; y++)
//         {   
//             if (y % 2 == 0)
//             {
//                 for (int x = 0; x < gridSize.x; x++)
//                 {
                    
//                         GameObject tile = new GameObject($"Tuile {x},{y}");

//                         HexTile hextile = tile.AddComponent<HexTile>();
                        
//                         hextile.settings = settings;
//                         hextile.RollTileType();
                        
//                         if (hextile.tileType.isEmptyRoom)
//                         {
//                             DestroyImmediate(tile);
//                         }
//                         else
//                         {
//                             Assign its offset coordinates for human parsing (Colum, Row)
//                             hextile.offsetCoordinate = new Vector2Int(x, y);
                    
//                             Assing/convert these to cube coordinates for navigation
//                             hextile.cubeCoordinate = OffsetToCube(hextile.offsetCoordinate);

//                             hextile.transform.position = GetPositionForHexFromCoordinates(hextile.offsetCoordinate);
//                             tile.transform.parent = this.transform;
//                         }
//                 }
//             }
//             else
//             {
//                 for (int x = 0; x < gridSize.x; x++)
//                 {
                    
//                     GameObject tile = new GameObject($"Tuile {x},{y}");

//                     HexTile hextile = tile.AddComponent<HexTile>();
//                     hextile.settings = settings;
//                     hextile.RollTileType();
                    
//                     if (hextile.tileType.isEmptyRoom)
//                     {
//                         DestroyImmediate(tile);
//                     }
//                     else
//                     {
                        
//                         Assign its offset coordinates for human parsing (Colum, Row)
//                         hextile.offsetCoordinate = new Vector2Int(x, y);
                    
//                         Assing/convert these to cube coordinates for navigation
//                         hextile.cubeCoordinate = OffsetToCube(hextile.offsetCoordinate);

//                         hextile.transform.position = GetPositionForHexFromCoordinates(hextile.offsetCoordinate);
//                         tile.transform.parent = this.transform;
//                     }
//                 }
//             }
//         }
        
        
//         tileManager = GetComponent<TileManager>();
//         tileMeshCombiner = GetComponent<TileMeshCombiner>();

//         Check here all the connections to see if problems
//         if (OnLayoutFinished != null) OnLayoutFinished();
        

// #if UNITY_EDITOR
        
//            tileManager.CalculateNeighbours();
//            tileManager.CheckForConnection();
//            tileMeshCombiner.CombineMesh();
                  
// #endif

//     }


    [Button("Clear Grid")]
    public void ClearGrid()
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

#if UNITY_EDITOR
        
           tileManager.ClearHexTiles();
                  
#endif

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
