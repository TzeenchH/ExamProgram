using ExaminationProgram.Wizard;

namespace ExaminationProgram.Interfaces
{
    //ILinkedStep
    public interface ILinkedInstance<TLinkedStep> where TLinkedStep : BaseWizardStep
    {
        TLinkedStep PrevStep { get; set; }
        TLinkedStep NextStep { get; set; }
    }
}
