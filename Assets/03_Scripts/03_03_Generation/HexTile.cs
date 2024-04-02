using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[ExecuteInEditMode]
public class HexTile : MonoBehaviour
{
    public BiomePrefabs settings;
    public BiomePrefabs.TileType tileType;
    public BiomePrefabs.TileType previousTileType = BiomePrefabs.TileType.Room_22;

    public GameObject tile;

    public GameObject fow;

    public Vector2Int offsetCoordinate;
    public Vector3Int cubeCoordinate;

    public List<HexTile> neighbours;
    public bool hasNeighbourNE, hasNeighbourE, hasNeighbourSE, hasNeighbourSO, hasNeighbourO, hasNeighbourNO;
    public HexTile neighbourNE, neighbourE, neighbourSE, neighbourSO, neighbourO, neighbourNO;

    public bool isDisconnected = false;
    
    private bool isDirty = false;

    private void OnValidate()
    {
        if(tile == null) {return;}

        isDirty = true;
    }

    private void Update()
    {
        if (isDirty)
        {
            if (Application.isPlaying)
            {
                GameObject.Destroy(tile);
            }
            else
            {
                GameObject.DestroyImmediate(tile);
            }
            
            AddTile();
            isDirty = false;
        }
    }

    public void RollTileType()
    {
        tileType = (BiomePrefabs.TileType)Random.Range(0, Enum.GetNames(typeof(BiomePrefabs.TileType)).Length);
    }

    public void AddTile()
    {

        
        GameObject tilePrefab = settings.GetTile(tileType, previousTileType);
        previousTileType = tileType;
        
        tile = GameObject.Instantiate(tilePrefab,transform);
        /*if (gameObject.GetComponent<MeshCollider>() == null)
        {
            MeshCollider collider = gameObject.AddComponent<MeshCollider>();
            collider.sharedMesh = GetComponent<MeshFilter>().mesh;
        }*/
    }

    public void DestroyTile()
    {
        DestroyImmediate(gameObject,true);
    }

    public void OnDrawGizmosSelected()
    {
        
        foreach (HexTile neighbour in neighbours)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 5f);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, neighbour.transform.position);
        }
    }
}
