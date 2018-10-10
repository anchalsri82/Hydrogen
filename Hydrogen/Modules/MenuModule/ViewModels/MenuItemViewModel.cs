using Hydrogen.Infra.Common;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hydrogen.Modules.MenuModule.ViewModels
{
    public class MenuItemViewModel : ViewModelBase
    {
        private readonly ICommand _menuItemCommand;
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemViewModel"/> class.
        /// </summary>
        /// <param name="parentViewModel">The parent view model.</param>
        public MenuItemViewModel(MenuItemViewModel parentViewModel, Action action)
        {
            ParentViewModel = parentViewModel;
            _childMenuItems = new ObservableCollection<MenuItemViewModel>();
            if (action != null)
                _menuItemCommand = new DelegateCommand(action, CanExecute);
        }
        private bool CanExecute()
        {
            return true;
        }
        private ObservableCollection<MenuItemViewModel> _childMenuItems;
        /// <summary>
        /// Gets the child menu items.
        /// </summary>
        /// <value>The child menu items.</value>
        public ObservableCollection<MenuItemViewModel> ChildMenuItems
        {
            get
            {
                return _childMenuItems;
            }
        }

        private string _header;
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public string Header
        {
            get
            {
                return _header;
            }
            set
            {
                _header = value; RaisePropertyChanged("Header");
            }
        }
        private string _navigationPath;
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public string NavigationPath
        {
            get
            {
                return _navigationPath;
            }
            set
            {
                _navigationPath = value; RaisePropertyChanged("NavigationPath");
            }
        }

        /// <summary>
        /// Gets or sets the parent view model.
        /// </summary>
        /// <value>The parent view model.</value>
        public MenuItemViewModel ParentViewModel { get; set; }

        public ICommand MenuItemCommand
        {
            get
            {
                return _menuItemCommand;
            }
        }

        public virtual void LoadChildMenuItems()
        {

        }
    }
}