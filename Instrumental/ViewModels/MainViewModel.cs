using Instrumental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrumental.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        public MainViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            navigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        public BaseViewModel CurrentViewModel => navigationService.CurrentViewModel;

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


    }
}
