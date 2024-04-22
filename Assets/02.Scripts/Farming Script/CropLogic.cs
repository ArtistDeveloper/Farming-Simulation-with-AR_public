using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//실시간이 된다면 Awake에 값을 받아와야할거 같음.

public class CropLogic : MonoBehaviour
{
    public float maxGrowth = 100f;
    public float growthLevel = 0;
    public float growthRate = 0.5f;      //자라는 속도임.
    public float maxHealth = 100.0f;

    public GameObject witheredPrefab;

    private bool wither = false;
    public float health = 100.0f;
    public float witerRate = 10.0f;

    private DirtBlock dirtBlock;
    private CropState cropState;
    private CropGrowTime cropGrowTime;

    private float getRemainGrowTime;
    private float getTimeMaxGrowInterval;

    void Start()
    {
        dirtBlock = transform.parent.GetComponent<DirtBlock>();
        cropState = transform.GetComponent<CropState>();
        cropGrowTime = transform.GetComponent<CropGrowTime>();
        health = maxHealth;
        growthLevel = 0;     
    }
    
    void Update()
    {
        //시드는 것임.
        if(wither)
        {          
             health -= witerRate * Time.deltaTime;

            if(health <= 0 ){    
                if(witheredPrefab != null)
                {
                    for(int i=0; i<5; i++){
                        for(int j=0; j<4; j++){
                            //썩은 Crop나타나게 하는 코드.
                            GameObject go = Instantiate(witheredPrefab, transform.position + new Vector3(i,0,j), Quaternion.identity);
                            go.transform.SetParent(transform.parent.parent);
                            go.GetComponentInChildren<Transform>().localScale = transform.localScale;
                        }
                    }
                }else{
                    Debug.LogError("withered Prefab이 설정되지 않음.");
                }     
                dirtBlock.CropWither();
            }              
        }else
        {
            if(health < maxHealth){
                health += (growthRate / 2) * Time.deltaTime;        //여기 있는 숫자를 키우면 health 올라가는 속도가 느려짐. 일단 난 빠르게 함.
            }
        }

        if(health >= maxHealth){
            health = maxHealth;
        }

        //RemainGrowTime과 MaxGrowInterval을 가져온다.
        getRemainGrowTime = cropGrowTime.getRemainGrowTime();
        getTimeMaxGrowInterval = cropGrowTime.getTimeMaxGrowInterval();
        //Debug.Log("CropLogic에서 getRemainGrowTime의 값 즉 들고온 Remain값: " + getRemainGrowTime);

        if(getRemainGrowTime <= 0){
            growthLevelMakeMax();
        }
        
        if(growthLevel >= maxGrowth){ 
            ScaleCrop(0.0f);
        }else{
            //작물이 점점 커지는 것.
            getRemainGrowTime = cropGrowTime.getRemainGrowTime();
            getTimeMaxGrowInterval = cropGrowTime.getTimeMaxGrowInterval();
            float getResult = getRemainGrowTime / getTimeMaxGrowInterval;           
            ScaleCrop(getResult);
        }

    }

    void ScaleCrop(float getResult)        //Crop의 크기를 늘리는 코드임. 잘 크는데 대신에 조금 뚝뚝 커짐.
    {
        growthLevel = maxGrowth - (maxGrowth * getResult);          //원래 여기 maxGrowth = 100;
        Vector3 cropScale = new Vector3(1, 1, 1) * (growthLevel /maxGrowth);
        gameObject.transform.localScale = cropScale;
    }

    public void StartWither()
    {
        wither = true;
    }

    public void StopWither()
    {
        wither = false;
    }

    public void growthLevelMakeMax(){
        growthLevel = maxGrowth;
    }

}
