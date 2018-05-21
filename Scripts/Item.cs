﻿using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;


    public virtual void Use(int indexOfslot)
    {
        Debug.Log("Using " + name);
    }
    
    public virtual void Remove(int indexOfSlot)
    {
        Debug.Log("Unequiping" + name);
    }
}
