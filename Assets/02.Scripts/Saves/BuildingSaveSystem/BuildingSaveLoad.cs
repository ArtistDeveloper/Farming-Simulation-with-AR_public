using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSaveLoad : MonoBehaviour
{
    public GameObject buildingPrefab1, buildingPrefab2, buildingPrefab3, buildingPrefab4, 
                      buildingPrefab5, buildingPrefab6, buildingPrefab7, buildingPrefab8, buildingPrefab9;
    private AllBuildingData save;
    private int saveLength;
    void Start(){       //원래 Awake
        //Debug.Log("LoadBuilding 시작.");
        LoadBuilding();
        //Debug.Log("LoadBuilding 완료");
    }

    public void OnApplicationFocus(bool value){
        if(value){      //들어왔을 때 실행.
            //Debug.Log("Building OnApplicationFocus true 실행");
            //LoadBuilding();     //원래 친구 삭제 후 복사해서 놓음.
            //Debug.Log("Building 로드");
        }else
        {
            //Debug.Log("Building OnApplicationFocus false 실행");
            SaveBuilding();
            //Debug.Log("Building Save");
        }
    }

    public void OnApplicationQuit()
    {
        SaveBuilding();
        //Debug.Log("Building 저장 완료");
    }


    public void SaveBuilding(){
        BuildingSaveManager.Save(GameObject.FindObjectsOfType<Building>());         //
        //Debug.Log("찾은 Building의 개수"+GameObject.FindObjectsOfType<Building>().Length);      //잘 됌.
    }

    public void LoadBuilding(){
        save = BuildingSaveManager.Load();
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        for(int i = 0; i<saveLength; i++){
            Destroy(buildings[i]);              // 이건 된다.
        }
        Debug.Log("Building Load에서 찾은 Building의 개수 - 복사하는 개수: " + buildings.Length);
        Debug.Log("그럼 building Load에 있는 save의 데이터 개수: "+ save.buildingSaveDatas.Length);
        saveLength = buildings.Length;

        //태그 해줘야함! - 어려운거 아니니까 까먹지 말쟈~!
        //Debug.Log("Load for문 돌리는 길이: "+ save.buildingSaveDatas.Length);
        for(int i=save.buildingSaveDatas.Length-1; i>=0; i--){       //int i=0; i <= save.cropSaveDatas.Length -1; i++    //int i=save.buildingSaveDatas.Length-1; i>=0; i--
            // Vector3 position;
            // position.x = save.buildingSaveDatas[i].x;        //Mathf.Abs(i - save.buildingSaveDatas.Length)
            // position.y = save.buildingSaveDatas[i].y;
            // position.z = save.buildingSaveDatas[i].z;       //포지션 지정.
            int gridX = save.buildingSaveDatas[i].gridX;
            int gridZ = save.buildingSaveDatas[i].gridZ;
            Vector3 originPos = GameObject.FindObjectOfType<GridBuildingSystem>().GetComponent<GridBuildingSystem>().originPos;
            //Debug.Log("Building originPos: " + originPos);

            Quaternion rotate = Quaternion.identity;
            rotate.eulerAngles = new Vector3(save.buildingSaveDatas[i].rotateX, save.buildingSaveDatas[i].rotateY, save.buildingSaveDatas[i].rotateZ); 
            int buildingKind = save.buildingSaveDatas[i].buildingKind;      //building 종류 지정.
            //Debug.Log("Load에서 buildingKindNum: "+buildingKindNumber);
            if(buildingKind == 1){                          
                GameObject genedBuilding = Instantiate(buildingPrefab1, new Vector3 (gridX, 0, gridZ) * 1.0f + originPos, rotate);  //position대로 가길 바람.
                genedBuilding.GetComponent<Building>().gridX = gridX;
                genedBuilding.GetComponent<Building>().gridZ = gridZ;
            } else if(buildingKind == 2){
                GameObject genedBuilding = Instantiate(buildingPrefab2, new Vector3 (gridX, 0, gridZ) * 1.0f + originPos, rotate);
                genedBuilding.GetComponent<Building>().gridX = gridX;
                genedBuilding.GetComponent<Building>().gridZ = gridZ;
            } else if(buildingKind == 3){
                GameObject genedBuilding = Instantiate(buildingPrefab3, new Vector3 (gridX, 0, gridZ) * 1.0f + originPos, rotate);
                genedBuilding.GetComponent<Building>().gridX = gridX;
                genedBuilding.GetComponent<Building>().gridZ = gridZ;
            } else if(buildingKind == 4){
                GameObject genedBuilding = Instantiate(buildingPrefab4, new Vector3 (gridX, 0, gridZ) * 1.0f + originPos, rotate);
                genedBuilding.GetComponent<Building>().gridX = gridX;
                genedBuilding.GetComponent<Building>().gridZ = gridZ;
            } else if(buildingKind == 5){
                GameObject genedBuilding = Instantiate(buildingPrefab5, new Vector3 (gridX, 0, gridZ) * 1.0f + originPos, rotate);
                genedBuilding.GetComponent<Building>().gridX = gridX;
                genedBuilding.GetComponent<Building>().gridZ = gridZ;
            } else if(buildingKind == 6){
                GameObject genedBuilding = Instantiate(buildingPrefab6, new Vector3 (gridX, 0, gridZ) * 1.0f + originPos, rotate);
                genedBuilding.GetComponent<Building>().gridX = gridX;
                genedBuilding.GetComponent<Building>().gridZ = gridZ;
            } else if(buildingKind == 7){
                GameObject genedBuilding = Instantiate(buildingPrefab7, new Vector3 (gridX, 0, gridZ) * 1.0f + originPos, rotate);
                genedBuilding.GetComponent<Building>().gridX = gridX;
                genedBuilding.GetComponent<Building>().gridZ = gridZ;
            }else if(buildingKind == 8){
                GameObject genedBuilding = Instantiate(buildingPrefab8, new Vector3 (gridX, 0, gridZ) * 1.0f + originPos, rotate);
                genedBuilding.GetComponent<Building>().gridX = gridX;
                genedBuilding.GetComponent<Building>().gridZ = gridZ;
            } else if(buildingKind == 9){
                GameObject genedBuilding = Instantiate(buildingPrefab9, new Vector3 (gridX, 0, gridZ) * 1.0f + originPos, rotate);
                genedBuilding.GetComponent<Building>().gridX = gridX;
                genedBuilding.GetComponent<Building>().gridZ = gridZ;
            }
            
        }

        
    }
}
