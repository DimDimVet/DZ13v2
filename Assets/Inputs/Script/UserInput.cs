using UnityEngine;
using Zenject;

public class UserInput : MonoBehaviour
{
    [Inject] private IUserInput userInput;//�������� ������ � ������������

    public bool DebugLogOnOff;//��� ������
    //��������� ����� MapCurrent(new input)
    private MapCurrent inputAction;
    private InputData inputData;

    void Start()
    {
        inputAction = new MapCurrent();//�������������� ����� input
        inputData=new InputData();
        
        if (inputAction!=null)//�������� �� null
        {
            //�������� �� event ������� ������� � �������� �������� ��������� ���������
            inputAction.UIMap.WASD.performed += context => { inputData.Move = context.ReadValue<Vector2>(); };
            inputAction.UIMap.WASD.started += context => { inputData.Move = context.ReadValue<Vector2>(); };
            inputAction.UIMap.WASD.canceled += context => { inputData.Move = context.ReadValue<Vector2>(); };

            inputAction.Map.WASD.performed += context => { inputData.Move = context.ReadValue<Vector2>(); };
            inputAction.Map.WASD.started += context => { inputData.Move = context.ReadValue<Vector2>(); };
            inputAction.Map.WASD.canceled += context => { inputData.Move = context.ReadValue<Vector2>(); };

            inputAction.Map.Look.performed += context => { inputData.Mouse = context.ReadValue<Vector2>(); };
            inputAction.Map.Look.started += context => { inputData.Mouse = context.ReadValue<Vector2>(); };
            inputAction.Map.Look.canceled += context => { inputData.Mouse = context.ReadValue<Vector2>(); };

            inputAction.Map.Shoot.performed += context => { inputData.Shoot = context.ReadValue<float>(); };
            inputAction.Map.Shoot.started += context => { inputData.Shoot = context.ReadValue<float>(); };
            inputAction.Map.Shoot.canceled += context => { inputData.Shoot = context.ReadValue<float>(); };

            inputAction.Map.Pull.performed += context => { inputData.Pull = context.ReadValue<float>(); };
            inputAction.Map.Pull.started += context => { inputData.Pull = context.ReadValue<float>(); };
            inputAction.Map.Pull.canceled += context => { inputData.Pull = context.ReadValue<float>(); };

            inputAction.Map.ModePlayer.performed += context => { inputData.Mode = context.ReadValue<float>(); };
            inputAction.Map.ModePlayer.started += context => { inputData.Mode = context.ReadValue<float>(); };
            inputAction.Map.ModePlayer.canceled += context => { inputData.Mode = context.ReadValue<float>(); };
            //�������� 
            inputAction.Enable();
        }
        else
        {
            Debug.LogError("��� ����� � ������� MapCurrent");
        }
        
    }


    void Update()
    {
        userInput.InputData=inputData;
        if (DebugLogOnOff)
        {
            Debug.Log($"�������� � = {userInput.InputData.Move.x}, �������� Y = {userInput.InputData.Move.y}");
            Debug.Log($"���� � = {userInput.InputData.Mouse.x}, ���� Y = {userInput.InputData.Mouse.y}");
            Debug.Log($"������� = {userInput.InputData.Shoot}");
            Debug.Log($"������ = {userInput.InputData.Pull}");
            Debug.Log($"����� = {userInput.InputData.Mode}");
        }
    }
}
