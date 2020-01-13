using System;

namespace ExaminationProgram.Interfaces
{
    public interface ISetting: IsVisible, ICloneable
    {
        string Name { get; set; }
        string Dimention { get; set; }
        
        
    }
}
