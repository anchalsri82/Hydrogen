using System.Windows.Controls;
using Hydrogen.Modules.HelpModule.ViewModels;

namespace Hydrogen.Modules.HelpModule.Views
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : UserControl
    {
        public HelpView()
        {
            InitializeComponent();
        }
        public HelpView(HelpViewModel helpViewModel)
        {
            InitializeComponent();
            DataContext = helpViewModel;
        }
    }
}
