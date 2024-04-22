using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AllFarmsData
{
    public FarmSaveData[] farmSaveDatas;

    public AllFarmsData(FarmSaveData[] farmSaveDatas){
        this.farmSaveDatas = farmSaveDatas;
    }
}