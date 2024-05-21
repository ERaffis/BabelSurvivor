using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
//Script pour combiner les mesh ensemble. Pour l'instant ça combine seulement les planchers et pas de la manière la plus optimisée. Il faut modifier quelques trucs et ajouter les murs.
public class TileMeshCombiner : MonoBehaviour
{

    public List<MeshFilter> meshFilters;

    [HorizontalGroup("Split", 0.5f)]
    [Button("Combine Floor Mesh")]
    public void Awake()
    {
        HexGrid.OnLayoutFinished  += CombineMesh;
    }

    public void CombineMesh()
    {
        ClearMesh();

        meshFilters = new List<MeshFilter>();
        
        MeshFilter[] meshChildren;

        meshChildren = GetComponentsInChildren<MeshFilter>();

        
        for (int i = 0; i < meshChildren.Length; i++)
        {
            if (meshChildren[i].gameObject.name.Contains("FL_"))
            {
                meshFilters.Add(meshChildren[i]);
                meshChildren[i].gameObject.SetActive(false);
            }
        }
        
        CombineInstance[] combine = new CombineInstance[meshFilters.Count];
        
        int j = 0;
        foreach (MeshFilter meshFilter in meshFilters)
        {
            combine[j].mesh = meshFilters[j].sharedMesh;
            combine[j].transform = meshFilters[j].transform.localToWorldMatrix;
            meshFilters[j].gameObject.SetActive(false);
            j++;
        }
        

        Mesh mesh = new Mesh();
        mesh.CombineMeshes(combine,true,true);
        mesh.name = "Combined_Floor";
        transform.GetComponent<MeshFilter>().sharedMesh = mesh;
        transform.gameObject.SetActive(true);
        
        GetComponent<MeshCollider>().sharedMesh = transform.GetComponent<MeshFilter>().sharedMesh;
    }
    
    
    [HorizontalGroup("Split", 0.5f)]
    [Button("Clear Floor Mesh")]
    public void ClearMesh()
    {

        transform.GetComponent<MeshFilter>().sharedMesh = null;
        transform.gameObject.SetActive(true);
        meshFilters.Clear();

        GetComponent<MeshCollider>().sharedMesh = null;
        transform.GetComponent<MeshFilter>().sharedMesh = null;
        
    }
}
