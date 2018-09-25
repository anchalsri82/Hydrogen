using Hydrogen.Infra.Common;
using Prism.Regions;

namespace Hydrogen.Modules.AboutModule.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public AboutViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Title = "About";
        }
    }
}
