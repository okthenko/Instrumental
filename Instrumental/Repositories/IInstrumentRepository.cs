using Instrumental.Models;
using System.Collections.Generic;

namespace Instrumental.Repositories
{
    public interface IInstrumentRepository
    {
        List<InstrumentModel> Instruments { get; }

        InstrumentModel GetRandomInstrument();
    }
}