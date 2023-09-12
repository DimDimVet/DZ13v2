using System;
using System.Collections;
using System.Collections.Generic;
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
    private float mouseSens = 0.5f;
    private float stopFactor = 100;

    void Start()
    {

        originRotation = transform.rotation;
    }

    //мыш

    void Update()
    {
        //inputData = userInput.InputData;
        //Debug.Log(userInput.InputData);
        //inputData.Move = userInput.moveInput;
        //inputData.Mouse = userInput.mouseInput;

        angle += userInput.InputData.Mouse * mouseSens;
        angle.y = Math.Clamp(angle.y, -60, 60);

        Quaternion rotationY = Quaternion.AngleAxis(angle.x, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(angle.y, Vector3.right);

        transform.rotation = originRotation * rotationY * rotationX;


        if (userInput.InputData.Move.y > 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition += transform.forward / stopFactor;
            transform.position = currentPosition;
        }
        if (userInput.InputData.Move.y < 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition -= transform.forward / stopFactor;
            transform.position = currentPosition;
        }

        if (userInput.InputData.Move.x > 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition += transform.right / stopFactor;
            transform.position = currentPosition;
        }
        if (userInput.InputData.Move.x < 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition -= transform.right / stopFactor;
            transform.position = currentPosition;
        }
        //moveData.MoveSpeed = Speed / 100;
        //if (transform == null)
        //{
        //    return;
        //}

        //Vector3 currentPosition = transform.position;
        //currentPosition += new Vector3(inputData.Move.x * moveData.MoveSpeed, 0, inputData.Move.y * moveData.MoveSpeed);
        //transform.position = currentPosition;

        //Vector3 dir = new Vector3(inputData.Mouse.x, inputData.Mouse.y, 0);
        //if (dir == Vector3.zero)
        //{
        //    return;
        //}

        //Quaternion currentRotation = transform.rotation;
        //Quaternion newRotation = Quaternion.LookRotation(Vector3.Normalize(dir));
        //if (newRotation == currentRotation)
        //{
        //    return;
        //}

        //Quaternion tempRotation = Quaternion.Lerp(currentRotation, newRotation, Time.deltaTime * 10);
        //if (Math.Abs(tempRotation.y) <= 0.5)
        //{
        //    if (Math.Abs(tempRotation.x) <= 0.3)
        //    {
        //        tempRotation.z = 0;
        //        transform.rotation = tempRotation;
        //        Debug.Log(transform.rotation.z);
        //    }

        //}
        //else
        //{
        //    return;
        //}
    }
}



public struct MoveData
{
    public float MoveSpeed;

}