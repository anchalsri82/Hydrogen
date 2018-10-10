using System;

namespace Hydrogen.Modules.MenuModule.ViewModels
{
    public class SeparatorViewModel : MenuItemViewModel
    {
        public SeparatorViewModel(MenuItemViewModel parentViewModel, Action action) : base(parentViewModel, action)
        {

        }
    }
}
