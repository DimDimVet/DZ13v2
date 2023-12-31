using UnityEngine;

public interface IRegistrator
{
    public Transform OutPos { get; set; }

    void SetData(RegistratorConstruction data);
    RegistratorConstruction GetData(int hash);
}
