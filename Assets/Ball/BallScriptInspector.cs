using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BallScript))]
public class BallScriptInspector : Editor
{
    void OnSceneGUI()
    {
        BallScript bs = (BallScript)target;
        Handles.color = UnityEngine.Color.red;
        Handles.DrawLine(bs.gameObject.transform.position, (bs.gameObject.transform.position + bs.Direction * bs.Speed));
    }
}
