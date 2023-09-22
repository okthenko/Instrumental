using Instrumental.Models;
using Instrumental.Services;
using Instrumental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Instrumental.Commands
{
    class SubmitCommand : BaseCommand
    {
        private INavigationService navigationService;
        private IGameService gameService;
        private QuestionViewModel questionViewModel;
        public SubmitCommand(INavigationService navigationService, IGameService gameService, QuestionViewModel questionViewModel)
        {
            this.navigationService = navigationService;
            this.gameService = gameService;
            this.questionViewModel = questionViewModel;
        }

        public override void Execute(object? parameter)
        {
            var answer = questionViewModel.Question.Options.Where(o => o.IsSelected).Select(o => o.Text).FirstOrDefault();      

            if (answer != null)
            {
                navigationService.CurrentViewModel = new AnswerViewModel(navigationService, gameService, questionViewModel.Question, gameService.IsCorrectAnswer(answer));
            }
        }
    }
}

