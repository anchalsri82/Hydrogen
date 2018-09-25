using System.Windows.Controls;
using Hydrogen.Modules.MenuModule.ViewModels;

namespace Hydrogen.Modules.MenuModule.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        public MenuView()
        {
            InitializeComponent();
        }
        public MenuView(MenuViewModel menuViewModel)
        {
            InitializeComponent();
            DataContext = menuViewModel;
        }
    }
}
