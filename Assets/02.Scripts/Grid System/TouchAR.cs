using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAR
{
    public static Vector3 GetWolrdTouchPosition3D()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            return hit.point;    
        else
            return Vector3.zero;
    }
}

