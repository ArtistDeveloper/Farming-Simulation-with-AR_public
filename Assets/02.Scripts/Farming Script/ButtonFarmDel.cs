using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFarmDel : MonoBehaviour
{
    public void OnClickThis(){
        if(GameObject.Find("ZFarmEx(Clone)")){
            GameObject delTarget = GameObject.Find("ZFarmEx(Clone)");
            Destroy(delTarget);
        }
    }
}
