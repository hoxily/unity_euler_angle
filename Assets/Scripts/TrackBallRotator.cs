using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用鼠标拖动时，沿过中心点的任意方向的旋转轴的旋转操作。
/// </summary>
public class TrackBallRotator : MonoBehaviour
{
    public float rotateSpeed;

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.MouseDrag)
        {
            Vector3 delta = new Vector3(e.delta.x, -e.delta.y, 0);
            if (delta.sqrMagnitude <= 0)
            {
                return;
            }
            Debug.Log(delta);
            Quaternion fromYToX = Quaternion.FromToRotation(Vector3.up, Vector3.right);
            Vector3 axis = fromYToX * delta;
            transform.Rotate(axis, rotateSpeed * delta.magnitude, Space.World);
        }
    }
}
