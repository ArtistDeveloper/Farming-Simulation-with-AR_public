using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BliudItemDB : MonoBehaviour
{
    public static BliudItemDB instance;
    private void Awake(){
        instance=this;
    }

    public List<BliudItem> bliudItemDB = new List<BliudItem>();
}
