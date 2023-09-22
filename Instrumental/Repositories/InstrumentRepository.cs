using Instrumental.Models;
using Instrumental.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Instrumental.Repositories
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private ISqliteDataAccess sqliteDataAccess;
        private Random random;
        private List<InstrumentModel> instruments;

        public InstrumentRepository(ISqliteDataAccess sqliteDataAccess, Random? random = null)
        {
            this.sqliteDataAccess = sqliteDataAccess;
            this.random = random ?? new Random();
        }

        public List<InstrumentModel> Instruments
        {
            get
            {
                if (instruments != null) return instruments;

                instruments = new List<InstrumentModel>();
                var entities = sqliteDataAccess.LoadInstruments().ToList();
                entities.ForEach(e => instruments.Add(new InstrumentModel(e)));

                return instruments;
            }
        }

        public InstrumentModel GetRandomInstrument()
        {
            return Instruments[random.Next(Instruments.Count)];
        }

    }
}
