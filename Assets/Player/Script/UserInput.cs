using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    //создадим переменую MapCurrent(new input)
    private MapCurrent inputAction;
    public float2 moveInput;
    public float2 mouseInput;
    void Start()
    {
        inputAction = new MapCurrent();//инициализируем карту input

        //подпишем на event события нажатий и значения присвоим локальным переменым
        inputAction.UIMap.WASD.performed += context => { moveInput = context.ReadValue<Vector2>(); };
        inputAction.UIMap.WASD.started += context => { moveInput = context.ReadValue<Vector2>(); };
        inputAction.UIMap.WASD.canceled += context => { moveInput = context.ReadValue<Vector2>(); };

        inputAction.Map.WASD.performed += context => { moveInput = context.ReadValue<Vector2>(); };
        inputAction.Map.WASD.started += context => { moveInput = context.ReadValue<Vector2>(); };
        inputAction.Map.WASD.canceled += context => { moveInput = context.ReadValue<Vector2>(); };

        inputAction.Map.Look.performed += context => { mouseInput = context.ReadValue<Vector2>(); };
        inputAction.Map.Look.started += context => { mouseInput = context.ReadValue<Vector2>(); };
        inputAction.Map.Look.canceled += context => { mouseInput = context.ReadValue<Vector2>(); };
        //запустим 
        inputAction.Enable();
        //Debug.Log(moveInput);
    }


    void Update()
    {

        //Debug.Log(mouseInput);
    }
}
