using Unity.Mathematics;
using UnityEngine;

public class CameraDataExecutor : ICameraData
{
    public Transform TransformCamera { get; set; }
    public float2 CameraAngle { get; set; }

}
