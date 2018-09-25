using Prism.Events;
using System;

namespace Hydrogen.Infra.Service.Events
{
    public class MenuItemArgs
    {
        public string Path { get; set; }
        public string NavigationPath { get; set; }

        public Action Command { get; set; }
    }
    public class MenuEvent : PubSubEvent<MenuItemArgs>
    {
    }
}
