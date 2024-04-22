using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AllCropsData
{
    public CropSaveData[] cropSaveDatas;

    public AllCropsData(CropSaveData[] cropSaveDatas){
        this.cropSaveDatas = cropSaveDatas;
    }
}