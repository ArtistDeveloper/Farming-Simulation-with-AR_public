using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//이걸 지금 SaveManager에 넣어서 1번만?실행시키고 싶...은데... 이거는... 음...

public class CropTime : CropSaveLoad      
{
    //이 이후에는 시간 관련 변수들
    private DateTime m_AppQuitTime = new DateTime(1970, 1, 1).ToLocalTime();  //이건 나가는 시간이고 꼭 필요함!
    private CropLogic cropLogic;
    private bool frist = true;
    void Start(){
        LoadAppQuitTime();
        //Debug.Log("CropTime에서 LaodApplication 수행");
        //Debug.Log("CropTime에서 LoadAppQuitTime 실행 후 값: "+ m_AppQuitTime);
        LoadCrop();
        //Debug.Log("LaodCrop Awake에서 실행.");
    }

    //게임 초기화(Awake), 중간 이탈, 중간 복귀 시 실행되는 함수
    public void OnApplicationFocus(bool value){
        if (value)
        {  
            if(frist != true){
                //Debug.Log("Crop OnApplicationFocus true 실행");
                LoadCrop();             //이까진 됐음.      - 잘 들고 온다.   
                //Debug.Log("Save된 Crop Time을 들고옴.");    
                LoadAppQuitTime();      //그래서 그만둔 시간만 들고옴.       - 잘들고 온다. 
            }else{
                frist = false;
            }                  
        }
        else    //이탈 시 실행
        {
            //Debug.Log("Crop OnApplicationFocus false 실행");
            SaveCrop();
            SaveAppQuitTime();
        }
    }

    //게임 종료 시 실행되는 함수
    public void OnApplicationQuit()
    {
        SaveCrop();
        SaveAppQuitTime();
    }

    public bool SaveAppQuitTime()           //나간 시간 저장
    {
        bool result = false;
        try
        {
            var appQuitTime = DateTime.Now.ToLocalTime().ToBinary().ToString();     
            PlayerPrefs.SetString("AppQuitTime", appQuitTime);
            PlayerPrefs.Save();

            //Debug.Log("Save AppQuitTime : " + DateTime.Now.ToLocalTime().ToString());
            result = true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("SaveAppQuitTime Failed (" + e.Message + ")");
        }
        return result;
    }

    public bool LoadAppQuitTime()       
    {
        bool result = false;
        try
        {
            if (PlayerPrefs.HasKey("AppQuitTime"))      //처음에는 없어도 ㄱㅊ 노상관임.
            {
                var appQuitTime = string.Empty;
                appQuitTime = PlayerPrefs.GetString("AppQuitTime");                
                m_AppQuitTime = DateTime.FromBinary(Convert.ToInt64(appQuitTime));      //바이너리 값을 불러온다.
                //Debug.Log("Load Saved m_AppQuitTime: "+ m_AppQuitTime);
            }else{
                m_AppQuitTime = DateTime.Now.ToLocalTime();
            }

            result = true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("LoadAppQuitTime Failed (" + e.Message + ")");
        }
        return result;
    }

    public DateTime get_m_AppQuitTime(){
        return m_AppQuitTime;
    }
}
