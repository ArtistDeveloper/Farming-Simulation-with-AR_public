using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropCountSave : MonoBehaviour
{
    //작물의 종류가 추가되면 PlayerPrefs 종류를 더 늘리면 됨 
    //int형이라서 가능한 경우임.
    public int watermelon;
    public Text watermelon_Text;

    public int Carrot;
    public Text Carrot_Text;

    public int Potato;
    public Text Potato_Text;

    public int Asparagus;
    public Text Asparagus_Text;

    public int Beet;
    public Text Beet_Text;

    public int Pumkin;
    public Text Pumkin_Text;

    public int Onion;
    public Text Onion_Text;

    public int Lettuce;
    public Text Lettuce_Text;

    public int Wheat;
    public Text Wheat_Text;

    public int Broccoli;
    public Text Broccoli_Text;


    void Start(){
        LoadCropCountData();
    }

    public void LoadCropCountData(){
        //여기 각 작물에 대한 Count를 playerPrefs에서 들고오면 된다.
        if(PlayerPrefs.HasKey("Watermelon_Count")){         //여긴 그냥 하면 됨. 그 이유는 불러와서 넣는 것일 뿐이기 떄문임. 저장하는게 문제인듯.
            watermelon = PlayerPrefs.GetInt("Watermelon_Count", 0);
            watermelon_Text.text = watermelon.ToString("0");
        }else{
            watermelon_Text.text = "0";
            //Debug.Log("Watermelon PlayerPrefs 못찾음!!!");
        }
    
    
        if(PlayerPrefs.HasKey("Carrot_Count")){
            Carrot = PlayerPrefs.GetInt("Carrot_Count", 0);
            Carrot_Text.text = Carrot.ToString("0");
        }else{
            Carrot_Text.text = " 0";
            //Debug.Log("Carrot PlayerPrefs 못찾음!!!");
        }


        if(PlayerPrefs.HasKey("Potato_Count")){
            Potato = PlayerPrefs.GetInt("Potato_Count", 0);
            Potato_Text.text = Potato.ToString("0");
        }else{
            Potato_Text.text = "0";
            //Debug.Log("Potato PlayerPrefs 못찾음!!!");
        }


        if(PlayerPrefs.HasKey("Asparagus_Count")){
            Asparagus = PlayerPrefs.GetInt("Asparagus_Count", 0);
            Asparagus_Text.text = Asparagus.ToString("0");
        }else{
            Asparagus_Text.text = "0";
            //Debug.Log("Asparagus PlayerPrefs 못찾음!!!");
        }
    

        if(PlayerPrefs.HasKey("Beet_Count")){
            Beet = PlayerPrefs.GetInt("Beet_Count", 0);
            Beet_Text.text = Beet.ToString("0");
        }else{
            Beet_Text.text = "0";
            //Debug.Log("Beet PlayerPrefs 못찾음!!!");
        }
   

        if(PlayerPrefs.HasKey("Pumkin_Count")){
            Pumkin = PlayerPrefs.GetInt("Pumkin_Count", 0);
            Pumkin_Text.text = Pumkin.ToString("0");
        }else{
            Pumkin_Text.text = "0";
            //Debug.Log("Pumkin PlayerPrefs 못찾음!!!");
        }
    

        if(PlayerPrefs.HasKey("Onion_Count")){
            Onion = PlayerPrefs.GetInt("Onion_Count", 0);
            Onion_Text.text = Onion.ToString("0");
        }else{
            Onion_Text.text = "0";
            //Debug.Log("Onion PlayerPrefs 못찾음!!!");
        }
    

        if(PlayerPrefs.HasKey("Lettuce_Count")){
            Lettuce = PlayerPrefs.GetInt("Lettuce_Count", 0);
            Lettuce_Text.text = Lettuce.ToString("0");
        }else{
            Lettuce_Text.text = "0";
            //Debug.Log("Lettuce PlayerPrefs 못찾음!!!");
        }


        if(PlayerPrefs.HasKey("Wheat_Count")){
            Wheat = PlayerPrefs.GetInt("Wheat_Count", 0);
            Wheat_Text.text = Wheat.ToString("0");
        }else{
            Wheat_Text.text = "0";
            //Debug.Log("Wheat PlayerPrefs 못찾음!!!");
        }
   

        if(PlayerPrefs.HasKey("Broccoli_Count")){
            Broccoli = PlayerPrefs.GetInt("Broccoli_Count", 0);
            Broccoli_Text.text = Broccoli.ToString("0");
        }else{
            Broccoli_Text.text = "0";
            //Debug.Log("Broccoli PlayerPrefs 못찾음!!!");
        }
    }

}
