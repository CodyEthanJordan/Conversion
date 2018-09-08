using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Assets.Scripts;

[CustomEditor(typeof(Liquid))]
// ^ This is the script we are making a custom editor for.
public class YourScriptEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Water"))
        {

        }
    }
}

