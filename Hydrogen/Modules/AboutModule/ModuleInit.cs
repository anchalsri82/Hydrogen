using Autofac;
using Hydrogen.Infra.Service;
using Hydrogen.Infra.Service.Events;
using Hydrogen.Modules.AboutModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Hydrogen.Modules.AboutModule
{
    public class ModuleInit : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainer _container;
        private readonly IMenuService _menuService;
        internal const string AboutView = "AboutView";
        internal const string AboutMenuPath = "Help>About";

        public ModuleInit(IRegionManager regionManager, IContainer container, IMenuService menuService)
        {
            _regionManager = regionManager;
            _container = container;
            _menuService = menuService;
        }

        public void Initialize()
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterType<AboutView>().Named<object>("AboutView").SingleInstance();
            //builder.Update(_container);
            _menuService.Register(new MenuItemArgs { NavigationPath = AboutView, Path = AboutMenuPath });
            //_menuService.Register(new MenuItemArgs { NavigationPath = AboutView, Path = AboutMenuPath });
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AboutView>("AboutView");
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }
    }
}
