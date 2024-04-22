 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

// 참고 자료입니다.
//이게 SaveSystem

public static class PlayerSaveManager
{
    public static void Save(Player[] players){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "Player Save.bin ");
        FileStream stream =File.Create(path);

        //교체 사항
        PlayerSaveData[] playerSaveDatas = new PlayerSaveData[players.Length];
        for(int i = 0; i<players.Length; ++i){
            playerSaveDatas[i] = new PlayerSaveData(players[i]);
        }

        AllPlayersData data = new AllPlayersData(playerSaveDatas);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static AllPlayersData Load(){
        try{
         BinaryFormatter formatter = new BinaryFormatter();
         string path = Path.Combine(Application.persistentDataPath, "Player Save.bin");
         FileStream stream = File.OpenRead(path);
         AllPlayersData data = (AllPlayersData)formatter.Deserialize(stream);
         //AllPlayersData data = formatter.Deserialize(stream) as AllPlayersData;
         stream.Close();
         return data;
         }
         catch(Exception e){
             Debug.Log(e.Message);
             return default;
         }
     }

}
