using Instrumental.Services;
using Instrumental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrumental.Commands
{
    class ReplayCommand : BaseCommand
    {
        private QuestionViewModel questionViewModel;
        public ReplayCommand(QuestionViewModel questionViewModel)
        { 
            this.questionViewModel = questionViewModel; 
        }

        public override void Execute(object? parameter)
        {
            questionViewModel.Question = questionViewModel.Question;
        }
    }
}
