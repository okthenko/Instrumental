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
    public class ScoreViewModel : BaseViewModel
    {
        private INavigationService navigationService;
        private IGameService gameService;
        private int score;
        public ScoreViewModel(INavigationService navigationService, IGameService gameService)
        {
            this.navigationService = navigationService; 
            this.gameService = gameService;
            Score = gameService.Score;

            HomeCommand = new NavigateCommand(navigationService, CreateStartViewModel);
        }
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                OnPropertyChanged(nameof(score));
            }
        }
        public ICommand HomeCommand { get; }
        public ICommand StartCommand { get; }
        private StartViewModel CreateStartViewModel()
        {
            return new StartViewModel(navigationService, gameService);
        }
    }
}
