using Instrumental.ViewModels;
using System;

namespace Instrumental.Services
{
    public class NavigationService : INavigationService
    {
        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                if (currentViewModel != null) { currentViewModel.Dispose(); }
                currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action? CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

    }
}
