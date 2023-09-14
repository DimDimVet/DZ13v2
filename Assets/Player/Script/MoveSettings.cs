using UnityEngine;

[CreateAssetMenu]
public class MoveSettings : ScriptableObject
{
    [Header("��������� ��������")]
    public float SpeedMove = 100f;
    public float SpeedAngle=10f;
    public float CorrectY=0f;

    [Header("��������� ������")]
    public float Force = 1f;
    public float Height = 1f;

    [Header("������� ���� GND")]
    public LayerMask GroundLayer;

    [Header("�������� �������")]
    public float ShootDelay=1f;
}
