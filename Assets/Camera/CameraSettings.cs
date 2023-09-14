using UnityEngine;

[CreateAssetMenu]
public class CameraSettings : ScriptableObject
{
    [Header("��������� ��������")]
    public float MouseSensor = 0.5f;
    public float MinStopAngle = -30f;
    public float MaxStopAngle = 30f;
    public Vector3 Offset=new Vector3(0,0,0);

}
