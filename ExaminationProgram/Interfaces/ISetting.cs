using System;

namespace ExaminationProgram.Interfaces
{
    public interface ISetting: IsVisible
    {
        string Name { get; set; }
        string Dimention { get; set; }
        
        
    }
}
