using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArIndicator;

namespace PlaneOnObject
{
    public class Farmer : MonoBehaviour
    {
        //static영역이라 프리팹에 할당되기 이전에 초기화되서 farmer가 안뜨는 듯
        public GameObject farmerPrefab;
        public static GameObject staticFarmer; 

        void Awake()
        {
            ARTapToPlaceObject aRTapToPlace = GameObject.FindGameObjectWithTag("ARinteraction").GetComponent<ARTapToPlaceObject>();
            aRTapToPlace.planeOnObjectDelegate += FarmerInstantiate;
        }        

        void Start()
        {
            staticFarmer = farmerPrefab;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public static void FarmerInstantiate(Vector3 planeTransformPosition, Quaternion rotation)
        {
           Vector3 yUpperPos = planeTransformPosition;
           yUpperPos.y += 0.5f;
           Instantiate(staticFarmer, yUpperPos, staticFarmer.transform.rotation); 
        }
    }
}