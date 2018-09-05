using TestFormService.Contract;
using TestFormService.Implementation;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace TestFormService
{
    public class UnityContainer
    {
        private static IUnityContainer _unityContainer;
        private static readonly string FilePath = "C:\\Development\\profile.json";
        public static IUnityContainer Instance => _unityContainer ?? (_unityContainer = InitialiseUnityContainer());

        private static IUnityContainer InitialiseUnityContainer()
        {
            var container = new Unity.UnityContainer();

            container.RegisterType<IProfileRepository, ProfileRepository>(new ContainerControlledLifetimeManager(),
                new InjectionConstructor(FilePath));
            container.RegisterType<IProfileService, ProfileService>();

            return container;
        }
    }
}
