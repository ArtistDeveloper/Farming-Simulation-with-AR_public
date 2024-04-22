using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AllPlayersData
{
    public PlayerSaveData[] playerSaveDatas;

    public AllPlayersData(PlayerSaveData[] playerSaveDatas){
        this.playerSaveDatas = playerSaveDatas;
    }
}