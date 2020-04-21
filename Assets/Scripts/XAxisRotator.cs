using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class XAxisRotator : BaseRotator
{
    public override void RotateBy(Transform source, Transform target)
    {
        float x = source.localEulerAngles.x;
        target.Rotate(x, 0, 0, space);
    }
}
