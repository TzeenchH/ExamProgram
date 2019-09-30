using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExaminationProgram.Helpers
{
    public class ExtendedMultiBinding : MultiBinding
    {
        public ExtendedMultiBinding(BindingBase b1, BindingBase b2)
        {
            Bindings.Add(b1);
            Bindings.Add(b2);
        }
    }
}
