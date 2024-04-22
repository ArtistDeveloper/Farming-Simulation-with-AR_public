using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFarmKind : MonoBehaviour
{
    public GameObject farmPrefab;
    GameObject farm;

    public void OnClickButton_0(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 0);
        //Debug.Log("0번 버튼 선택됨.");
    }

    public void OnClickButton_1(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 1);
        //Debug.Log("1번 버튼 선택됨.");
    }

    public void OnClickButton_2(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 2);
        //Debug.Log("2번 버튼 선택됨.");
    }
    
    public void OnClickButton_3(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 3);
        //Debug.Log("3번 버튼 선택됨.");
    }

    public void OnClickButton_4(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 4);
        //Debug.Log("4번 버튼 선택됨.");
    }

    public void OnClickButton_5(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 5);
        //Debug.Log("5번 버튼 선택됨.");
    }

    public void OnClickButton_6(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 6);
        //Debug.Log("6번 버튼 선택됨.");
    }

    public void OnClickButton_7(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 7);
        //Debug.Log("7번 버튼 선택됨.");
    }

    public void OnClickButton_8(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 8);
        //Debug.Log("8번 버튼 선택됨.");
    }

    public void OnClickButton_9(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 9);
        //Debug.Log("9번 버튼 선택됨.");
    }
}
