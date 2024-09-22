using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    Waypoint Waypoint => target as Waypoint;

    private void OnSceneGUI()
    {
        Handles.color = Color.red;
        for (int i = 0; i < Waypoint.Pointes.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            // Create handles
            Vector3 currentWaypointPoint = Waypoint.CurrentPosition + Waypoint.Pointes[i];
            Vector3 newWaypointPoint = Handles.FreeMoveHandle(
                    position: currentWaypointPoint,
                    size: .7f,
                    snap: new Vector3(.3f, .3f, .3f),
                    Handles.SphereHandleCap
                );

            // Create index text
            GUIStyle textStyle = new GUIStyle();
            textStyle.fontStyle = FontStyle.Bold;
            textStyle.fontSize = 18;
            textStyle.normal.textColor = Color.yellow;
            Vector3 textAlligment = Vector3.down * .3f + Vector3.right * .3f;
            Handles.Label(position: Waypoint.CurrentPosition + Waypoint.Pointes[i] + textAlligment, text: $"{i}", textStyle);

            EditorGUI.EndChangeCheck();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free Move Handle");
                Waypoint.Pointes[i] = newWaypointPoint - Waypoint.CurrentPosition;
            }

        }
    }
}
