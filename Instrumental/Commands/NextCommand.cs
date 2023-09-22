using Instrumental.Services;
using Instrumental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrumental.Commands
{
    class NextCommand : BaseCommand
    {
        private INavigationService navigationService;
        private IGameService gameService;
        public NextCommand(INavigationService navigationService, IGameService gameService)
        {
            this.navigationService = navigationService;
            this.gameService = gameService;
        }
        public override void Execute(object? parameter)
        {
            var nextQuestion = gameService.GetNextQuestion();

            if(nextQuestion != null)
            {
                navigationService.CurrentViewModel = new QuestionViewModel(navigationService, gameService, nextQuestion);
            }
            else
            {
                navigationService.CurrentViewModel = new ScoreViewModel(navigationService, gameService);
            }

        }
    }
}
