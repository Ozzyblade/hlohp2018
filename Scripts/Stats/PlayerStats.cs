using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

	// Use this for initialization
	void Start () {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}
	
	void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armourModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifer(oldItem.armourModifier);
            damage.RemoveModifer(oldItem.damageModifier);
        }
    }

    public void AddHealth(int health)
    {
        if (currentHealth + health >= maxHealth)
        {
            currentHealth = maxHealth;
            Debug.Log("Added: " + health + " health. Current health: " + currentHealth);
        }
         else
        {
            currentHealth += health;
            Debug.Log("Added: " + health + " health. Current health: " + currentHealth);
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range.GetValue());
    }
}
