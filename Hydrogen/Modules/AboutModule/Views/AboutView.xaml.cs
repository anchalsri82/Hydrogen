using Hydrogen.Modules.AboutModule.ViewModels;
using System.Windows.Controls;

namespace Hydrogen.Modules.AboutModule.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView : UserControl
    {
        public AboutView()
        {
            InitializeComponent();
        }
        public AboutView(AboutViewModel aboutViewModel)
        {
            InitializeComponent();
            DataContext = aboutViewModel;
        }
    }
}
