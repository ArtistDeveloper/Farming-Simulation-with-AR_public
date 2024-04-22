using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newnew : MonoBehaviour
{
    [SerializeField]private Transform characterBody;

    [SerializeField]private Transform cameraArm;


    Animator animator;



    void Start() {

        animator = characterBody.GetComponent<Animator>();

    }

    private void LookAround(){

    Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

    Vector3 camAngle = cameraArm.rotation.eulerAngles;

    float x = camAngle.x - mouseDelta.y;



    if (x < 180f){
        x = Mathf.Clamp(x, -1f, 70f);
    }

    else{
        x = Mathf.Clamp(x, 335f, 361f);
    }

    cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);

}
private void Move(){

    Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    bool isMove = moveInput.magnitude != 0;

    animator.SetBool("isMove", isMove);

    if (isMove)

    {

        Vector3 lookback = new Vector3(-cameraArm.forward.x, 0f, -cameraArm.forward.z).normalized;

        Vector3 lookRight = new Vector3(-cameraArm.right.x, 0f, -cameraArm.right.z).normalized;

        Vector3 moveDir = lookback * moveInput.y + lookRight * moveInput.x;



        characterBody.forward= lookback;

        transform.position += moveDir * Time.deltaTime* 5f;

    }

}




void Update(){

    LookAround();
    Move();
    if(Input.GetMouseButtonDown(0)){
    RaycastHit hit;

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if(Physics.Raycast(ray, out hit,100.0f)){
            if(hit.transform != null){
                PrintName(hit.transform.gameObject);
            }

        }
    }

}
private void PrintName(GameObject go){
    print(go.name);
    if(go.name=="Cube"){click();}
        
}
private void click(){


    animator.SetTrigger("clickon");


        Vector3 lookback = new Vector3(-cameraArm.forward.x, 0f, -cameraArm.forward.z).normalized;
       //Vector3 lookRight = new Vector3(-cameraArm.right.x, 0f, -cameraArm.right.z).normalized;
        
        characterBody.forward= lookback;
        //*Time.deltaTime * 5f;

}
   


}

