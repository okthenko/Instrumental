using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrumental.Entities
{
    public class InstrumentEntity
    {
        public InstrumentEntity(Int64 id, string instrumentName, string imageFileName, string soundFileName)
        {
            this.Id = id;
            this.InstrumentName = instrumentName;
            this.ImageFileName = imageFileName;
            this.SoundFileName = soundFileName;
        }
        public Int64 Id { get; }
        public string InstrumentName { get; }
        public string ImageFileName { get; }
        public string SoundFileName { get; }
    }
}
