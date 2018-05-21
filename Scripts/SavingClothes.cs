using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingClothes : MonoBehaviour {

    #region Singleton
    public static SavingClothes instance;

    private void Awake()
    {
        //instance = this;
        if (instance==null)
        {
            DontDestroyOnLoad(gameObject);
            //created = true;
            instance = this;
            Debug.Log("Awake: " + gameObject);
            
        }
        else if(instance !=this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    //public GameObject player;
    public SkinnedMeshRenderer[] equipedMeshes;
    public Equipment[] equipedItems;
    public int[] indeksuMasyvas;
    //private static bool created = false;
    // Use this for initialization
    void Start () {
        //int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        //equipedMeshes = new SkinnedMeshRenderer[numSlots];
        //equipedMeshes = player.GetComponent<EquipmentManager>().currentMeshes;
	}
    /*
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }
    */
    public void UpdateEquipedMeshes()
    {
        equipedMeshes = EquipmentManager.instance.currentMeshes;
    }
}
