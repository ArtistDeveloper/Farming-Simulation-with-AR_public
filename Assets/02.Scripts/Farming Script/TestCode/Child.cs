using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
   void Awake(){
       //Debug.Log("애");
   }

   void Start(){
       int childNum = gameObject.GetComponentInParent<Parent>().parentInt;
       Debug.Log(childNum);
   }
}
