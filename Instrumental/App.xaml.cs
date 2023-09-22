using Instrumental.Repositories;
using Instrumental.Services;
using Instrumental.ViewModels;
using System;
using System.Configuration;
using System.Windows;

namespace Instrumental
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private INavigationService navigationService;
        private IGameService gameService;
        public App()
        {
            navigationService = new NavigationService();

            var instrumentRepository = new InstrumentRepository(new SqliteDataAccess());
            var numberOfQuestions = int.Parse(ConfigurationManager.AppSettings["numberOfQuestions"]);
            var numberOfOptions = int.Parse(ConfigurationManager.AppSettings["numberOfOptions"]);
            gameService = new GameService(instrumentRepository, numberOfQuestions, numberOfOptions);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            navigationService.CurrentViewModel = new StartViewModel(navigationService, gameService);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationService)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
