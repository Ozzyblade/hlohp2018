using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3.0f;
    bool isFocus = false;
    bool hasInteracted = false;
    Transform player;
    public Transform interactionTransform;

    public virtual void Interact()
    {
        Debug.Log("Interacting with: " + transform.name);
    }

    private void Start()
    {
        if (interactionTransform == null)
            interactionTransform = this.transform;
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocus()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        } 
    }

    void OnDrawGizmos()
    {
        if (interactionTransform == null)
            interactionTransform = this.transform;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
