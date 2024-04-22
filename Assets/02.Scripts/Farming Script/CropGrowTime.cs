using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//이게 실제 작물에 넣을 코드임.

public class CropGrowTime : MonoBehaviour
{
    //여기를 종류별로 다르게 지정을 해주면 된다. -> 자라는 시간 같은 경우를 말하고 있는 것임.

    private CropLogic cropLogic;
    private CropState cropState;

    private Coroutine m_RechargeTimerCoroutine = null;
    public int timeMaxGrowInterval = 60; //다 자르는데 걸리는 시간. 
    public int remainGrowTime = 60;       
    public DateTime m_AppQuitTime = new DateTime(1970, 1, 1).ToLocalTime();
    private DateTime check_m_AppQuitTime = new DateTime(1970, 1, 1).ToLocalTime();      //체크용 시간. 이거 없으면 이상한 버그 발생함.
    private bool set_check = false;
    private GameObject cropTime;
    public bool witherOrGather = false;        //썩거나 뽑히면 true;
    
    private bool startBoolConduct = false;

    void Awake(){
        cropState = gameObject.GetComponent<CropState>();
    }

    void OnApplicationFocus(bool value){
        //Debug.Log("CropGrowTime의 OnApplication 실행");
        if (value)
        {   
            set_check = true;
        }
    }

    void Start(){       //이걸  Update로 옮기고...
        // cropTime = GameObject.FindWithTag("SaveManager");       //이게 null은 아님.
        // m_AppQuitTime = cropTime.GetComponent<CropTime>().get_m_AppQuitTime();
        // SetRechargeScheduler();     //처음엔 여기서 시작.
        // set_check = false;
    }

    void Update(){
        if(!startBoolConduct){
            startBoolConduct = true;
            cropTime = GameObject.FindWithTag("SaveManager");       //이게 null은 아님.
            m_AppQuitTime = cropTime.GetComponent<CropTime>().get_m_AppQuitTime();
            //Debug.Log("CropGrowTime에서의 m_AppQuitTime" + m_AppQuitTime);
            SetRechargeScheduler();     //처음엔 여기서 시작.
            set_check = false;
        }

        if(set_check){
            SetRechargeScheduler();
            set_check = false;
        }

        if(witherOrGather){
            Destroy(this);
        }
    }

    void OnDestory(){
        witherOrGather = true;
    }

    public void SetRechargeScheduler(Action onFinish = null)
    {
        if(m_AppQuitTime == check_m_AppQuitTime){       //여기 같으면 return하도록 했음 그냥.
                Debug.Log("m_AppQuitTime: " + m_AppQuitTime);
                return;
        }

        if (m_RechargeTimerCoroutine != null)
        {        
            StopCoroutine(m_RechargeTimerCoroutine);
        }

        m_AppQuitTime = cropTime.GetComponent<CropTime>().get_m_AppQuitTime();
        
        if(remainGrowTime != timeMaxGrowInterval){               
            var timeDifferenceInSec = (int)((DateTime.Now.ToLocalTime() - m_AppQuitTime).TotalSeconds);    //지금 시간이랑 앱을 껐을 떄의 시간을 뺀 값이 들어가게 된다.            
            var remainTime = remainGrowTime - timeDifferenceInSec;  
            if (remainTime <= timeMaxGrowInterval)      
            {
                //Debug.Log("DoRechargeTimer 진입 전");
                m_RechargeTimerCoroutine = StartCoroutine(DoRechargeTimer(remainTime, onFinish));
            }
        }else       //remainGrowTime == timeMaxGrowInterval로 새로 생겼다는 의미
        {
            Debug.Log("처음 만들어짐");
            var remainTime = remainGrowTime;        //이게 들어가도 상관이 없는게 결국 Awake에서 timeMax로 조절을 해줘서 상관없음.
            if (remainTime <= timeMaxGrowInterval)      
            {
                //Debug.Log("DoRechargeTimer 진입 전");
                m_RechargeTimerCoroutine = StartCoroutine(DoRechargeTimer(remainTime, onFinish));
            }
        }
    }

    private IEnumerator DoRechargeTimer(int remainTime, Action onFinish = null)
    {
        //Debug.Log("DoRechargeTimer 진입");
        if (remainTime <= 0)            //즉 남은시간이 없다. 다 자랐다.
        {
            remainGrowTime = 0;
        }
        else //remainTime > 0
        {
            remainGrowTime = remainTime;
        }
      
        while (remainGrowTime > 0)        //다 자랄때까지 시간이 남았을 때 돌리는 while이고 1초씩 기다리면서 1f씩 줄인다. 
        {
            //Debug.Log("CropGrowingTimer : " + remainGrowTime + "s");
            remainGrowTime -= 1;
            yield return new WaitForSeconds(1f);        //결국 마지막에는 remainGrowTime = 0이 된다.
        }

        if(remainGrowTime <= 0){
            if(cropState != null){
                cropState.GrowDone();         
            }else{
                Debug.Log("cropState를 들고오지 못함");    
            }
        }
    }

    public int getRemainGrowTime(){
        return remainGrowTime;
    }
    public int getTimeMaxGrowInterval(){
        return timeMaxGrowInterval;
    }

}
