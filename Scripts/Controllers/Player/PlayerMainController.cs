using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerMoveController))]
public class PlayerMainController : MonoBehaviour
{

    public Interactable focus;

    public LayerMask layerMask;
    Camera cam;
    PlayerMoveController moveController;
    Animator anim;
    public GameObject testBullet;
    public Transform muzzleLocal;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        moveController = GetComponent<PlayerMoveController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetKeyDown(KeyCode.Y))
        {
            anim.SetTrigger("Shoot");
            //Instantiate(testBullet,)
        }

        HandleControlInputs();
    }

    void HandleControlInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetMovePos();
            RemoveFocus();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    void GetMovePos()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            // Move the player
            //Debug.Log(hit.collider.name + " " + hit.point);
            moveController.MoveToPoint(hit.point);
            // De-focus objects
        }
    }

    void Interact()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                SetFocus(interactable);
            }
        }
    }

    void SetFocus(Interactable nFocus)
    {

        if (nFocus != focus)
        {
            if (focus != null)
                focus.OnDeFocus();

            focus = nFocus;
            moveController.FollowTarget(nFocus);
        }

        nFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDeFocus();

        focus = null;
        moveController.UnFollowTarget();
    }
}
