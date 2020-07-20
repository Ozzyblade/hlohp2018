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

    Equipment[]             currentEquipment;
    Sprite[]                currentSprites;
    Inventory               inventory;
    //public SpriteRenderer   targetSprite;
    EquipLocalManager equipLocalManager;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    private void Start()
    {
        int noSlots         = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment    = new Equipment[noSlots];

        inventory           = Inventory.instance;
        currentSprites      = new Sprite[noSlots];

        equipLocalManager = EquipLocalManager.instance;
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex       = (int)newItem.equipmentSlot;
        Equipment oldItem   = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(newItem, oldItem);

        currentEquipment[slotIndex] = newItem;

        Sprite newSprite    = Instantiate<Sprite>(newItem.sprite);
        equipLocalManager.SetLocalPos(newItem, newSprite);
        currentSprites[slotIndex]   = newSprite;
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentSprites[slotIndex] != null)
            {
                //Destroy(currentSprites[slotIndex].gameObject);
            }
            Equipment oldItem           = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
                onEquipmentChanged.Invoke(null, oldItem);
        }

    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }

}
