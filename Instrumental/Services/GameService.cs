using Instrumental.Models;
using Instrumental.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Instrumental.Services
{
    public class GameService : IGameService
    {
        private IInstrumentRepository instrumentRepository;
        private int numberOfQuestions;
        private int numberOfOptions;
        private List<InstrumentModel> playedInstruments;
        private QuestionModel? currentQuestion;
        public GameService(IInstrumentRepository instrumentRepository, int numberOfQuestions, int numberOfOptions)
        {
            this.instrumentRepository = instrumentRepository;
            this.numberOfQuestions = numberOfQuestions; ;
            this.numberOfOptions = numberOfOptions;
            playedInstruments = new List<InstrumentModel>();
        }

        public int Score { get; private set; }

        public void StartGame()
        {
            currentQuestion = null;
            playedInstruments.Clear();
            Score = 0;
        }

        public QuestionModel? GetNextQuestion()
        {
            if (playedInstruments.Count >= numberOfQuestions)
            {
                return null;
            }

            var instrument = GetInstrument();
            playedInstruments.Add(instrument);

            var question = currentQuestion = new QuestionModel { Instrument = instrument, Options = GetOptions(instrument) };
            return question;

        }

        public bool IsCorrectAnswer(string answer)
        {
            if (currentQuestion != null)
            {
                var isCorrect = answer.Equals(currentQuestion.Instrument.InstrumentName, StringComparison.OrdinalIgnoreCase);

                if (isCorrect)
                {
                    Score += 1;
                }
                return isCorrect;
            }
            return false;
        }

        private InstrumentModel GetInstrument()
        {
            InstrumentModel? instrument = null;
            do
            {
                instrument = instrumentRepository.GetRandomInstrument();
            }
            while (playedInstruments.Contains(instrument));

            return instrument;
        }

        private List<OptionModel> GetOptions(InstrumentModel selectedInstrument)
        {
            var instruments = new List<InstrumentModel>() { selectedInstrument };
            InstrumentModel? instrument = null;

            for (int i = 0; i < numberOfOptions - 1; i++)
            {
                do
                {
                    instrument = instrumentRepository.GetRandomInstrument();
                }
                while (instruments.Contains(instrument));

                instruments.Add(instrument);
            }
            return BuildOptions(instruments).OrderBy(o => Guid.NewGuid()).ToList();
        }
        private List<OptionModel> BuildOptions(List<InstrumentModel> instruments)
        {
            var options = new List<OptionModel>();

            foreach (var instrument in instruments)
            {
                options.Add(new OptionModel() { Text = instrument.InstrumentName, IsSelected = false });
            }
            return options;
        }
    }
}
