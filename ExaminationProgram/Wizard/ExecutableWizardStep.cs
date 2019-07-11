using ExaminationProgram.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProgram.Wizard
{
    public class ExecutableWizardStep : BaseWizardStep, IExecutable<BaseWizardStep, ContextMediator, object>
    {
        public Action<BaseWizardStep, ContextMediator, object> ExecuteStep { get; set; }        
    }
}
