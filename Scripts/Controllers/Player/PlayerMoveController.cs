using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMoveController : MonoBehaviour {

    //setup linerenderer
    LineRenderer lineRenderer;
    Color lineRendererOriginalColor;

    NavMeshAgent navAgent;
    [SerializeField] private bool updateSpriteRotation = false;
    [SerializeField] private bool showPaths = true;

    Transform target;

    public GameObject gfx;

    // Use this for initialization
    void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = updateSpriteRotation;
        
        lineRenderer = GetComponent<LineRenderer>();
        lineRendererOriginalColor = lineRenderer.startColor;
        lineRenderer.material.color = Color.green;
    }

    public void MoveToPoint(Vector3 _point)
    {
        navAgent.SetDestination(_point);
    }

    public void FollowTarget(Interactable nTarget)
    {
        navAgent.stoppingDistance = nTarget.radius * .8f;
        target = nTarget.interactionTransform;
    }

    public void UnFollowTarget()
    {
        navAgent.stoppingDistance = 0f;
        target = null;
    }

    Vector3 previousLocation = Vector3.zero;

    void Update()
    {
        if (navAgent.hasPath && showPaths)
        {
            EnableNavAgentPath();
        }
        else
        {
            DisableNavAgentPath();
        }

        if (target != null)
        {
            navAgent.SetDestination(target.position);
        }

        Vector3 currentVel = (transform.position - previousLocation) / Time.deltaTime;

        if (currentVel.x > 0)
        {
            Debug.Log("Right");
            gfx.transform.rotation = Quaternion.Euler(90, 0, 0);
           
        } else
        {
            Debug.Log("Left");
            gfx.transform.rotation = Quaternion.Euler(270, 90, 90);
        }
    }

    void EnableNavAgentPath()
    {
        lineRenderer.positionCount = navAgent.path.corners.Length;
        lineRenderer.SetPositions(navAgent.path.corners);
        lineRenderer.enabled = true;
    }

    void DisableNavAgentPath() {
        lineRenderer.enabled = false;
    }
}
