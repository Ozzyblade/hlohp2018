using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //Customizable settings from the editor
    [Header("Camera Settings")]
    public Vector3 cameraStartingOffset = new Vector3(0, 10, 0);
    [SerializeField] private float smoothingSpeed = 0.125f;
    [SerializeField] private float cameraMoveSpeed = 20.0f;
    [SerializeField] private float zoomInputMultiplier = 2.0f;

    Vector3 cameraOffSet;
    Vector3 focusCamera;
    GameObject player;
    GameObject focus;
    Transform focusLocation;
    Vector3 camPos;
    bool cameraHasFocus = true;

    // Use this for initialization
    void Start () {
        cameraOffSet = cameraStartingOffset;
        
        player = GameObject.FindGameObjectWithTag("Player");
        focusLocation = player.transform;
        focus = player;

        camPos = focusLocation.position;
    }

    private void Update()
    {

       
        if (focus != null)
        {
            cameraOffSet.x      = cameraStartingOffset.x;
            cameraOffSet.z      = cameraStartingOffset.z;

            Vector3 desiredPos  = focusLocation.position + cameraOffSet;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothingSpeed);

            transform.position = smoothedPos;
        } else
        {
            transform.position = cameraOffSet;
        }

        if (Input.GetKey(KeyCode.W))
        {
            DeFocusCamera();
            cameraOffSet.z += cameraMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            DeFocusCamera();
            cameraOffSet.x -= cameraMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            DeFocusCamera();
            cameraOffSet.z -= cameraMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            DeFocusCamera();
            cameraOffSet.x += cameraMoveSpeed * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
            cameraOffSet.y += Input.GetAxisRaw("Mouse ScrollWheel") * -zoomInputMultiplier;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (focus == null)
            {
                focus = player;
            }
        }

    }

    void DeFocusCamera()
    {
        focus = null;
    }
}
