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
        public ObservableCollection<MenuItemViewModel> ChildMenuItems => _menuItems;
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
            var menuLength = menus.Length;
            if (menuLength > 0)
            {
                var topMenu = _menuItems.Where(x => x.Header == menus[0]).FirstOrDefault();
                var navigationPath = menuItemArgs.NavigationPath;
                Action action = () =>
                {
                    OnMenuClick(menuItemArgs.NavigationPath);
                };
                if (string.IsNullOrWhiteSpace(menuItemArgs.NavigationPath))
                {
                    action = menuItemArgs.Command;
                }
                if (topMenu == null)
                {
                    Action topAction = action;
                    if (menuLength > 1)
                    {
                        topAction = null;
                    }
                    topMenu = new MenuItemViewModel(null, topAction)
                    {
                        Header = menus[0]
                    };
                    _menuItems.Add(topMenu);
                }
                var parent = topMenu;
                if (menuLength > 1)
                {
                    for (int i = 1; i <= menuLength-1; i++)
                    {
                        var menu = parent.ChildMenuItems?.Where(x => x.Header == menus[i]).FirstOrDefault();
                        if (menu == null)
                        {
                            menu = new MenuItemViewModel(parent, null)
                            {
                                Header = menus[i]
                            };
                            parent.ChildMenuItems.Add(menu);
                        }
                        parent = menu;
                    }
                    var menuLeaf = new MenuItemViewModel(parent, action)
                    {
                        Header = menus[menuLength - 1]
                    };
                    parent.ChildMenuItems.Add(menuLeaf);
                }
            }
        }
        private void OnMenuClick(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.TabRegion, navigationPath);
        }
    }
}
