using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProgram.Interfaces
{
    public interface IReadOnly
    {
        bool IsReadOnly { get; set; }
    }
}
