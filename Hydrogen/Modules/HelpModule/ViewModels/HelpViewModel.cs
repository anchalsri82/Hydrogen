﻿using Hydrogen.Infra.Common;
using Prism.Regions;

namespace Hydrogen.Modules.HelpModule.ViewModels
{
    public class HelpViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public HelpViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Title = "Help";
        }
    }
}
