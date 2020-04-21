using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class ZAxisRotator : BaseRotator
{
    public override void RotateBy(Transform source, Transform target)
    {
        float z = source.localEulerAngles.z;
        target.Rotate(0, 0, z, space);
    }
}
