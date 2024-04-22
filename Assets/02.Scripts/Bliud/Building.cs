using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int buildingKind;         // 이걸로 building 종류 선택

    public int gridX;
    public int gridZ;

    public void takeX(int x)
    {
        gridX = x;
    }

    public void takeZ(int z)
    {
        gridZ = z;
    }
}
