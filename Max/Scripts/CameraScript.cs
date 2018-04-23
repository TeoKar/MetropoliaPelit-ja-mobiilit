using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Adapted from:
/// https://www.youtube.com/watch?v=Ta7v27yySKs
/// 
/// Author Max Nikander
/// Scripts for mouse input and camera movement.
/// </summary>

public class CameraScript : MonoBehaviour
{

    // Constants to limit camera movement
    private const float y_Axis_Min = 3;
    private const float y_Axis_Max = 50.0f;

    public Transform lookingAt;
    public Transform cameraTransform;

    private Camera MainCamera;

    // Constants to limit camera zoom
    private const float max_Zoom_Distance = 10.0f;
    private const float min_Zoom_Distance = 4.0f;

    private float currentDistance = 10.0f;
    private float currentXaxis = 0.0f;
    private float currentYaxis = 0.0f;


    [SerializeField] private float zoomSensitivity = -1.0f;
    [SerializeField] private float sensitivityXaxis = 4.0f;
    [SerializeField] private float sensitivityYaxis = 1.0f;

    Vector3 relativePos;
    public float distanceOffset;
    private PauseMenu pauseTools;
    /// <summary>
    /// Adds references to game objects.
    /// </summary>
    private void Start()
    {
        pauseTools = GameObject.Find("GameController").GetComponent<PauseMenu>();
        cameraTransform = transform;
        MainCamera = Camera.main;
    }
    /// <summary>
    /// Gets mouse inputs and clamps camera parameters.
    /// </summary>
    private void Update()
    {
        if (!pauseTools.GetpauseOn())
        {
            // User mouseinput for camera axisK
            currentXaxis += Input.GetAxis("Mouse X") * sensitivityXaxis;
            currentYaxis += Input.GetAxis("Mouse Y") * sensitivityYaxis;
            // Limits camera movement between constants
            currentYaxis = Mathf.Clamp(currentYaxis, y_Axis_Min, y_Axis_Max);

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            currentDistance = currentDistance + scroll * zoomSensitivity;
            currentDistance = Mathf.Clamp(currentDistance, min_Zoom_Distance, max_Zoom_Distance);


            /*
            RaycastHit hit;
            Debug.DrawLine(MainCamera.transform.position, lookingAt.position);
            if (Physics.Raycast(MainCamera.transform.position, lookingAt.position, out hit, currentDistance + 0.5f))
            {
                Debug.Log("Camera was hit");
                Debug.DrawLine(MainCamera.transform.position, hit.point);
                distanceOffset = currentDistance - hit.distance + 0.8f;
                distanceOffset = Mathf.Clamp(distanceOffset, 0, currentDistance);
            }
            else
            {
                distanceOffset = 0;

            }
            */
        }
    }
    /// <summary>
    /// Moves the camera according to mouse inputs.
    /// </summary>
    private void LateUpdate()
    {
        if (!pauseTools.GetpauseOn())
        {
            // Camera movement vector and rotation
            Vector3 direction = new Vector3(0, 0, -(currentDistance));
            Quaternion rotation = Quaternion.Euler(currentYaxis, currentXaxis, 0);
            cameraTransform.position = lookingAt.position + rotation * direction;
            cameraTransform.LookAt(lookingAt.position);
        }

    }
}


