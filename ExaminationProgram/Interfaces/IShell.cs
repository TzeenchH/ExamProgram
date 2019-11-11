using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProgram.Interfaces
{
    public interface IShell
    {
        IContainer Container { get; set; }
    }
}
