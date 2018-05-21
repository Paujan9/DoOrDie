using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public SkinnedMeshRenderer targetMesh;
    public Equipment[] currentEquipment;
    public SkinnedMeshRenderer[] currentMeshes;
    public SkinnedMeshRenderer[] defaultMeshes;
    public Equipment[] defaultEquipment;
    //int[] indeksuMasyvas;

    //Drabuziu saugojimui kitoje scenoje:
    //public GameObject drabuziuSaugotojas;


    private void Start()
    {
        //indeksuMasyvas = new int[4];
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];

        for (int i = 0; i < numSlots; i++)
        {
            currentEquipment[i] = SavingClothes.instance.equipedItems[i];
            SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(SavingClothes.instance.equipedItems[i].mesh);
            newMesh.transform.parent = targetMesh.transform;

            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
            currentMeshes[i] = newMesh;
            //SavingClothes.instance.equipedMeshes[i] = newMesh;
        }
    }

    public void Equip( Equipment newItem, int indexOfSlot)
    {
        int slotIndex = (int)newItem.equipSlot;
        //indeksuMasyvas[slotIndex] = indexOfSlot;
        SavingClothes.instance.indeksuMasyvas[slotIndex] = indexOfSlot;
        if(currentEquipment[slotIndex]!=null)
        {

        }
        //if (currentEquipment[slotIndex] == null)
        //{
        //Unequip((int)newItem.equipSlot, newItem.isDefaultItem);
        //Unequip((int)currentEquipment[slotIndex].equipSlot, currentEquipment[slotIndex].isDefaultItem);
        if (newItem != currentEquipment[slotIndex])
        {
            Unequip(slotIndex, currentEquipment[slotIndex].isDefaultItem, indexOfSlot);
            if(currentEquipment[slotIndex]==defaultEquipment[slotIndex])
                Destroy(currentMeshes[slotIndex].gameObject);
            currentEquipment[slotIndex] = newItem;

            SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
            newMesh.transform.parent = targetMesh.transform;

            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
            currentMeshes[slotIndex] = newMesh;
        }
        //}
        UpdateEquiped();
        //SavingClothes.instance.equipedMeshes = currentMeshes;
    }

    public void Unequip(int slotIndex, bool isDefault, int indexOfSlot)
    {
        
        if(isDefault)
        {
            if (currentEquipment[slotIndex] != null)
            {
                if (currentMeshes[slotIndex] != null)
                {
                    Destroy(currentMeshes[slotIndex].gameObject);
                }
                currentEquipment[slotIndex] = null;
            }
        }
        //else if(indeksuMasyvas[slotIndex]==indexOfSlot)
        else if(SavingClothes.instance.indeksuMasyvas[slotIndex] == indexOfSlot)
        {
            currentEquipment[slotIndex] = defaultEquipment[slotIndex];
            Destroy(currentMeshes[slotIndex].gameObject);
            //currentMeshes[slotIndex] = defaultMeshes[slotIndex];
            SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(defaultMeshes[slotIndex]);
            newMesh.transform.parent = targetMesh.transform;

            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
            currentMeshes[slotIndex] = newMesh;
        }
        UpdateEquiped();
    }

    public void UpdateEquiped()
    {
        for (int i = 0; i < currentMeshes.Length; i++)
        {
            SavingClothes.instance.equipedMeshes[i] = currentMeshes[i];
            SavingClothes.instance.equipedItems[i] = currentEquipment[i];
        }
        
    }
}
