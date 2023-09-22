using Instrumental.Entities;
using System.Collections.Generic;

namespace Instrumental.Services
{
    public interface ISqliteDataAccess
    {
        IEnumerable<InstrumentEntity> LoadInstruments();
    }
}