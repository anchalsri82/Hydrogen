using Autofac;
using Hydrogen.Infra.Common;
using Hydrogen.Infra.Service;
using Hydrogen.Modules.MenuModule.Services;
using Hydrogen.Modules.MenuModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Hydrogen.Modules.MenuModule
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
            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(MenuView));

            var builder = new ContainerBuilder();
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.Update(_container);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
