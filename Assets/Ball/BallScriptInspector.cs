using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
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
#endif
