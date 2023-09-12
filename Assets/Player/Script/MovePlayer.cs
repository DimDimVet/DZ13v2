using System;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class MovePlayer : MonoBehaviour
{
    [Inject] private IUserInput userInput;//получим данные в структуре
    //
    public MoveSettings moveSettings;
    //
    private Quaternion originRotation;
    private float2 angle;

    private float mouseSensor;
    private float speedMove;
    private float minStopAngle;
    private float maxStopAngle;

    void Start()
    {
        //settings
        mouseSensor = moveSettings.MouseSensor;
        speedMove = moveSettings.SpeedMove;
        minStopAngle = moveSettings.MinStopAngle;
        maxStopAngle = moveSettings.MaxStopAngle;
        //
        originRotation = transform.rotation;
    }

    void Update()
    {

        angle += userInput.InputData.Mouse * mouseSensor;
        angle.y = Math.Clamp(angle.y, minStopAngle, maxStopAngle);

        Quaternion rotationY = Quaternion.AngleAxis(angle.x, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(angle.y, Vector3.right);

        transform.rotation = originRotation * rotationY * rotationX;

        if (userInput.InputData.Move.y > 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition += transform.forward / speedMove;
            transform.position = currentPosition;
        }
        if (userInput.InputData.Move.y < 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition -= transform.forward / speedMove;
            transform.position = currentPosition;
        }

        if (userInput.InputData.Move.x > 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition += transform.right / speedMove;
            transform.position = currentPosition;
        }
        if (userInput.InputData.Move.x < 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition -= transform.right / speedMove;
            transform.position = currentPosition;
        }

    }
}

