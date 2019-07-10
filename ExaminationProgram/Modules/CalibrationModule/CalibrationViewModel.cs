using System.Windows.Input;
using ExaminationProgram.Wizard;
using System.Collections.ObjectModel;
using ExaminationProgram.Abstractions;
using ExaminationProgram.Helpers;

namespace ExaminationProgram.Modules.CalibrationModule
{
    public class CalibrationViewModel : BaseViewModel
    {
        private WizardView wizardView;
        private ObservableCollection<SetupWizard> savedCalibrations;
        private ICommand clearSavedCalibrationsCommand;

        public ObservableCollection<SetupWizard> SavedCalibrations
        {
            get => savedCalibrations;
            set => SetValue(ref savedCalibrations, value);
        }
        public WizardView WizardView
        {
            get => wizardView;
            set => SetValue(ref wizardView, value);
        }

       
        public ICommand ClearSavedCalibrationsCommand
        {
            get => clearSavedCalibrationsCommand;
            set => SetValue(ref clearSavedCalibrationsCommand, value);
        }
        public CalibrationViewModel(string title, string iconName, ContextMediator contextMediator, WizardView wizardView) : base(title, iconName, contextMediator)
        {
            WizardView = wizardView;
            ClearSavedCalibrationsCommand = new DelegateCommand(() =>
                SavedCalibrations.Clear());
        }



    }
}
