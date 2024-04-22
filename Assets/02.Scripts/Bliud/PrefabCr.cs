using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabCr : MonoBehaviour
{
    [SerializeField] private Text buildText;
    [SerializeField] private Text DiaText;
    [SerializeField] public GameObject ckd;
    [SerializeField] public GameObject dkseho;

    public GameObject dnf1;
    public GameObject dnf2;
    public GameObject dnf3;
    public GameObject wkehdck;
    public GameObject anfxodzm;

    public GameObject ekfrwkd;

    public GameObject wlq;
    public GameObject tkdwja;
    //public GameObject
    

    
    [SerializeField] private Text DiamainText;
    private int ChageDia;
    private int useDia;    


    public GameObject farmPrefab;
    GameObject farm;

    private InventoryUI inventoryUI;

    void Start(){
        inventoryUI = GameObject.Find("GameObject").transform.Find("UI").transform.Find("InventoryBBG").GetComponent<InventoryUI>();
    }
    public void OnYes(){
      
       if(buildText.text=="울타리1을 설치하시겠습니까?")
       {
         useDia = int.Parse(DiamainText.text);
           if(useDia>1000)
           {
                Instantiate(dnf1, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-1000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        
        if(buildText.text=="울타리2을 설치하시겠습니까?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>2000)
           {
                Instantiate(dnf2, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-2000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        
        if(buildText.text=="울타리3을 설치하시겠습니까?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>3000)
           {
                Instantiate(dnf3, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-3000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        
        if(buildText.text=="자동차를 설치하시겠습니까?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>200000)
           {
                Instantiate(wkehdck, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-200000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        
        if(buildText.text=="물탱크를 설치하시겠습니까?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>50000)
           {
                Instantiate(anfxodzm, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-50000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        
        if(buildText.text=="닭장을 설치하시겠습니까?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>5000)
           {
                Instantiate(ekfrwkd, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-5000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

        if(buildText.text=="집을 설치하시겠습니까?")
       {
         useDia = int.Parse(DiamainText.text);
           if(useDia>0)
           {
                Instantiate(wlq, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-0;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

        if(buildText.text=="상점을 설치하시겠습니까?")
       {
         useDia = int.Parse(DiamainText.text);
           if(useDia>0)
           {
                Instantiate(tkdwja, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-0;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

        //-------------------------------------------------------------

         if(buildText.text=="아스파라거스를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>500)
           {    int i = 0;
                for(i = 0; i<inventoryUI.boxCount; i=i+0){
                    if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("Asparagus"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 0);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-500;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxneercan==inventoryUI.boxCount)
                    {   
                        inventoryUI.qnwhr.SetActive(true);
                        i=inventoryUI.boxCount;
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("In"))
                    {   
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 0);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-500;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                        
                    }
                    else
                    {
                        i++;
                    }
                    
               
                } 
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

         if(buildText.text=="사탕무를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>1000)
           {    int i = 0;
                for(i = 0; i<inventoryUI.boxCount; i=i+0){
                    if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("Beet"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 1);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-1000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxneercan==inventoryUI.boxCount)
                    {
                        inventoryUI.qnwhr.SetActive(true);
                        i=inventoryUI.boxCount;
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("In"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 1);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-1000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else
                    {
                        i++;
                    }
               
                } 
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

         if(buildText.text=="브로콜리를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>2000)
           {    int i = 0;
                for(i = 0; i<inventoryUI.boxCount; i=i+0){
                    if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("Broccoli"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 2);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-2000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxneercan==inventoryUI.boxCount)
                    {
                        inventoryUI.qnwhr.SetActive(true);
                        i=inventoryUI.boxCount;
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("In"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 2);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-2000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else
                    {
                        i++;
                    }
               
                }
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

        
         if(buildText.text=="당근을 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>3000)
           {  int i = 0;
                for(i = 0; i<inventoryUI.boxCount; i=i+0){
                    if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("Carrot"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 3);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-3000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxneercan==inventoryUI.boxCount)
                    {
                        inventoryUI.qnwhr.SetActive(true);
                        i=inventoryUI.boxCount;
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("In"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 3);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-3000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else
                    {
                        i++;
                    }
               
                }
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

        
         if(buildText.text=="양상추를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>4000)
           {  int i = 0;
                for(i = 0; i<inventoryUI.boxCount; i=i+0){
                    if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("Lettuce"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 4);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-4000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxneercan==inventoryUI.boxCount)
                    {
                        inventoryUI.qnwhr.SetActive(true);
                        i=inventoryUI.boxCount;
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("In"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 4);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-4000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else
                    {
                        i++;
                    }
               
                }
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

        
         if(buildText.text=="양파를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>5000)
           {  int i = 0;
                for(i = 0; i<inventoryUI.boxCount; i=i+0){
                    if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("Onion"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 5);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-5000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxneercan==inventoryUI.boxCount)
                    {
                        inventoryUI.qnwhr.SetActive(true);
                        i=inventoryUI.boxCount;
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("In"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 5);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-5000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else
                    {
                        i++;
                    }
               
                }
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

        if(buildText.text=="감자를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>6000)
           {  int i = 0;
                for(i = 0; i<inventoryUI.boxCount; i=i+0){
                    if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("Potato"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 6);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-6000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxneercan==inventoryUI.boxCount)
                    {
                        inventoryUI.qnwhr.SetActive(true);
                        i=inventoryUI.boxCount;
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("In"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 6);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-6000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else
                    {
                        i++;
                    }
               
                }
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

         if(buildText.text=="호박을 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>7000)
           {    int i = 0;
                for(i = 0; i<inventoryUI.boxCount; i=i+0){
                    if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("Pumpkin"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 7);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-7000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxneercan==inventoryUI.boxCount)
                    {
                        inventoryUI.qnwhr.SetActive(true);
                        i=inventoryUI.boxCount;
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("In"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 7);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-7000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else
                    {
                        i++;
                    }
               
                }
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

         if(buildText.text=="수박을 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>8000)
           {  int i = 0;
                for(i = 0; i<inventoryUI.boxCount; i=i+0){
                    if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("Watermelon"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 8);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-8000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxneercan==inventoryUI.boxCount)
                    {
                        inventoryUI.qnwhr.SetActive(true);
                        i=inventoryUI.boxCount;
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("In"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 8);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-8000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else
                    {
                        i++;
                    }
               
                }
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }

         if(buildText.text=="밀을 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>9000)
           {  int i = 0;
                for(i = 0; i<inventoryUI.boxCount; i=i+0){
                    if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("Wheat"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 9);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-9000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxneercan==inventoryUI.boxCount)
                    {
                        inventoryUI.qnwhr.SetActive(true);
                        i=inventoryUI.boxCount;
                        ckd.SetActive(false);
                    }
                    else if(inventoryUI.boxes[i].GetComponent<Button>().CompareTag("In"))
                    {
                        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        Farm farmScript = farm.GetComponent<Farm>();
                        farmScript.GenerateFarm(1, 1, 9);
                        i=inventoryUI.boxCount;

                        ChageDia=useDia-9000;
                        DiamainText.text="";
                        DiamainText.text=ChageDia.ToString();
                        ckd.SetActive(false);
                    }
                    else
                    {
                        i++;
                    }
               
                }
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }


    }


}
