using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipmentSlot;
    public Sprite sprite;
    public int armourModifier;
    public int damageModifier;
    public int range;

    public override void Use()
    {
        base.Use();
        //Equip the item
        EquipmentManager.instance.Equip(this);
        //Remove from inventory
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Hair, Eyes, Mouth, FacialHair, Head, Body, Helmet, BodyArmor, Melee, Gun};
