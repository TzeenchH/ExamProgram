using ExaminationProgram.Wizard;

namespace ExaminationProgram.Abstractions
{
    public abstract class WizardStepBuilder<TStep, TBuilder>
        where TStep : BaseWizardStep
        where TBuilder : WizardStepBuilder<TStep, TBuilder>
    {
        protected TStep executedWizardStep { get; set; }        
        public TBuilder SetName(string name)
        {
            executedWizardStep.Name = name;
            return (TBuilder)this;
        }

        public TBuilder SetIconName (string iconName)
        {
            executedWizardStep.IconName = iconName;
            return (TBuilder)this;
        }

        public TBuilder SetDescription(string description)
        {
            executedWizardStep.Description = description;
            return (TBuilder)this;
        }

        public TBuilder SetReadOnly(bool @readonly)
        {
            executedWizardStep.IsReadOnly = @readonly;
            return (TBuilder)this;
        }
           
        public TBuilder SetSelectable (bool selectable)
        {
            executedWizardStep.IsSelected = selectable;
            return (TBuilder)this;
        }

        public TBuilder SetParent(BaseWizardStep parent)
        {
            executedWizardStep.Parent = parent;
            return (TBuilder)this;
        }


    }
}
