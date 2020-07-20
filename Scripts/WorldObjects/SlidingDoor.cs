using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider))]
public class SlidingDoor : MonoBehaviour {

    #region Vars
    Animator animator;
    BoxCollider triggerZone;
    bool doorOpen;

    const string open   = "Open";
    const string close  = "Close";
    #endregion

    #region Init
    void Start () {
        doorOpen = false;
        animator = GetComponent<Animator>();

        // Debugging
        triggerZone = GetComponent<BoxCollider>();
	}
    #endregion

    #region Set Door Params
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy") { 
            doorOpen = true;
            Doors(open);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            doorOpen = false;
            Doors(close);
        }
    }
    #endregion

    #region Anim Doors
    void Doors(string dir)
    {
        animator.SetTrigger(dir);
    }
    #endregion

    #region Debug
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.blue;
        //Gizmos.DrawWireCube(transform.position, triggerZone.size);
        
    }
    #endregion
}
