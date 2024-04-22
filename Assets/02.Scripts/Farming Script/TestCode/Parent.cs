using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{
    public int parentInt = 126;

    void Awake(){
        //Debug.Log("부모");
        parentInt = 1234;
    }
}
