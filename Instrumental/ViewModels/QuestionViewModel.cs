using Instrumental.Commands;
using Instrumental.Models;
using Instrumental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Instrumental.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        private QuestionModel question;
        public QuestionViewModel(INavigationService navigationService, IGameService gameService, QuestionModel question)
        {
            this.question = question;

            SubmitCommand = new SubmitCommand(navigationService, gameService, this);
            ReplayCommand = new ReplayCommand(this);
        }

        public QuestionModel Question
        {
            get 
            { 
                return question; 
            }   
            set
            {
                question = value; 
                OnPropertyChanged(nameof(question));
            }
        }

        public ICommand ReplayCommand { get; }
        public ICommand SubmitCommand { get; }
    }
}
