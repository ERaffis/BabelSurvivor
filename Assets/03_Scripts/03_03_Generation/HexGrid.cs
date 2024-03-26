using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [Header("Grid Settings")] 
    public Vector2Int gridSize;
    [Tooltip("Taille d'une pièce")] public float size = 1f;
    public HexTileGenerationSettings settings;

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
    
    public void LayoutGrid()
    {
        Clear();
        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                GameObject tile = new GameObject($"Hex {x},{y}");

                HexTile hextile = tile.AddComponent<HexTile>();
                hextile.settings = settings;
                hextile.RollTileType();
                hextile.AddTile();
                
                //Assign its offset coordinates for human parsing (Colum, Row)
                hextile.offsetCoordinate = new Vector2Int(x, y);
                
                //Assing/convert these to cube coordinates for navigation
                //hextile.cub

                hextile.transform.position = GetPositionForHexFromCoordinates(hextile.offsetCoordinate);
                tile.transform.parent = this.transform;
            }
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

        xPosition = (column * (horizontalDistance)) + offset;
        yPosition = (row * verticalDistance);
        
        return new Vector3(xPosition,0,-yPosition);
    }

}
