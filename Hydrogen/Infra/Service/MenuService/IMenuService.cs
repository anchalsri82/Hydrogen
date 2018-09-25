using Hydrogen.Infra.Service.Events;

namespace Hydrogen.Infra.Service
{
    public interface IMenuService
    {
        void Register(MenuItemArgs menuItemArgs);
    }
}
