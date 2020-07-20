using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Spawner : MonoBehaviour {

    public Equipment[] objs;
    public GameObject g;
    private Equipment spawnItem;
    
	// Use this for initialization
	void Start () {

        //select random item to spawn
        spawnItem = objs[Random.Range(0, objs.Length)];
        Debug.Log(spawnItem.name);
        

        //spawn item
        g.GetComponent<ItemPickup>().setItem(spawnItem, transform.position);
        Instantiate(g, this.transform);
        
    }
	
    void awake()
    {
        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
