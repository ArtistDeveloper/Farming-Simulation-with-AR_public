using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
   Inventory inven;

   // public GameObject inventoryPanel;
    //bool activeInventory=false;

    public Box[] boxes;
    public Transform boxHolder;
    public int boxCount=5; 

    //이미지 보관
    [SerializeField] private Sprite Asparagus;
    [SerializeField] private Sprite Beet;
    [SerializeField] private Sprite Broccoli;
    [SerializeField] private Sprite Carrot;
    [SerializeField] private Sprite Lettuce;
    [SerializeField] private Sprite Onion;
    [SerializeField] private Sprite Potato;
    [SerializeField] private Sprite Pumkin;
    [SerializeField] private Sprite Watermelon;
    [SerializeField] private Sprite Wheat;

    [SerializeField] public GameObject qnwhr;


    private string spritename;  //이미지이름
   
    public int boxneercan=0;  //사용 가능한 칸
  
    public void Start()
    {
        gameObject.SetActive(false);
        inven=Inventory.instance;  
        boxes = boxHolder.GetComponentsInChildren<Box>();
       
        for(int i = 0; i<boxes.Length; i++){
            if(i<boxCount){
                boxes[i].GetComponent<Button>().interactable=true;
            }else{
                boxes[i].GetComponent<Button>().interactable=false;
            }
        }
        boxneercan=0; 
        Debug.Log("불러와짐");
    }


    public void BoxUpdate()
    {
        
        inven=Inventory.instance;  
        boxes = boxHolder.GetComponentsInChildren<Box>();
        for(int i = 0; i<boxes.Length; i++){
                if(i<boxCount){
                    boxes[i].GetComponent<Button>().interactable=true;
                }else{
                    boxes[i].GetComponent<Button>().interactable=false;
                }
        }

    }

    public void Cropharvesting(string cropkind){


        Debug.Log("1단계"+cropkind);
        int i = 0;
        for(i = 0; i<boxCount; i++){
            Debug.Log("2eksrP"+cropkind);
            if(boxes[i].GetComponent<Button>().CompareTag(cropkind))    // tag주워서 비교=true 해당 태그 붙어있으니  
            {
                Debug.Log("있어!"+cropkind);
                i++;

            } 
            else
            {
                Debug.Log("없어"+cropkind);

                    int j = 0;
                    for(j = 0; j<boxCount; j=j+0){
                        Debug.Log("여긴 왔어?"+cropkind);
                        if(boxes[j].GetComponent<Button>().CompareTag("In")){

                            if(cropkind=="Asparagus")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Asparagus;
                                boxes[j].GetComponent<Button>().tag="Asparagus";
                                boxneercan++;
                                Debug.Log(cropkind+"뢔ㄸ"+ boxneercan);
                                j=boxCount;

                            }
                            else if(cropkind=="Beet")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Beet;
                                boxes[j].GetComponent<Button>().tag="Beet";
                                boxneercan++;
                                Debug.Log(cropkind+"뢔ㄸ"+ boxneercan);
                                j=boxCount;
                            }
                            else if(cropkind=="Broccoli")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Broccoli;
                                boxes[j].GetComponent<Button>().tag="Broccoli";
                                boxneercan++;
                                Debug.Log(cropkind+"뢔ㄸ"+ boxneercan);
                                j=boxCount;
                            }
                            else if(cropkind=="Carrot")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Carrot;
                                boxes[j].GetComponent<Button>().tag="Carrot";
                                boxneercan++;
                                Debug.Log(cropkind+"뢔ㄸ"+ boxneercan);
                                j=boxCount;
                            }
                            else if(cropkind=="Lettuce")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Lettuce;
                                boxes[j].GetComponent<Button>().tag="Lettuce";
                                boxneercan++;
                                Debug.Log(cropkind+"뢔ㄸ"+ boxneercan);
                                j=boxCount;
                            }
                            else if(cropkind=="Onion")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Onion;
                                boxes[j].GetComponent<Button>().tag="Onion";
                                boxneercan++;
                                Debug.Log(cropkind+"뢔ㄸ"+ boxneercan);
                                j=boxCount;
                            }
                            else if(cropkind=="Potato")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Potato;
                                boxes[j].GetComponent<Button>().tag="Potato";
                                boxneercan++;
                                Debug.Log(cropkind+"뢔ㄸ"+ boxneercan);
                                j=boxCount;
                            }
                            else if(cropkind=="Pumpkin")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Pumkin;
                                boxes[j].GetComponent<Button>().tag="Pumpkin";
                                boxneercan++;
                                Debug.Log(cropkind+"뢔ㄸ"+ boxneercan);
                                j=boxCount;
                            }
                            else if(cropkind=="Watermelon")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Watermelon;
                                boxes[j].GetComponent<Button>().tag="Watermelon";
                                boxneercan++;
                                Debug.Log(cropkind+"뢔ㄸ"+ boxneercan);
                                j=boxCount;
                            }
                            else if(cropkind=="Wheat")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Wheat;
                                boxes[j].GetComponent<Button>().tag="Wheat";
                                boxneercan++;
                                Debug.Log(cropkind+"뢔ㄸ"+ boxneercan);
                                j=boxCount;
                            }
                        
                        }
                        else if(boxes[j].GetComponent<Button>().CompareTag(cropkind))
                        {
                            j=boxCount;
                        }
                        else
                        {
                            Debug.Log("In도 아니고 크롭도 아니네");
                            j++;
                        }
                        
                    }
                    
                

           }  i=i+10;
        }

    } // Cropharvesting 끝




   public void AddBox(){
       
       boxCount++;
   }
}
