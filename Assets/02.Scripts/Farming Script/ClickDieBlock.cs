using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDieBlock : MonoBehaviour
{
    public GameObject parent;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){        //이걸 터치로 바꾸면 됌.
            Destroy(parent);
            Destroy(gameObject);          
        }
    }
}
