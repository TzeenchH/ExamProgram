using ExaminationProgram.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProgram.Interfaces
{
    public interface IHasBoundedSteps
    {
        IList<BaseWizardStep> BoundedSteps { get; set; }
    }
}
