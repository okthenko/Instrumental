using Instrumental.Commands;
using Instrumental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Instrumental.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        public StartViewModel(INavigationService navigationService, IGameService gameService ) 
        {
            StartCommand = new StartCommand(navigationService, gameService);
        }

        public ICommand StartCommand { get; }
    }
}
