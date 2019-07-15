using System.Windows.Input;
using ExaminationProgram.Wizard;
using System.Collections.ObjectModel;
using ExaminationProgram.Abstractions;
using ExaminationProgram.Helpers;

namespace ExaminationProgram.Modules.CalibrationModule
{
    public class CalibrationViewModel : BaseViewModel
    {
        private WizardView _wizardView;
        private ObservableCollection<SetupWizard> savedCalibrations;
        private ICommand clearSavedCalibrationsCommand;
        private SetupWizard _setupWizard;

        private SetupWizard SetupWizard
        {
            get => _setupWizard;
            set => SetValue ( ref _setupWizard, value);
        }

        public ObservableCollection<SetupWizard> SavedCalibrations
        {
            get => savedCalibrations;
            set => SetValue(ref savedCalibrations, value);
        }
        public WizardView WizardView
        {
            get => _wizardView;
            set => SetValue(ref _wizardView, value);
        }


        public ICommand ClearSavedCalibrationsCommand
        {
            get => clearSavedCalibrationsCommand;
            set => SetValue(ref clearSavedCalibrationsCommand, value);
        }
        public CalibrationViewModel(string title, string iconName, ContextMediator contextMediator, WizardView wizardView, SetupWizard setupWizard) : base(title, iconName, contextMediator)
        {
            WizardView = wizardView;
            SetupWizard = setupWizard;
            WizardView.DataContext = SetupWizard;
            ClearSavedCalibrationsCommand = new DelegateCommand(() =>
                SavedCalibrations.Clear());
        }



    }
}
