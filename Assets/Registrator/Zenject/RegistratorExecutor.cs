using System.Collections.Generic;
using UnityEngine;

public class RegistratorExecutor : IRegistrator
{
    public Transform OutPos { get; set; }

    private List<RegistratorConstruction> dataObject=new List<RegistratorConstruction>();

    public void SetData(RegistratorConstruction data)
    {
        dataObject.Add(data);
    }

    public RegistratorConstruction GetData(int hash)
    {
        for (int i = 0; i < dataObject.Count; i++)
        {
            if (dataObject[i].Hash==hash)
            {
                return dataObject[i];
            }
            
        }
        return new RegistratorConstruction();
    }
}
