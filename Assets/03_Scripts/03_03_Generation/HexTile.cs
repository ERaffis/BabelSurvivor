using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[ExecuteInEditMode]
public class HexTile : MonoBehaviour
{
    public BiomePrefabs settings;
    public RoomPrefabs tileType;
    
    public GameObject tile;

    public GameObject fow;

    public Vector2Int offsetCoordinate;
    public Vector3Int cubeCoordinate;

    public List<HexTile> neighbours;
    public bool hasNeighbourNE, hasNeighbourE, hasNeighbourSE, hasNeighbourSO, hasNeighbourO, hasNeighbourNO;
    public HexTile neighbourNE, neighbourE, neighbourSE, neighbourSO, neighbourO, neighbourNO;
    
    
    public GameObject doorNE, doorE, doorSE, doorSO, doorO, doorNO;
    
    private bool isDirty = false;

    private void OnValidate()
    {
        if(tile == null) {return;}

        isDirty = true;
    }

    /*private void Update()
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
            
            AddTile(settings.roomPrefabs[0].floorPrefab);
            isDirty = false;
        }
    }
    */

    public void RollTileType()
    {
        RoomPrefabs room = settings.SpawnFloor();
        tileType = room;
        AddTile(room.floorPrefab);
    }
    public void AddTile(GameObject roomPrefab)
    {
        GameObject tilePrefab = roomPrefab;
        tile = Instantiate(tilePrefab,transform);
        GetDoor();
    }

    public void DestroyTile()
    {
        DestroyImmediate(gameObject,true);
    }

    // public void OnDrawGizmosSelected()
    // {
        
    //     foreach (HexTile neighbour in neighbours)
    //     {
    //         Gizmos.color = Color.blue;
    //         Gizmos.DrawSphere(transform.position, 5f);
    //         Gizmos.color = Color.white;
    //         Gizmos.DrawLine(transform.position, neighbour.transform.position);
    //     }
    // }


    public void RespawnTile()
    {
        foreach (Transform child  in gameObject.transform)
        {
            DestroyImmediate(child.gameObject);
        }
        
        tileType = settings.basicRoom;
        AddTile(tileType.floorPrefab);
    }

    public void GetDoor()
    {
        doorNE = transform.Find(tileType.floorPrefab.name+"(Clone)/Walls/DR_BOT_NE").gameObject;
        doorE = transform.Find(tileType.floorPrefab.name+"(Clone)/Walls/DR_BOT_E").gameObject;
        doorSE = transform.Find(tileType.floorPrefab.name+"(Clone)/Walls/DR_BOT_SE").gameObject;
        doorSO = transform.Find(tileType.floorPrefab.name+"(Clone)/Walls/DR_BOT_SO").gameObject;
        doorO = transform.Find(tileType.floorPrefab.name+"(Clone)/Walls/DR_BOT_O").gameObject;
        doorNO = transform.Find(tileType.floorPrefab.name+"(Clone)/Walls/DR_BOT_NO").gameObject;
    }

    public void SetDoor(String door)
    {
        switch (door)
        {
            case "NE":
                doorNE.SetActive(true);
                break;
            case "E":
                doorE.SetActive(true);
                break;
            case "SE":
                doorSE.SetActive(true);
                break;
            case "SO":
                doorSO.SetActive(true);
                break;
            case "O":
                doorO.SetActive(true);
                break;
            case "NO":  
                doorNO.SetActive(true);
                break;
        }
    }
}
