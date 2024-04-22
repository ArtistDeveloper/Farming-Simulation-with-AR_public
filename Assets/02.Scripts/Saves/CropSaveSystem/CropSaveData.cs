using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//얘가 Data로 치면 된다.
[System.Serializable]
public class CropSaveData
{
   //시간
   public int remainGrowTimeSave;
   public bool witherOrGather; 
   public string cropname;

   public CropSaveData(CropGrowTime B){
      //시간 저장
      remainGrowTimeSave = B.remainGrowTime;
      witherOrGather = B.witherOrGather;
      cropname =  B.name;
   }
}
