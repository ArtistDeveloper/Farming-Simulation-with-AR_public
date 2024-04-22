using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject nulll;
    [SerializeField] GameObject Watermelon;
    [SerializeField] GameObject Carrot;
    [SerializeField] GameObject Potato;
    [SerializeField] GameObject Asparagus;
    [SerializeField] GameObject Beet;
    [SerializeField] GameObject Pumkin;
    [SerializeField] GameObject Onion;
    [SerializeField] GameObject Lettuce;
    [SerializeField] GameObject Wheat;
    [SerializeField] GameObject Broccoli;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void Sellckd(){

            if(GetComponent<Button>().CompareTag("In")){
                nulll.SetActive(true);
            }
            if(GetComponent<Button>().CompareTag("Watermelon")){
                Watermelon.SetActive(true);
                Debug.Log("수박");
            }
            if(GetComponent<Button>().CompareTag("Carrot")){
                Carrot.SetActive(true);
                Debug.Log("당근");
            }
            if(GetComponent<Button>().CompareTag("Potato")){
                Potato.SetActive(true);
                Debug.Log("감자");
            }
            if(GetComponent<Button>().CompareTag("Asparagus")){
                Asparagus.SetActive(true);
                Debug.Log("아스파");
            }
            if(GetComponent<Button>().CompareTag("Beet")){
                Beet.SetActive(true);
                Debug.Log("비트에요");
            }
            if(GetComponent<Button>().CompareTag("Pumpkin")){
                Pumkin.SetActive(true);
                Debug.Log("호박");
            }
            if(GetComponent<Button>().CompareTag("Onion")){
                Onion.SetActive(true);
                Debug.Log("양파");
            }
            if(GetComponent<Button>().CompareTag("Lettuce")){
                Lettuce.SetActive(true);
                Debug.Log("양상추");
            }
            if(GetComponent<Button>().CompareTag("Wheat")){
                Wheat.SetActive(true);
                Debug.Log("밀");
            }
            if(GetComponent<Button>().CompareTag("Broccoli")){
                Broccoli.SetActive(true);
                Debug.Log("브로콜");
            }

        
    }
}
