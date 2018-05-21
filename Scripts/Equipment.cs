using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName ="Inventory/Equipment")]

public class Equipment : Item {

    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;

    public override void Use(int indexOfSlot)
    {
        base.Use(indexOfSlot);
        EquipmentManager.instance.Equip(this, indexOfSlot);
    }
    public override void Remove(int indexOfSlot)
    {
        base.Remove(indexOfSlot);
        
        EquipmentManager.instance.Unequip((int)this.equipSlot, this.isDefaultItem, indexOfSlot);
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Feet, Back}