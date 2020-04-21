using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRotator : ScriptableObject
{
    public Space space;

    public abstract void RotateBy(Transform source, Transform target);
}
