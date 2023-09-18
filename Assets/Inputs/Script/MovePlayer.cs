using UnityEngine;
using Zenject;

public class MovePlayer : MonoBehaviour
{
    [Inject] private IUserInput userInput;//получим данные управления в структуре
    [Inject] private ICameraData cameraData;//получим данные управления камерой
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
        transform.Rotate(Vector3.up, cameraData.CameraAngle.x);//поворот мышью
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

