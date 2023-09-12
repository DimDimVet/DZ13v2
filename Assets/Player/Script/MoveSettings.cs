using UnityEngine;

[CreateAssetMenu]
public class MoveSettings : ScriptableObject
{
    public float MouseSensor = 1f;
    public float SpeedMove = 1f;
    public float minStopAngle = -90f;
    public float maxStopAngle = 90f;
}
