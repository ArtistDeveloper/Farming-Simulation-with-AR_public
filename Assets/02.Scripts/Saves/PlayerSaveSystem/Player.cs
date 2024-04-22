using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    
    public int HealthPoint = 1;
    public float AttackPoint = 0.5f; 

    public void SavePlayer(){
        PlayerSaveManager.Save(GameObject.FindObjectsOfType<Player>());
    }

    public void LoadPlayer(){
        Debug.Log("LoadPlayer 실행");
        AllPlayersData save = PlayerSaveManager.Load();
        //Player player = GameObject.FindObjectOfType<Player>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //태그 해줘야함! - 어려운거 아니니까 까먹지 말쟈~!

        Debug.Log(save.playerSaveDatas.Length); //4
        Debug.Log(players.Length);      //3(SaveManager != Player)
         //여기가 Vector3 pos파트임.
         for(int i=save.playerSaveDatas.Length-1; i>=0; i--){
            //Player[] playerSpawns = new Player[save.playerSaveDatas.Length];
            Vector3 position;
            position.x = save.playerSaveDatas[i].x;
            position.y = save.playerSaveDatas[i].y;
            position.z = save.playerSaveDatas[i].z;
            players[i].transform.position = position;

            Quaternion rotate = Quaternion.identity;
            rotate.eulerAngles = new Vector3(save.playerSaveDatas[i].rotateX, save.playerSaveDatas[i].rotateY, save.playerSaveDatas[i].rotateZ);
            players[i].transform.rotation = rotate;
         }
    }
    

}
