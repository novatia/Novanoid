using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoUtility
{
    public static void DrawArrow(Vector3 pos, Vector3 direction,Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
        Color previous = Gizmos.color;

        Gizmos.color = color;

        Gizmos.DrawRay(pos, direction);

        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
        Gizmos.DrawRay(pos + direction, left * arrowHeadLength);

        Gizmos.color = previous;
    }

}
