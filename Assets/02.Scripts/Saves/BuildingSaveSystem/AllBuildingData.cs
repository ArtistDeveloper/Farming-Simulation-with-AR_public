using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AllBuildingData
{
    public BuildingSaveData[] buildingSaveDatas;
    
    public AllBuildingData(BuildingSaveData[] buildingSaveDatas){
        this.buildingSaveDatas = buildingSaveDatas;
    }
}
