 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

// 참고 자료입니다.
//이게 SaveSystem

public static class FarmSaveManager
{
    public static void Save(Farm[] farms){
        

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "Farm Save.bin ");
        FileStream stream =File.Create(path);

        //교체 사항
        FarmSaveData[] farmSaveDatas = new FarmSaveData[farms.Length];
        for(int i = 0; i<farms.Length; ++i){            //되는 코드 -> int i = 0; i<farms.Length; ++i // 차이 없음 ->int i = farms.Length-1; i>=0; i--
            farmSaveDatas[i] = new FarmSaveData(farms[i]);
        }

        AllFarmsData data = new AllFarmsData(farmSaveDatas);
        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static AllFarmsData Load(){
        try{
         BinaryFormatter formatter = new BinaryFormatter();
         string path = Path.Combine(Application.persistentDataPath, "Farm Save.bin");
         FileStream stream = File.OpenRead(path);
         AllFarmsData data = (AllFarmsData)formatter.Deserialize(stream);

         stream.Close();
         return data;
         }
         catch(Exception e){
             Debug.Log(e.Message);
             return default;
         }
    }
}
