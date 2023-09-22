using Instrumental.Services;
using Instrumental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrumental.Commands
{
    public class StartCommand : BaseCommand
    {
        private INavigationService navigationService;
        private IGameService gameService;
        public StartCommand(INavigationService navigationService, IGameService gameService)
        {
            this.navigationService = navigationService;
            this.gameService = gameService;
        }
        public override void Execute(object? parameter)
        {
            gameService.StartGame();
            var initialQuestion = gameService.GetNextQuestion();
            navigationService.CurrentViewModel = new QuestionViewModel(navigationService, gameService, initialQuestion);
        }
    }
}
