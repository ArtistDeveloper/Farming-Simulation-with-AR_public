using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//얘가 Data로 치면 된다.
[System.Serializable]
public class FarmSaveData
{
   //현재 저장하는 Data - 위치, 파괴가 되었는지 아닌지(Crop이 다 재배되었는지 아닌지.)
   //
   // public float[] position;
   // public float x;
   // public float y;
   // public float z;

   public int gridX;
   public int gridZ;

   public bool isDistroy;
   public int saveFarmKindNumber;

   public float[] rotate;
   public float rotateX;
   public float rotateY;
   public float rotateZ;
   
   public FarmSaveData(Farm B){
      // //위치
      // x = B.transform.position.x;
      // y = B.transform.position.y;
      // z = B.transform.position.z;

      // position = new float[3];
      // position[0] = x;
      // position[1] = y;
      // position[2] = z;

      //grid 위치 저장.
      gridX = B.gridX;
      gridZ = B.gridZ;

      //각도
      rotateX  = B.transform.eulerAngles.x;
      rotateY = B.transform.eulerAngles.y;
      rotateZ = B.transform.eulerAngles.z;

      rotate = new float[3];
      rotate[0] = rotateX;
      rotate[1] = rotateY;
      rotate[2] = rotateZ;

      isDistroy = B.isDistroy;
      saveFarmKindNumber = B.saveFarmKindNumber;
   }
}
