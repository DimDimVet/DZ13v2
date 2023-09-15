using System;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class CameraMove : MonoBehaviour
{
    [Inject] private IUserInput userInput;//получим данные управлени в структуре
    [Inject] private ICameraData cameraData;//будем в нее передавать
    //
    [SerializeField] private CameraSettings cameraSettings;

    private float2 angle;
    private float yRot;
    private float mouseSensor;
    private float minStopAngle;
    private float maxStopAngle;
    private Vector3 setPos;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        setPos=transform.position;
        //settings
        mouseSensor = cameraSettings.MouseSensor;
        minStopAngle = cameraSettings.MinStopAngle;
        maxStopAngle = cameraSettings.MaxStopAngle;
        //
        //originRotation = transform.rotation;
    }

    void Update()
    {
        angle= userInput.InputData.Mouse * mouseSensor*Time.deltaTime;
        yRot-=angle.y;
        yRot=Math.Clamp(yRot, minStopAngle, maxStopAngle);
        transform.localRotation=Quaternion.Euler(yRot, 0, 0);

        cameraData.CameraAngle=angle;//передадим углы 
        if (cameraData.TransformCamera!=null)
        {
            transform.position =cameraData.TransformCamera.position/*+setPos*/;//получим позицию объекта привязки
            transform.rotation=cameraData.TransformCamera.rotation;
        }

    }
}
