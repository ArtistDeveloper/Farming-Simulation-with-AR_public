using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySaveSystem : MonoBehaviour
{
    public int money;
    public Text money_Text;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("Money")){
            //Debug.Log("Money 처음 생성");
            PlayerPrefs.SetInt("Money", 100000);
            money = PlayerPrefs.GetInt("Money");
            money_Text.text = money.ToString("0");
        }else{
            //Debug.Log("Money 처음 생성 아님");
            money = PlayerPrefs.GetInt("Money");
            money_Text.text = money.ToString("0");
        }
    }
}
