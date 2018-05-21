using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour {

    #region Singleton
    public static Store instance;
    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();

}
