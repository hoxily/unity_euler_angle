using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiStepEulerAnglePacked : MonoBehaviour
{
    public Transform source;

    public BaseRotator[] rotateOrders;

    private void Update()
    {
        transform.localRotation = Quaternion.identity;
        foreach (var r in rotateOrders)
        {
            r.RotateBy(source, transform);
        }
    }
}
