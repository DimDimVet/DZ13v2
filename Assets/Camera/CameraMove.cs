using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 transformCamera;
    [SerializeField] private Quaternion rotate;
    [SerializeField] private Transform gameTarget;
    void Start()
    {
        
        mainCamera.transform.position=transformCamera;
        mainCamera.transform.rotation=rotate;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 hh = new Vector3(2, 2, 2);
        //mainCamera.transform.position=transformCamera+gameTarget.position;
        //mainCamera.transform.LookAt(gameTarget);

        mainCamera.transform.RotateAround(gameTarget.forward, gameTarget.forward, Time.deltaTime*25);
    }
}
