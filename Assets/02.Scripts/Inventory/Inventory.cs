using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake(){
        if(instance!=null){
            Destroy(gameObject);
        }
    }
    #endregion

    public delegate void OnBoxCountChange(int val);
    public OnBoxCountChange onBoxCountChange;

    private int boxCount;

    public int BoxCount{
        get => boxCount;
        set{
            boxCount=value;
            onBoxCountChange.Invoke(boxCount);
        }
    }
    
    void Start()
    {
       boxCount=5;        
    }

    void Update()
    {
        
    }
}
