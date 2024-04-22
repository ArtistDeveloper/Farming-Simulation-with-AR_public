using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSlot
{
    public GameObject slotPrefab;
    public BlockSlockType slotType;
}

public enum BlockSlockType
{
    CROP,
    STRUCTURE
}