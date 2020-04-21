using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class YAxisRotator : BaseRotator
{
    public override void RotateBy(Transform source, Transform target)
    {
        float y = source.localEulerAngles.y;
        target.Rotate(0, y, 0, space);
    }
}
