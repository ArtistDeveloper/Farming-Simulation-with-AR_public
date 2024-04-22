using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockSlot slot;
    public int x = 0;
    public int z = 0;
    public string name = "Block";
    public int id = 0;
    public GameObject blockPrefab;
}
