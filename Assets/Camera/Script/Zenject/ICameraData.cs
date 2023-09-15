using Unity.Mathematics;
using UnityEngine;

public interface ICameraData
{
    float2 CameraAngle { get; set; }
    Transform TransformCamera { get; set; }
}
