using Instrumental.Entities;
using Instrumental.Models;
using Instrumental.Repositories;
using Instrumental.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Instrumental.Tests.Services
{
    [TestFixture]
    public class GameServiceTests
    {
        private Mock<IInstrumentRepository> mockInstrumentRepository;
        private int numberOfQuestions;
        private int numberOfOptions;
        private Random random;

        [SetUp]
        public void SetUp()
        {
            mockInstrumentRepository = new Mock<IInstrumentRepository>();

            numberOfQuestions = int.Parse(ConfigurationManager.AppSettings["numberOfQuestions"]);
            numberOfOptions = int.Parse(ConfigurationManager.AppSettings["numberOfOptions"]);
        }


        [Test]
        public void GetNextQuestion_CalledOnce_ReturnsQuestionWithUniqueOptions()
        {
            //Arrange
            var instruments = GetSimulatedRandomTestInstruments();            
            mockInstrumentRepository.Setup(x => x.GetRandomInstrument()).Returns(instruments.Dequeue);
            var gameService = new GameService(mockInstrumentRepository.Object, numberOfQuestions, numberOfOptions);
            gameService.StartGame();

            //Act
            var question = gameService.GetNextQuestion();

            //Assert
            var options = question.Options;
            Assert.That(options.Count(), Is.EqualTo(options.Distinct().Count()));
        }

        [Test]

        public void GetNextQuestion_CalledNTimes_ReturnsNUniqueQuestions()
        {
            //Arrange
            var instruments = GetSimulatedRandomTestInstruments();
            mockInstrumentRepository.Setup(x => x.GetRandomInstrument()).Returns(instruments.Dequeue);
            var gameService = new GameService(mockInstrumentRepository.Object, numberOfQuestions, numberOfOptions);
            gameService.StartGame();

            var questions = new List<QuestionModel>();
            var question = gameService.GetNextQuestion();

            //Act
            do
            {
                questions.Add(question);
                question = gameService.GetNextQuestion();
;
            }
            while (question != null);

            //Assert
            Assert.That(questions.Count(), Is.EqualTo(questions.Select(q => q.Instrument).Distinct().Count()));
        }

        [Test]

        public void GetNextQuestion_CalledRepeatedly_ReturnsCorrectNumberOfQuestions()
        {
            //Arange
            var instruments = GetSimulatedRandomTestInstruments();
            mockInstrumentRepository.Setup(x => x.GetRandomInstrument()).Returns(instruments.Dequeue);
            var gameService = new GameService(mockInstrumentRepository.Object, numberOfQuestions, numberOfOptions);
            gameService.StartGame();

            int counter = 0;
            var question = gameService.GetNextQuestion();

            //Act
            do
            {
                counter++;
                question = gameService.GetNextQuestion();
            }
            while (question != null);

            //Assert
            Assert.That(numberOfQuestions, Is.EqualTo(counter));
        }

        [Test]

        public void IsCorrect_WhenAnswerIsCorrect_ReturnsTrue()
        {
            //Arrange
            var instruments = GetSimulatedRandomTestInstruments();
            mockInstrumentRepository.Setup(x => x.GetRandomInstrument()).Returns(instruments.Dequeue);

            var gameService = new GameService(mockInstrumentRepository.Object, numberOfQuestions, numberOfOptions);
            gameService.StartGame();

            //Act
            var question = gameService.GetNextQuestion();
            var answer = question.Instrument.InstrumentName;
            var isCorrect = gameService.IsCorrectAnswer(answer);

            //Assert
            Assert.That(isCorrect, Is.EqualTo(true));
        }

        public void IsCorrect_WhenAnswerIsIncorrect_ReturnsTrue()
        {
            //Arrange

            var instruments = GetSimulatedRandomTestInstruments();
            mockInstrumentRepository.Setup(x => x.GetRandomInstrument()).Returns(instruments.Dequeue);

            var gameService = new GameService(mockInstrumentRepository.Object, numberOfQuestions, numberOfOptions);
            gameService.StartGame();

            //Act
            var question = gameService.GetNextQuestion();
            var correctAnswer = question.Instrument.InstrumentName;
            var incorrectAnswer = question.Options.Where(o => o.Text != correctAnswer).FirstOrDefault().Text;
            var isCorrect = gameService.IsCorrectAnswer(incorrectAnswer);

            //Assert
            Assert.That(isCorrect, Is.EqualTo(false));
        }

        [Test]
        public void IsCorrect_WhenAnswerIsCorrect_IncreasesScoreByCorrectAmount()
        {
            //Arrange

            var instruments = GetSimulatedRandomTestInstruments();
            mockInstrumentRepository.Setup(x => x.GetRandomInstrument()).Returns(instruments.Dequeue);

            var gameService = new GameService(mockInstrumentRepository.Object, numberOfQuestions, numberOfOptions);
            gameService.StartGame();

            //Act
            var question = gameService.GetNextQuestion();
            var correctAnswer = question.Instrument.InstrumentName;
            gameService.IsCorrectAnswer(correctAnswer);
            var score = gameService.Score;

            //Assert
            Assert.That(score, Is.EqualTo(1));
        }

        [Test]
        public void IsCorrect_WhenAnswerIsIncorrect_DoesNotIncreaseScore()
        {
            //Arrange
            var instruments = GetSimulatedRandomTestInstruments();
            mockInstrumentRepository.Setup(x => x.GetRandomInstrument()).Returns(instruments.Dequeue);

            var gameService = new GameService(mockInstrumentRepository.Object, numberOfQuestions, numberOfOptions);
            gameService.StartGame();

            //Act
            var question = gameService.GetNextQuestion();
            var correctAnswer = question.Instrument.InstrumentName;
            var incorrectAnswer = question.Options.Where(o => o.Text != correctAnswer).FirstOrDefault().Text;
            gameService.IsCorrectAnswer(incorrectAnswer);
            var score = gameService.Score;

            //Assert
            Assert.That(score, Is.EqualTo(0));
        }


        private Queue<InstrumentModel> GetSimulatedRandomTestInstruments()
        {
            var testModels = new Queue<InstrumentModel>();

            for (int i = 1; i < numberOfQuestions * numberOfOptions; i++)
            {
                testModels.Enqueue(GetTestInstrument(i));

                if (i % numberOfOptions - 1 == 0)
                {
                    testModels.Enqueue(GetTestInstrument(i));
                }
            }
            return testModels;
        }

        private InstrumentModel GetTestInstrument(int i)
        {
            int id = i;
            string instrumentName = $"Test{i}";
            string imageFileName = $"pack://application:,,,/Resources/Images/test{i}.jpg";
            string soundFileName = $"pack://application:,,,/Resources/Sounds/test{i}.mp3";

            var entity = new InstrumentEntity(id, instrumentName, imageFileName, soundFileName);
            return new InstrumentModel(entity);
        }
    }
}
