using UnityEngine;
using Zenject;

public class RegistratorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IRegistrator>().To<RegistratorExecutor>().AsSingle().NonLazy();//�������������� ����� ����� ����������� ExecutorZenject

        //Container.BindFactory<>();
    }
}
