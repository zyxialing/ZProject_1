using UnityEngine;
using System.Collections;

public class ZPhysics
{
    public static bool CheckBox(Vector3 targetPivot1,Vector3 size1,Vector3 targetPivot2,Vector3 size2)
    {
        //坐标检测（当两个物体的x、y、z方向间距都小于两个物体在该方向上的长度）
        if ((Mathf.Abs(targetPivot1.x - targetPivot2.x) <= size1.x / 2 + size2.x / 2) &&
            (Mathf.Abs(targetPivot1.y - targetPivot2.y) <= size1.y / 2 + size2.y / 2) &&
            (Mathf.Abs(targetPivot1.z - targetPivot2.z) <= size1.z / 2 + size2.z / 2))
        {
            return true;
        }
        return false;
    }

    public static bool CheckBox(ZBoxTrigger obj1, ZBoxTrigger obj2)
    {
        Vector3 targetPivot1 = obj1.transform.position + obj1.Center;
        Vector3 targetPivot2 = obj2.transform.position + obj1.Center;
        Vector3 size1 = obj1.Size;
        Vector3 size2 = obj2.Size;
        //坐标检测（当两个物体的x、y、z方向间距都小于两个物体在该方向上的长度）
        if ((Mathf.Abs(targetPivot1.x - targetPivot2.x) <= size1.x / 2 + size2.x / 2) &&
            (Mathf.Abs(targetPivot1.y - targetPivot2.y) <= size1.y / 2 + size2.y / 2) &&
            (Mathf.Abs(targetPivot1.z - targetPivot2.z) <= size1.z / 2 + size2.z / 2))
        {
            return true;
        }
        return false;
    }
}
