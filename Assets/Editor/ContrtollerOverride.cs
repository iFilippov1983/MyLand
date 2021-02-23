using System.Collections;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(HeroCtrl))]
public class ContrtollerOverride : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("+Speed"))
        {
            
        }
        if (GUILayout.Button("-Speed"))
        {

        }

    }
}
