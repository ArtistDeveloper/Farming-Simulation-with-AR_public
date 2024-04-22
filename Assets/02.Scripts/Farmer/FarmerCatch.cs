using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerCatch : MonoBehaviour
{
    [SerializeField] 
    Collider FarmerCollider;
    Renderer FarmerRenderer;
    Camera characterCamera;

    private void Awake(){
        characterCamera=GetComponentInChildren<Camera>();
    }
    // Start is called before the first frame update
    public void Lookatme(){
        Ray ray = characterCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitResult;

        if(Physics.Raycast(ray, out hitResult)){
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position; 
        }




    }
}
