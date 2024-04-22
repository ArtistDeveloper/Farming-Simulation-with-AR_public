using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Block", menuName="Farm Game/Block", order=1)]
public class BlockData : ScriptableObject
{
    //Asset하위에 Blocks를 만들어야함.
    public GameObject blockPrefab;
    public string name = "Block"; 
}