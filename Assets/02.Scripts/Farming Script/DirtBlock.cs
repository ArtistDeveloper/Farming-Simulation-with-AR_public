using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBlock : MonoBehaviour
{
    public int maxWater = 100;
    public float waterLevel = 100.0f;
    public int hydrationRate = 6;
    private float fadeLevel = 0;
    private bool cropDestroy = false;

    public Material wetTexture;
    public Material dryTexture;

    public GameObject crop ;
    //private CropLogic cropLogic;

    void Start()
    {
        //물을 준 상태
        waterLevel = maxWater;
        //cropLogic = transform.parent.GetComponentInChildren<CropLogic>();       
    }

    void Update()
    {
        waterLevel -= hydrationRate * Time.deltaTime;


        if(waterLevel < 0) {
            waterLevel = 0;
        }
        
        fadeLevel += (hydrationRate * Time.deltaTime) / 100;
        if(fadeLevel > 1){
            fadeLevel = 1;
        }

        GetComponent<MeshRenderer>().material.Lerp(wetTexture, dryTexture, fadeLevel);

        // if(waterLevel <= 0)
        // {
        //     if(cropLogic != null){
        //        cropLogic.StartWither();
        //     }
        // }

        if(cropDestroy){
            //List안에 썩지 않은 Crop들을 다 넣어서 한번에 없애기 위해 이렇게 작성을 했음.
            CropLogic[] cropList = GetComponentsInChildren<CropLogic>(true);
            if(cropList != null){  
            for(int i = 0;i<cropList.Length; i++){ 
                if(cropList[i] != transform){           
                        Destroy(cropList[i].gameObject);   
                        Destroy(gameObject);
                    }
                }
            }
        }

        //w를 누르면 물을 주는 것임.
        //그래서 현재 w를 누르면 땅이 물을 뿌린것 처럼 약간 까매지고 다시 fade out 되서 drt된다. 
        // if(Input.GetKeyDown(KeyCode.W)){
        //     waterLevel = maxWater;
        //     fadeLevel = 0;

        //     if(cropLogic != null){
        //         cropLogic.StopWither();
        //     }
        // }
    }

    public void CropWither()
    {
        cropDestroy = true;
    }

}
