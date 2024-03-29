using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HexGrid))]
public class HexGridEditor : Editor
{
   public override void OnInspectorGUI()
   {
      DrawDefaultInspector();
      
      HexGrid hexGrid = (HexGrid)target;

      if (GUILayout.Button("Generate Layout"))
      {
         hexGrid.LayoutGrid();
      }
   }
}

[CustomEditor(typeof(TileManager))]
public class TileManagerEditor : Editor
{
   public override void OnInspectorGUI()
   {
      DrawDefaultInspector();
      
      TileManager tileManager = (TileManager)target;

      if (GUILayout.Button("Calculate Neighbours"))
      {
         tileManager.CalculateNeighbours();
      }
   }
}
[CustomEditor(typeof(TileMeshCombiner))]
public class TileMeshCombinerEditor : Editor
{
   public override void OnInspectorGUI()
   {
      DrawDefaultInspector();
      
      TileMeshCombiner tileMeshCombiner = (TileMeshCombiner)target;

      if (GUILayout.Button("Combine Meshes"))
      {
         tileMeshCombiner.CombineMesh();
      }
      
      if (GUILayout.Button("Clear Meshes"))
      {
         tileMeshCombiner.ClearMesh();
      }
   }
}

[CustomEditor(typeof(SpawnPlayer))]
public class SpawnPlayerEditor : Editor
{
   public override void OnInspectorGUI()
   {
      DrawDefaultInspector();
      
      SpawnPlayer spawnPlayer = (SpawnPlayer)target;

      if (GUILayout.Button("Place Player"))
      {
         spawnPlayer.PlacePlayerInLevel();
      }
   }
}

[CustomEditor(typeof(HexTileGenerationSettings))]
public class HexTileGenerationSettingsEditor : Editor
{
   public override void OnInspectorGUI()
   {
      DrawDefaultInspector();
      
      SpawnPlayer spawnPlayer = (SpawnPlayer)target;

      if (GUILayout.Button("Place Player"))
      {
         spawnPlayer.PlacePlayerInLevel();
      }
   }
}

