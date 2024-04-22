
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public Transform world;
    public BlockData[] blockTypes;   
    public Block[,] blocks = new Block[1, 1];

    public int width = 1;       //5X5개로 설정이 되며 겹치게 나와서 결국에 보았을 때 10행이 형성됨.
    public int height = 1;
    //blockIndex값이 1이면 잔디가 나오게 설정을 해놓았음 - 혹시 식물에 따라 키우는 곳이 다를까봐 해놓은 설정임. 
    //1 - 35:23 - 삭제하지마시오 그리고 언제든지 block추가 가능합니다.
    public int blockIndex = 0;
    private GameObject farmLoad;
    public bool isDistroy = false;
    public int saveFarmKindNumber;

    //grid 변수
    public int gridX, gridZ;

    public void takeX(int x)
    {
        gridX = x;
    }

    public void takeZ(int z)
    {
        gridZ = z;
    }

    public CropData[] cropTypes;

    void Awake(){
        blocks = new Block[height, width];          //이리로 생성하니까 crop Tag 추출이 된다.
    }

    void Update(){
        if(this.transform.Find("Block (0,0,0)").Find("Asparagus(Clone)") == null && this.transform.Find("Block (0,0,0)").Find("Beet(Clone)") == null && 
        this.transform.Find("Block (0,0,0)").Find("Broccoll(Clone)") == null && this.transform.Find("Block (0,0,0)").Find("Carrot(Clone)") == null && 
        this.transform.Find("Block (0,0,0)").Find("Lettuce(Clone)") == null && this.transform.Find("Block (0,0,0)").Find("Onion(Clone)") == null &&
        this.transform.Find("Block (0,0,0)").Find("Potato(Clone)") == null && this.transform.Find("Block (0,0,0)").Find("Pumpkin(Clone)") == null &&
        this.transform.Find("Block (0,0,0)").Find("Watermelon(Clone)") == null && this.transform.Find("Block (0,0,0)").Find("Wheat(Clone)")== null){    //Crop이 있는지 없는지 확인함.
            Debug.Log("Crop 다 재배 또는 삭제됨");
            Destroy(this);
        }

        if(isDistroy){
            Destroy(this.gameObject);           //Destoty(this)하면 스크립트만 삭제됨. 지금이 상태는 저 머냐 gameObject 삭제.
        }
    }

    void OnDisable(){
        isDistroy = true;
    }

    public void GenerateFarm(float width, float height, int farmKindNumber)
    {
        saveFarmKindNumber = farmKindNumber;
        for(int z=0; z<height; z++){
            for(int x=0; x<width; x++){

                //혹시 여기서 MissingPrefab이 뜬다면 해당 Scriptable Object에 가서 Prefab을 넣어주면 됨.
                Block block = new Block();
                BlockData blockData = blockTypes[blockIndex];
                
                block.id = blockIndex;
                block.name = blockData.name;
                block.x = x;
                block.z = z;
                block.blockPrefab = blockData.blockPrefab;
               
                CropValue crop = new CropValue();
                CropData cropData = cropTypes[farmKindNumber]; //배열 안에 0번쨰 있는 crop을 소환! 그러면 
                    
                crop.maxGrowth = cropData.maxGrowth;
                crop.growthRate = cropData.growthRate;
                crop.maxHealth = cropData.maxHealth;
                crop.slotPrefab = cropData.CropPrefab;

                block.slot = crop;
                block.slot.slotType = BlockSlockType.CROP;
                
                blocks[z,x] = block;
                                  
            }
        }

        RenderFarm();
    }

    public void RenderFarm()
    {
        for(int z = 0; z<blocks.GetLength(0); z++){
            for(int x = 0; x < blocks.GetLength(1); x++)
            {
                Block block = blocks[z, x];
                Vector3 blockPos = new Vector3(block.x, 0, block.z);                      

                //go의 의미는 밭이 생성되는 위치를 의미한다. Inmstantiate가 block.blockPrefab을 복제해서 Vector위치에 놓는다.
                GameObject go = Instantiate(block.blockPrefab, blockPos, Quaternion.identity);
                go.transform.SetParent(world);
                go.name = block.name +" (" + x + ","+ 0 + "," + z + ")";      //형성되는 밭의 위치를 명확하게 보여주기 위해서 이걸 사용했음.

                //crop 나타나는 함수.
                for(int i=0; i<5; i++){  
                    for(int j=0; j<4; j++){
                        GameObject blockSlot = Instantiate(block.slot.slotPrefab, blockPos + new Vector3(-4.5f + i, 0.18f, 1.0f + j), Quaternion.identity);     //bidge 추가 내용 2 - 40:16
                        blockSlot.transform.SetParent(go.transform);   

                        if(block.slot.slotType == BlockSlockType.CROP){
                            CropValue crop = (CropValue) block.slot;

                            CropLogic cropLogic = blockSlot.GetComponentInChildren<CropLogic>();
                            cropLogic.maxGrowth = crop.maxGrowth;
                            cropLogic.maxHealth = crop.maxHealth;
                            cropLogic.growthRate = crop.growthRate;
                            cropLogic.witheredPrefab = cropTypes[0].witheredPrefab;     //cropTypes안에 몇번쨰 것을 쓸 것인지 나중에 설정이 가능함.
                        }                         
                    }                   
                }
               
            }
        }
    }
}