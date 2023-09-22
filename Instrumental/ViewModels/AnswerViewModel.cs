using Instrumental.Commands;
using Instrumental.Models;
using Instrumental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Instrumental.ViewModels
{
    public class AnswerViewModel : BaseViewModel
    {
        private INavigationService navigationService;
        private IGameService gameService;
        private InstrumentModel instrument;
        private bool isCorrect;
        public AnswerViewModel(INavigationService navigationService, IGameService gameService, QuestionModel question, bool isCorrect)
        {
            this.navigationService = navigationService;
            this.gameService = gameService;
            instrument = question.Instrument;

            NextCommand = new NextCommand(navigationService, gameService);

            this.isCorrect = isCorrect;
        }
        public InstrumentModel Instrument
        {
            get
            {
                return instrument;
            }
            set
            {
                instrument = value;
                OnPropertyChanged(nameof(instrument));
            }
        }
        public bool IsCorrect
        {
            get
            {
                return isCorrect;
            }
            set
            {
                isCorrect = value;
                OnPropertyChanged(nameof(isCorrect));
            }
        }

        public ICommand NextCommand { get; }

    }
}
