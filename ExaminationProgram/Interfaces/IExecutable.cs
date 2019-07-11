using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProgram.Interfaces
{
    public interface IExecutable <TThis, TMediator, TOutsideObject>
    {
        Action<TThis, TMediator , TOutsideObject> ExecuteStep { get; set; }
    }
}
