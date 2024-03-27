using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class TileMeshCombiner : MonoBehaviour
{

    public List<MeshFilter> meshFilters;
    public void CombineMesh()
    {

        meshFilters = new List<MeshFilter>();
        MeshFilter[] meshChildren = GetComponentsInChildren<MeshFilter>();
        for (int i = 0; i < meshChildren.Length; i++)
        {
            if (meshChildren[i].gameObject.name == "Piece_Floor")
            {
                meshFilters.Add(meshChildren[i]);
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
        
        GetComponent<MeshCollider>().sharedMesh = null;
        GetComponent<MeshCollider>().sharedMesh = transform.GetComponent<MeshFilter>().sharedMesh;
    }

    public void ClearMesh()
    {
        transform.GetComponent<MeshFilter>().sharedMesh = null;
        transform.gameObject.SetActive(true);
        foreach (MeshFilter meshFilter in meshFilters)
        {
            meshFilter.gameObject.SetActive(true);
        }
        meshFilters.Clear();
        GetComponent<MeshCollider>().sharedMesh = null;
    }
}
