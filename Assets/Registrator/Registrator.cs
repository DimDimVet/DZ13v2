using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Registrator : MonoBehaviour
{
    [Inject] private IRegistrator dataReg;//������� ������ ���������� � ���������
    void Start()
    {
        RegistratorConstruction registrator = new RegistratorConstruction
        {
            Hash=gameObject.GetHashCode(),
            HealtObj=GetComponent<Healt>()
        };

        dataReg.SetData(registrator);
    }
}
