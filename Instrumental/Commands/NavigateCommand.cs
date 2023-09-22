using Instrumental.Services;
using Instrumental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrumental.Commands
{
    public class NavigateCommand : BaseCommand
    {
        private INavigationService navigationService;
        private readonly Func<BaseViewModel> createViewModel;
        public NavigateCommand(INavigationService navigationService, Func<BaseViewModel> createViewModel)
        {
            this.navigationService = navigationService; 
            this.createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            navigationService.CurrentViewModel = createViewModel();
        }
    }
}
