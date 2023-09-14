using System;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class CameraMove : MonoBehaviour
{
    [Inject] private IUserInput userInput;//получим данные в структуре
    //
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private Transform targetObjedct;
    //
    private Quaternion originRotation;
    private float2 angle;
    private float mouseSensor;
    private float minStopAngle;
    private float maxStopAngle;
    //
    private Vector3 offset;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        //settings
        offset = cameraSettings.Offset;
        mouseSensor = cameraSettings.MouseSensor;
        minStopAngle = cameraSettings.MinStopAngle;
        maxStopAngle = cameraSettings.MaxStopAngle;
        //
        originRotation = transform.rotation;
    }

    void Update()
    {

        if (offset != cameraSettings.Offset)
        {
            offset = cameraSettings.Offset;
        }

        transform.position = targetObjedct.position + offset;

        angle += userInput.InputData.Mouse * mouseSensor;
        angle.y = Math.Clamp(angle.y, minStopAngle, maxStopAngle);

        Quaternion rotationY = Quaternion.AngleAxis(angle.x, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(angle.y, Vector3.right);

        transform.rotation = originRotation * rotationY * rotationX;
    }
}
