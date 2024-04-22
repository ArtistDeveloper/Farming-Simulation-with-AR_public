using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSound : MonoBehaviour
{
    public Slider sld;
    AudioSource audiosource;

    private float backVol;
    
    void Awake()
    {
        if (backVol != null)
        {
            backVol = PlayerPrefs.GetFloat("main_bgm");
        }
        Debug.Log("volume : " + backVol);
        sld.value = backVol;
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("main_bgm", sld.value);

        if (audiosource != null)
            audiosource.volume = PlayerPrefs.GetFloat("main_bgm");
        
    }


}
