using UnityEngine;
using Zenject;

public class MovePlayer : MonoBehaviour
{
    [Inject] private IUserInput userInput;//получим данные в структуре
    //
    [SerializeField] private MoveSettings moveSettings;
    [SerializeField] private Camera cameraMain;
    [SerializeField] private Transform targetCamera;

    private float speedAngle;
    private float speedMove;
    private Vector3 currentPos;
    private float correctY;

    private float smVelocity;
    void Start()
    {
        speedAngle = moveSettings.SpeedAngle;
        speedMove = moveSettings.SpeedMove;
        correctY = moveSettings.CorrectY;
    }

    void Update()
    {
        Vector3 dir = new Vector3(userInput.InputData.Mouse.x, 0, userInput.InputData.Mouse.y).normalized;

        float rotationAngle = Mathf.Atan2(dir.x, dir.z)*Mathf.Rad2Deg+ cameraMain.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle,ref smVelocity,10f);
        transform.rotation = Quaternion.Euler(0,angle,0);


        //currentPos = targetCamera.position - transform.position;
        //currentPos.y = correctY;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentPos), speedAngle * Time.deltaTime);
        //Ray ray = new Ray(cameraMain.transform.position, cameraMain.transform.forward);
        //targetCamera.position = ray.GetPoint(15);

        //float yTop = Mathf.LerpAngle(transform.eulerAngles.y,cameraMain.transform.rotation.y,5*(1-Mathf.Exp(-20*Time.deltaTime)));
        //transform.rotation = Quaternion.Slerp(transform.rotation, cameraMain.transform.rotation, 5 * (1 - Mathf.Exp(-20 * Time.deltaTime)));

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

