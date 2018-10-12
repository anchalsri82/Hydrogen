using Hydrogen.Infra.Common;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Hydrogen.Modules.MenuModule.ViewModels
{
    public class MenuItemViewModel : ViewModelBase
    {
        public ICommand Command { get; set; }
        public string CommandName { get; set; }
        public object Icon { get; set; }
        public bool IsCheckable { get; set; }
        private bool _IsChecked;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                _IsChecked = value;
                RaisePropertyChanged("IsChecked");
            }
        }

        public bool Visible { get; set; }
        public bool IsSeparator { get; set; }
        public string InputGestureText { get; set; }
        public string ToolTip { get; set; }
        public int MenuHierarchyID { get; set; }
        public int ParentMenuHierarchyID { get; set; }
        public string IconPath { get; set; }
        public bool IsAdminOnly { get; set; }
        public object Context { get; set; }
        public MenuItemViewModel Parent { get; set; }
        public int int_Sequence { get; set; }
        public int int_KeyIndex { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemViewModel"/> class.
        /// </summary>
        /// <param name="parentViewModel">The parent view model.</param>
        public MenuItemViewModel(MenuItemViewModel parentViewModel, Action action)
        {
            ParentViewModel = parentViewModel;
            _childMenuItems = new List<MenuItemViewModel>();
            if (action != null)
                Command = new DelegateCommand(action, CanExecute);
        }
        private bool CanExecute()
        {
            return true;
        }
        private List<MenuItemViewModel> _childMenuItems;
        /// <summary>
        /// Gets the child menu items.
        /// </summary>
        /// <value>The child menu items.</value>
        public List<MenuItemViewModel> ChildMenuItems
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
        
        public virtual void LoadChildMenuItems()
        {

        }
    }
}