
using Zenject;

public class GeneralInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IGeneral>().To<GeneralExecutor>().AsSingle().NonLazy();//инициализируем точку входа исполнителя ExecutorZenject

        //Container.BindFactory<>();
    }
}
