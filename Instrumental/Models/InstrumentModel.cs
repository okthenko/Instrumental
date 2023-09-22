using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instrumental.Entities;

namespace Instrumental.Models
{
    public class InstrumentModel
    {
        public InstrumentModel(InstrumentEntity entity)
        {
            InstrumentName = entity.InstrumentName;
            ImageFileName = entity.ImageFileName;
            SoundFileName = entity.SoundFileName;
        }
        public string InstrumentName { get; }
        public string ImageFileName { get; }
        public string SoundFileName { get; }
    }
}
