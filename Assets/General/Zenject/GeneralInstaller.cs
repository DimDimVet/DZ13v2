
using Zenject;

public class GeneralInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IGeneral>().To<GeneralExecutor>().AsSingle().NonLazy();//�������������� ����� ����� ����������� ExecutorZenject

        //Container.BindFactory<>();
    }
}
