using Instrumental.Models;

namespace Instrumental.Services
{
    public interface IGameService
    {
        int Score { get; }
        QuestionModel? GetNextQuestion();
        bool IsCorrectAnswer(string answer);
        void StartGame();
    }
}