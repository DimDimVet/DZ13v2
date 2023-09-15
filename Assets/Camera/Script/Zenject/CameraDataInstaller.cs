
using Zenject;

public class CameraDataInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        Container.Bind<ICameraData>().To<CameraDataExecutor>().AsSingle().NonLazy();//инициализируем точку входа исполнителя ExecutorZenject
    }
}
