using Hydrogen.Infra.Service;
using Hydrogen.Infra.Service.Events;
using Prism.Events;

namespace Hydrogen.Modules.MenuModule.Services
{
    public class MenuService : IMenuService
    {
        private readonly IEventAggregator _eventAggregator;
        public MenuService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        public void Register(MenuItemArgs menuItemArgs)
        {
            _eventAggregator.GetEvent<MenuEvent>().Publish(menuItemArgs);
        }
    }
}
