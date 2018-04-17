using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Adapted from 
 * https://www.youtube.com/watch?v=Ta7v27yySKs
*/
public class CameraScript : MonoBehaviour {

    // Constants to limit camera movement
    private const float y_Axis_Min = 0.0f;
    private const float y_Axis_Max = 50.0f;

    public Transform lookingAt;
    public Transform cameraTransform;

    private Camera MainCamera;

    private float distance = 10.0f;
    private float currentXaxis = 0.0f;
    private float currentYaxis = 0.0f;
    private float sensitivityXaxis = 4.0f;
    private float sensitivityYaxis = 1.0f;

    private void Start()
    {

        // 
        cameraTransform = transform;
        MainCamera = Camera.main;
    }

    private void Update()
    {
        // User mouseinput for camera axis
        currentXaxis += Input.GetAxis("Mouse X");
        currentYaxis += Input.GetAxis("Mouse Y");
        // Limits camera movement between constants
        currentYaxis = Mathf.Clamp(currentYaxis, y_Axis_Min, y_Axis_Max);
    }

    private void LateUpdate()
    {
        // Camera movement vector and rotation
        Vector3 direction = new Vector3(0, 0, -distance);   
        Quaternion rotation = Quaternion.Euler(currentYaxis, currentXaxis, 0);
        cameraTransform.position = lookingAt.position + rotation * direction;
        cameraTransform.LookAt(lookingAt.position);

    }
}


