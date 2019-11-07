using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationProgram;

namespace ExaminationProgram.Interfaces
{
    interface IView
    {
        IViewModel ViewModel { get; set; }

        void ModuleAccesed(AccessTypes access);
    }
}
