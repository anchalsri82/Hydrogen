using Hydrogen.Infra.Common;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Hydrogen.Shell.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; set; }

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.TabRegion, navigationPath);
        }
    }
}
