using Hydrogen.Infra.Common;
using Prism.Commands;
using Prism.Regions;

namespace Hydrogen.Modules.HelpModule.ViewModels
{
    public class HelpViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public HelpViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            Title = "Help";
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate("ChildRegion", navigationPath);
        }
    }
}
