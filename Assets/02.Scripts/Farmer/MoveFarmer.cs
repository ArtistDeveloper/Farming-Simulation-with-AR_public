using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMesh))]     //컴포넌트 자동 저장.
public class MoveFarmer : MonoBehaviour
{
    public List<Transform> wayPoints;
    public int nextIdx;
    private NavMeshAgent farmer;
    public float moveSpeed = 10;
    private Animator animator;
    //private readonly int isMove = Animator.StringToHash("isMove");

    public NavMeshAgent Farmer
    {
        get { return farmer; }
        set { farmer = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        farmer = GetComponent<NavMeshAgent>();
        farmer.autoBraking = false;     //목적지에 가까워질수록 속도를 줄이는 옵션 활성화
        farmer.speed = moveSpeed;
        animator = gameObject.GetComponent<Animator>();

        var group = GameObject.Find("WayPointGroup");
        if(group != null){
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);      //이거 있는 이유: GetComponenesInChidren함수는 추출하고 싶은 컴포넌트가 부모한테도 있으면 뽑아오기 때문에 부모에 있는거 삭제하려고 있음.
        }

        MoveWayPoint();
    }

    void MoveWayPoint(){
        if(farmer.isPathStale) {
            Debug.Log("최단 경로 계산 안됨.");
            return;      //최단 경로 계산 안됬으면 반환
        }
        //animator.SetBool(isMove, true);

        farmer.destination = wayPoints[nextIdx].position;
        farmer.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        //farmer가 이동 또는 목적지에 도착했는지 알려고 한 코드
        if(farmer.velocity.sqrMagnitude >= 0.2f * 0.2f && farmer.remainingDistance <=1.0f){
            //다음 목적지 계산
            nextIdx = ++nextIdx % wayPoints.Count;
            MoveWayPoint();
        }
    }
}
