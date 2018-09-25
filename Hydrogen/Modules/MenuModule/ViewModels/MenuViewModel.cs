using Hydrogen.Infra.Common;
using Hydrogen.Infra.Service.Events;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hydrogen.Modules.MenuModule.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<MenuItemViewModel> _menuItems;
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        /// <summary>
        /// Gets the child menu items.
        /// </summary>
        /// <value>The child menu items.</value>
        public ObservableCollection<MenuItemViewModel> MenuItems => _menuItems;
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuViewModel"/> class.
        /// </summary>
        public MenuViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _menuItems = new ObservableCollection<MenuItemViewModel>();
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<MenuEvent>().Subscribe(OnMenuEvent);
            _regionManager = regionManager;
        }
        private void OnMenuEvent(MenuItemArgs menuItemArgs)
        {
            var menus = menuItemArgs?.Path?.Split(new char[]{ ',', '/', '>' });
            if (menus.Length > 0)
            {
                var topMenu = _menuItems.Where(x => x.Header == menus[0]).FirstOrDefault();
                if (topMenu == null)
                {
                    Action action = () =>
                    {
                        OnMenuClick(menuItemArgs.NavigationPath);
                    };
                    if (string.IsNullOrWhiteSpace(menuItemArgs.NavigationPath))
                    {
                        action = menuItemArgs.Command;
                    }
                    topMenu = new MenuItemViewModel(null, action)
                    {
                        Header = menus[0],
                        NavigationPath = menuItemArgs.NavigationPath
                    };
                    _menuItems.Add(topMenu);
                }
                var menuLength = menus.Length;
                if (menuLength > 1)
                {
                    for (int i = 1; i <= menuLength; i++)
                    {
                        var menu = topMenu.ChildMenuItems.Where(x => x.Header == menus[0]).FirstOrDefault();
                    }
                }
            }
        }
        private void OnMenuClick(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.TabRegion, navigationPath);
        }
    }
}
