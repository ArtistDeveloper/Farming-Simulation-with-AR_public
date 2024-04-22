using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropState : MonoBehaviour
{
    //이거도 Crop에 들어가 있는 친구임.
    private DirtBlock dirtBlock;

    public GameObject growDoneCube;

    private bool waterPlz = false;      //물이 필요한지
    private bool growDone = false;      //다 자랐는지
    [SerializeField]
    private bool canHarvest = false;    //재배 가능
    public string cropKind;             //잘 받아옴 -> 프리팹에 다 적어야함.

    public int cropCount;

    private Vector3 cropPos;
    private CropCountSave cropCountSave;
    private InventoryUI inventoryUI;

    private string spritename;  //이미지이름

    private int boxneercan = 0;  //사용 가능한 칸

    //
    private Camera cam;



    void Start()
    {
        cropPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        cropCountSave = GameObject.Find("SaveManager").GetComponent<CropCountSave>();

        inventoryUI = GameObject.Find("Collection Ingame Object").transform.Find("UI").transform.Find("InventoryBBG").GetComponent<InventoryUI>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (growDone)
        {
            if (!transform.Find("DoneCube(Clone)"))
            {
                cropPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                GameObject.Instantiate(growDoneCube, cropPos + new Vector3(0, 1.5f, 0f), Quaternion.identity).transform.parent = this.transform;
                growDone = false;
                canHarvest = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (canHarvest && hit.collider.gameObject.tag == "CropGood")
                {
                    //Debug.Log("터치 완료");
                    if (PlayerPrefs.HasKey(cropKind + "_Count"))
                    {

                        //Debug.Log("PlayerPrefs 있음");
                        PlayerPrefs.SetInt(cropKind + "_Count", PlayerPrefs.GetInt(cropKind + "_Count") + 1);   //Q(채집)을 할 때 마다 저장을 하는 것임.
                        cropCountSave.LoadCropCountData();      //이거는 내가 스크립트를 꺼놔서 안됨. 키면 됨.
                        //Debug.Log("CropKind: " + cropKind);
                        inventoryUI.Cropharvesting(cropKind);

                        Destroy(gameObject);        //된다.                 
                    }
                    else
                    {

                        //Debug.Log("PlayerPrefs 없음");
                        PlayerPrefs.SetInt(cropKind + "_Count", 1);
                        Debug.Log(PlayerPrefs.GetInt(cropKind + "_Count"));
                        Destroy(gameObject);

                    }


                }



            }

        }

    }


    public void GrowDone()
    {
        growDone = true;
    }





}
