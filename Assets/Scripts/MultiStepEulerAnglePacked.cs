using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiStepEulerAnglePacked : MonoBehaviour
{
    public Transform source;

    public BaseRotator[] rotateOrders;

    private bool CheckRotateOrders(out Space space)
    {
        space = Space.World;
        if (rotateOrders.Length != 3)
        {
            Debug.LogError("rotateOrders 需要三个旋转分量。");
            return false;
        }
        space = rotateOrders[0].space;
        for (int i = 1; i < 3; i++)
        {
            if (rotateOrders[i].space != space)
            {
                Debug.LogError("rotateOrders 的旋转的相对空间需要统一为World或者Self.");
                return false;
            }
        }
        int xAxisRotatorCount = 0;
        int yAxisRotatorCount = 0;
        int zAxisRotatorCount = 0;
        for (int i = 0; i < 3; i++)
        {
            if (rotateOrders[i] is XAxisRotator)
            {
                xAxisRotatorCount++;
            }
            if (rotateOrders[i] is YAxisRotator)
            {
                yAxisRotatorCount++;
            }
            if (rotateOrders[i] is ZAxisRotator)
            {
                zAxisRotatorCount++;
            }
        }
        if (xAxisRotatorCount != 1)
        {
            Debug.LogError("rotateOrders 中 XAxisRotator 类型分量出现次数不为1.");
            return false;
        }
        if (yAxisRotatorCount != 1)
        {
            Debug.LogError("rotateOrders 中 YAxisRotator 类型分量出现次数不为1.");
            return false;
        }
        if (zAxisRotatorCount != 1)
        {
            Debug.LogError("rotateOrders 中 ZAxisRotator 类型分量出现次数不为1.");
            return false;
        }
        return true;
    }

    /// <summary>
    /// 用于Space.World变换时的辅助节点。
    /// 相当于把连续的YXZ坐标系单独拿出来，放到世界坐标系下进行运算。
    /// 为什么需要单独拿到世界坐标系下，因为使用了Space.World呀。
    /// </summary>
    private Transform _helper;

    private Transform helper
    {
        get
        {
            if (_helper == null)
            {
                _helper = new GameObject("WorldSpaceRotateHelper").transform;
            }
            return _helper;
        }
    }

    /// <summary>
    /// 使用四元数来代替辅助Transform节点。
    /// </summary>
    public bool useQuaternionInsteadWhenWorldSpace;

    private void Update()
    {
        if (CheckRotateOrders(out Space space))
        {
            if (space == Space.World)
            {
                if (useQuaternionInsteadWhenWorldSpace)
                {
                    //注意for循环里q是左乘新的Quaternion。因为使用Quaternion变换向量时是 q * vector，
                    //而多个相邻的Quaternion可以压缩为一个：q3 * q2 * q1 * vector = (q3 * (q2 * q1)) * vector;
                    Quaternion q = Quaternion.identity;
                    foreach (var r in rotateOrders)
                    {
                        if (r is XAxisRotator)
                        {
                            q = Quaternion.Euler(source.localEulerAngles.x, 0, 0) * q;
                        }
                        else if (r is YAxisRotator)
                        {
                            q = Quaternion.Euler(0, source.localEulerAngles.y, 0) * q;
                        }
                        else if (r is ZAxisRotator)
                        {
                            q = Quaternion.Euler(0, 0, source.localEulerAngles.z) * q;
                        }
                    }
                    transform.localRotation = q;
                }
                else
                {
                    helper.localRotation = Quaternion.identity;
                    foreach (var r in rotateOrders)
                    {
                        r.RotateBy(source, helper);
                    }
                    transform.localRotation = helper.localRotation;
                }
            }
            else
            {
                transform.localRotation = Quaternion.identity;
                foreach (var r in rotateOrders)
                {
                    r.RotateBy(source, transform);
                }
            }
        }
    }
}
