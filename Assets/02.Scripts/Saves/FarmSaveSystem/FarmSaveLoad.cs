using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class FarmSaveLoad : MonoBehaviour
{
    public GameObject farmPrefab;
    private AllFarmsData save;
    private int saveLength;
    void OnEnable(){       //원래 Awake
        Debug.Log("LoadFarm 시작.");
        LoadFarm();
        Debug.Log("LoadFarm 완료");
    }

    public void OnApplicationFocus(bool value){
        if(value){      //들어왔을 때 실행.
            //Debug.Log("Farm OnApplicationFocus true 실행");
            //LoadFarm();     //원래 친구 삭제 후 복사해서 놓음.
            //Debug.Log("Farm 로드");
        }else
        {
            //Debug.Log("Farm OnApplicationFocus false 실행");
            SaveFarm();
            //Debug.Log("Farm Save");
        }
    }

    public void OnApplicationQuit()
    {
        SaveFarm();
        //Debug.Log("Farm 저장 완료");
    }


    public void SaveFarm(){
        FarmSaveManager.Save(GameObject.FindObjectsOfType<Farm>());         //
        //Debug.Log("찾은 Farm의 개수"+GameObject.FindObjectsOfType<Farm>().Length);      //잘 됌.
    }

    public void LoadFarm(){
        save = FarmSaveManager.Load();
        GameObject[] farms = GameObject.FindGameObjectsWithTag("Farm");
        Debug.Log("Farm Load에서 찾은 Farm의 개수 - 복사하는 개수: " + farms.Length);
        Debug.Log("그럼 farm Load에 있는 save의 데이터 개수: "+ save.farmSaveDatas.Length);
        saveLength = farms.Length;

        
        //태그 해줘야함!
        //Debug.Log("Load for문 돌리는 길이: "+ save.farmSaveDatas.Length);
        for(int i=save.farmSaveDatas.Length-1; i>=0; i--){       //int i=0; i <= save.cropSaveDatas.Length -1; i++    //int i=save.farmSaveDatas.Length-1; i>=0; i--
            // Vector3 position;
            // position.x = save.farmSaveDatas[i].x;        //Mathf.Abs(i - save.farmSaveDatas.Length)
            // position.y = save.farmSaveDatas[i].y;
            // position.z = save.farmSaveDatas[i].z;       //포지션 지정.S

            int gridX = save.farmSaveDatas[i].gridX;
            int gridZ = save.farmSaveDatas[i].gridZ;
            Vector3 originPos = originPos = GameObject.FindObjectOfType<GridBuildingSystem>().GetComponent<GridBuildingSystem>().originPos;
            //Debug.Log("originPos: " + originPos);

            int farmKindNumber = save.farmSaveDatas[i].saveFarmKindNumber;      //이렇게 해서 어떤 종류의 crop인지 들고옴.
            //Debug.Log("Load에서 farmKindNum: "+farmKindNumber);

            Quaternion rotate = Quaternion.identity;
            rotate.eulerAngles = new Vector3(save.farmSaveDatas[i].rotateX, save.farmSaveDatas[i].rotateY, save.farmSaveDatas[i].rotateZ);
           
            GameObject genedFarm = Instantiate(farmPrefab, new Vector3 (gridX, 0, gridZ) * 1.0f + originPos, rotate);  //position대로 가길 바람.
            //Debug.Log("복사 됌");
            Farm genManager = genedFarm.GetComponent<Farm>();           //복사된 Farm의 Farm 스크립트를 들고옴.
            genManager.isDistroy = save.farmSaveDatas[i].isDistroy;
            genManager.saveFarmKindNumber = farmKindNumber;
            genManager.gridX = gridX;
            genManager.gridZ = gridZ;
            genManager.GenerateFarm(1, 1, farmKindNumber);
        }

        //여기 CropLoad해볼까?

        for(int i = 0; i<saveLength; i++){
            //Destroy(GameObject.FindObjectOfType<Farm>());     //이건 Farm이라는 스크립트 삭제.
            //Destroy(GameObject.Find("ZFarmEx(Clone)"));       //이건 왠지 모르겠는데 삭제가 안됨.
            Destroy(farms[i]);              // 이건 된다.
        }
    }
    
}
