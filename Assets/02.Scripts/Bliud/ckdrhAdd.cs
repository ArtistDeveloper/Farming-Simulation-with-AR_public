using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ckdrhAdd : MonoBehaviour
{
   
   [SerializeField] private Text buildText;
    [SerializeField] public GameObject ckd;
    [SerializeField] public GameObject dkseho;
    [SerializeField] private Text DiamainText;
    [SerializeField] private Text DiaminusText;
    public GameObject ckdrh;

    
    private int ChageDia;
    private int useDia;
    private int minusDia;
   public void ckdrhYes(){

         
      
        
            useDia = int.Parse(DiamainText.text);

            minusDia = int.Parse(DiaminusText.text);

            if(useDia>minusDia){
                Instantiate(ckdrh, new Vector3(0,0,0), Quaternion.identity);
                ChageDia=useDia-minusDia;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);

            }else{
                dkseho.SetActive(true);
                ckd.SetActive(false);
                
            }

            
 // if(buildText.text!= null){  ckd.SetActive(false);     }
 
            //GameObject.Find("InventoryBBG").GetComponent<InventoryUI>().AddBox();
            //GameObject.Find("InventoryBBG").GetComponent<InventoryUI>.AddBox();
            //GameObject.FindGameObjectWithTag("BBG").GetComponent<InventoryUI>();
        }
   
}
