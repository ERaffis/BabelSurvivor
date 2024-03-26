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

