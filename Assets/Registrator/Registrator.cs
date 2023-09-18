using UnityEngine;
using Zenject;

public class Registrator : MonoBehaviour
{
    [Inject] private IRegistrator dataReg;//получим данные управления в структуре
    private void Awake()
    {
        RegistratorConstruction registrator = new RegistratorConstruction
        {
            Hash=gameObject.GetHashCode(),
            HealtObj=GetComponent<Healt>(),
            PlayerHealt=GetComponent<PlayerHealt>(),
            ShootPlayer=GetComponent<ShootPlayer>()
        };

        dataReg.SetData(registrator);
    }
}
