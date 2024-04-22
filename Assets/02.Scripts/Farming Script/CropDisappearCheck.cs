using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropDisappearCheck : MonoBehaviour
{
    //이걸 block에 넣게 되면 Parent에 있는 Farm에 접근을 하게 되고
    //거기의 값을 바꿔줘서 
    private bool isCropDisappear = false;
    void Start(){
        transform.localPosition = new Vector3 (0, 0.355f, 0);
    }
    
    void Update()
    {      
        if(this.transform.Find("Block (0,0,0)").Find("Asparagus(Clone)") == null && this.transform.Find("Block (0,0,0)").Find("Beet(Clone)") == null && 
        this.transform.Find("Block (0,0,0)").Find("Broccoll(Clone)") == null && this.transform.Find("Block (0,0,0)").Find("Carrot(Clone)") == null&& 
        this.transform.Find("Block (0,0,0)").Find("Lettuce(Clone)") == null&& this.transform.Find("Block (0,0,0)").Find("Onion(Clone)") == null&&
        this.transform.Find("Block (0,0,0)").Find("Potato(Clone)") == null && this.transform.Find("Block (0,0,0)").Find("Pumpkin(Clone)") == null &&
        this.transform.Find("Block (0,0,0)").Find("Watermelon(Clone)") == null && this.transform.Find("Block (0,0,0)").Find("Wheat(Clone)")== null){    //Crop이 있는지 없는지 확인함.
            Debug.Log("Crop 없는거 찾음.");    //된다! - 이게 문제점이 하나 생각은 나는데 일단 보류함.
                                                    //문제점이 뭐냐면 다 뽑는게 아니라 일부만 뽑으면 나머지 부분에서 RenderFarm이 되서 0부터 시작하는 Crop이 생길 수 있다.
                                                    //근데 일단 진행하도록 하겠음.
                                                    //여기 까지는 나옴.
            Farm farmParent = this.GetComponentInParent<Farm>();
            farmParent.isDistroy = true;            //Farm 컴포넌트에 접근을 해서 isDistroy를 ture로 만들어 주면 Farm Object 파괴.

            Destroy(this);
        }
    }
}
