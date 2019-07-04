using System.Collections.Generic;
using System.Collections.ObjectModel;
using ExaminationProgram.Helpers;

namespace ExaminationProgram
{
    class Container : ObservableBase
    {
        IList<IHasTitle> Titles = new List<IHasTitle>();
         
        ObservableCollection<IHasTitle> views { get; set; }
    }
}
