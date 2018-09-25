using Autofac;
using Hydrogen.Modules.AboutModule.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Hydrogen.Modules.AboutModule
{
    public class ModuleInit : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainer _container;

        public ModuleInit(IRegionManager regionManager, IContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AboutView>().Named<object>("AboutView").SingleInstance();
            builder.Update(_container);
        }
    }
}
