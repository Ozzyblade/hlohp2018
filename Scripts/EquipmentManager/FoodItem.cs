using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Inventory/FoodItem")]
public class FoodItem : Item {

    //public Sprite sprite;
    //public PlayerStats playerStats;
    [SerializeField]
    private int healthBoost;
    PlayerManager playerManager;
    PlayerStats myStats;

    public override void Use()
    {
        base.Use();
        Debug.Log("Food Item: " + this.name);
        playerManager = PlayerManager.instance;
        myStats = playerManager.player.GetComponent<PlayerStats>();
        myStats.AddHealth(healthBoost);
        RemoveFromInventory();
        
    }
}
