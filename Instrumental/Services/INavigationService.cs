using Instrumental.ViewModels;
using System;

namespace Instrumental.Services
{
    public interface INavigationService
    {
        BaseViewModel CurrentViewModel { get; set; }

        event Action CurrentViewModelChanged;
    }
}