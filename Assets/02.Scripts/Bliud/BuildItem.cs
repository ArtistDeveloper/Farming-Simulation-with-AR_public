using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    Epuipment,
    Consumables,
    Etc
}

[System.Serializable]
public class BliudItem{
    public ItemType itemType;
    public string itemname;
    public Sprite itemImage;

    public bool Use(){
        return false;
    }
}