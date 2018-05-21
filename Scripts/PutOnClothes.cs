using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOnClothes : MonoBehaviour {

    public SkinnedMeshRenderer targetMesh;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        PutOnClothing(numSlots);
    }
    public void PutOnClothing(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(SavingClothes.instance.equipedItems[i].mesh);
            newMesh.transform.parent = gameObject.transform;

            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
        }
        
    }
}
