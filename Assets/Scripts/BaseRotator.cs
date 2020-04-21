using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// X,Y,Z单分量的旋转。具体实现在子类里。
/// </summary>
public abstract class BaseRotator : ScriptableObject
{
    public Space space;

    public abstract void RotateBy(Transform source, Transform target);
}
