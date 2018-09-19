using Autofac;
using Hydrogen.Modules.HelpModule.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Hydrogen.Modules.HelpModule
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
            builder.RegisterType<HelpView>().Named<object>("HelpView");
            builder.Update(_container);
        }
    }
}
