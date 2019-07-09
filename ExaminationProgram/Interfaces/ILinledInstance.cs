using ExaminationProgram.Wizard;

namespace ExaminationProgram.Interfaces
{
    //ILinkedStep
    public interface ILinledInstance<TLinkedStep> where TLinkedStep : WizardStep
    {
        TLinkedStep PrevStep { get; set; }
        TLinkedStep NextStep { get; set; }
    }
}
