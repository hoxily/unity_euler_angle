using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 复制source的欧拉角，按照分级的x,y,z（顺序按照场景节点层级来）单步旋转。
/// 用于验证Unity文档里所说的欧拉角zxy顺序是什么意思。
/// </summary>
public class MultiStepEulerAngle : MonoBehaviour
{
    public Transform source;

    public Transform x;

    public Transform y;

    public Transform z;

    private void Update()
    {
        Vector3 sourceEulerAngles = source.localEulerAngles;
        x.localEulerAngles = new Vector3(sourceEulerAngles.x, 0, 0);
        y.localEulerAngles = new Vector3(0, sourceEulerAngles.y, 0);
        z.localEulerAngles = new Vector3(0, 0, sourceEulerAngles.z);
    }
}
