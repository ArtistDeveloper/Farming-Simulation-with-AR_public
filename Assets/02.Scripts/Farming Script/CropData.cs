using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "Farm Game/Crop", order = 2)]

public class CropData : ScriptableObject
{
    public string name = "Crop";
    public GameObject CropPrefab;
    public GameObject witheredPrefab;

    public float maxGrowth = 100f;
    public float growthRate = 10f;
    public float maxHealth = 100.0f;
}
