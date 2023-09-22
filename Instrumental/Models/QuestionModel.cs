using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrumental.Models
{
    public class QuestionModel
    {
        public InstrumentModel Instrument { get; set; }
        public List<OptionModel> Options { get; set; }
    }
}
