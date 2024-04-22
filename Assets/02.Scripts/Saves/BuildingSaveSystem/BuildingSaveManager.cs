using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class BuildingSaveManager : MonoBehaviour
{
    public static void Save(Building[] buildings){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "Building Save.bin");
        FileStream stream =File.Create(path);

        //교체 사항
        BuildingSaveData[] buildingSaveDatas = new BuildingSaveData[buildings.Length];
        for(int i = 0; i<buildings.Length; ++i){            //되는 코드 -> int i = 0; i<buildings.Length; ++i // 차이 없음 ->int i = buildings.Length-1; i>=0; i--
            buildingSaveDatas[i] = new BuildingSaveData(buildings[i]);
        }

        AllBuildingData data = new AllBuildingData(buildingSaveDatas);
        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static AllBuildingData Load(){
        try{
         BinaryFormatter formatter = new BinaryFormatter();
         string path = Path.Combine(Application.persistentDataPath, "Building Save.bin");
         FileStream stream = File.OpenRead(path);
         AllBuildingData data = (AllBuildingData)formatter.Deserialize(stream);
         stream.Close();
         return data;
         }
         catch(Exception e){
             Debug.Log(e.Message);
             return default;
         }
    }
}
