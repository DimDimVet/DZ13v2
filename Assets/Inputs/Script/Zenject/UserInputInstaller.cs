using Zenject;

public class UserInputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IUserInput>().To<UserInputExecutor>().AsSingle().NonLazy();//инициализируем точку входа исполнителя ExecutorZenject
    }
}