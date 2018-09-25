﻿using Autofac;
using Hydrogen.Infra.Service;
using Hydrogen.Modules.HelpModule.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Hydrogen.Modules.HelpModule
{
    public class ModuleInit : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainer _container;
        private readonly IMenuService _menuService;
        private const string HelpView = "HelpView";
        private const string HelpMenuPath = "Help>Help";
        public ModuleInit(IRegionManager regionManager, IContainer container, IMenuService menuService)
        {
            _regionManager = regionManager;
            _container = container;
            _menuService = menuService;
        }

        public void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HelpView>().Named<object>(HelpView).SingleInstance();
            builder.Update(_container);
            _menuService.Register(new Infra.Service.Events.MenuItemArgs { NavigationPath = HelpView, Path = HelpMenuPath });
        }
    }
}
