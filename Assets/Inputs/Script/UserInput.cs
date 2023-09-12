using UnityEngine;
using Zenject;

public class UserInput : MonoBehaviour
{
    [Inject] private IUserInput userInput;//отправим данные в конструкторе

    public bool DebugLogOnOff;//для тестов
    //Подключим класс MapCurrent(new input)
    private MapCurrent inputAction;
    private InputData inputData;

    void Start()
    {
        inputAction = new MapCurrent();//инициализируем карту input
        inputData=new InputData();
        
        if (inputAction!=null)//проверим на null
        {
            //подпишем на event события нажатий и значения присвоим локальным переменым
            inputAction.UIMap.WASD.performed += context => { inputData.Move = context.ReadValue<Vector2>(); };
            inputAction.UIMap.WASD.started += context => { inputData.Move = context.ReadValue<Vector2>(); };
            inputAction.UIMap.WASD.canceled += context => { inputData.Move = context.ReadValue<Vector2>(); };

            inputAction.Map.WASD.performed += context => { inputData.Move = context.ReadValue<Vector2>(); };
            inputAction.Map.WASD.started += context => { inputData.Move = context.ReadValue<Vector2>(); };
            inputAction.Map.WASD.canceled += context => { inputData.Move = context.ReadValue<Vector2>(); };

            inputAction.Map.Look.performed += context => { inputData.Mouse = context.ReadValue<Vector2>(); };
            inputAction.Map.Look.started += context => { inputData.Mouse = context.ReadValue<Vector2>(); };
            inputAction.Map.Look.canceled += context => { inputData.Mouse = context.ReadValue<Vector2>(); };
            //запустим 
            inputAction.Enable();
        }
        else
        {
            Debug.LogError("Нет связи с классом MapCurrent");
        }
        
    }


    void Update()
    {
        userInput.InputData=inputData;
        if (DebugLogOnOff)
        {
            Debug.Log($"Движение Х = {userInput.InputData.Move.x}, Движение Y = {userInput.InputData.Move.y}");
            Debug.Log($"Мыш Х = {userInput.InputData.Mouse.x}, Мыш Y = {userInput.InputData.Mouse.y}");
        }
    }
}
