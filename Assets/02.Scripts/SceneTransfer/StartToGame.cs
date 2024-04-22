using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartToGame : MonoBehaviour
{
    public void OnClickTocuhToStart()
    {
        SceneManager.LoadScene("Farming Simulation");
        //Debug.Log("씬 넘어감.");
    }
}
