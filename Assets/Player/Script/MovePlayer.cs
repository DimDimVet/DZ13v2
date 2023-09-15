using UnityEngine;
using Zenject;

public class MovePlayer : MonoBehaviour
{
    [Inject] private IUserInput userInput;//������� ������ ���������� � ���������
    [Inject] private ICameraData cameraData;//������� ������ ���������� �������
    //
    [SerializeField] private MoveSettings moveSettings;
    [SerializeField] private Transform cameraPoint;

    private float speedMove;

    void Start()
    {
        speedMove = moveSettings.SpeedMove;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, cameraData.CameraAngle.x);//������� �����
        cameraData.TransformCamera=cameraPoint;

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

