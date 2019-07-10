using System.Windows;
using ExaminationProgram.Wizard;
using ExaminationProgram.Instruments;
using ExaminationProgram.Modules.LogsModule;
using ExaminationProgram.Modules.DataBaseModule;
using ExaminationProgram.Modules.SettingsModule;
using ExaminationProgram.Modules.CalibrationModule;
using ExaminationProgram.Modules.InstrumentalModule;
using ExaminationProgram.Modules.MeasurementsModule;
using ExaminationProgram.Modules.SettingsModule.Settings;

namespace ExaminationProgram
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var shell = new Shell("АИК");
            var InstrumentalView = new InstrumentalView();
            var SettingsView = new SettingsView();
            var MeasurementsView = new MeasurementsView();
            var DataBaseView = new DataBaseView();
            var LogsView = new LogsView();
            var CalibrationView = new CalibrationView();
            var WizardView = new WizardView();

            var ContextMediator = new ContextMediator();
            var SettingsGroupsContainer = new SettingsGroupsContainer(
                new SettingsGroup("Group 1",
                    new DoubleSetting() { Name = "Setting1.1", Dimention = "Hz", Visible=true },
                    new IntSetting() { Name = "Setting1.2", Dimention = "Ohm", Visible = true }),
                new SettingsGroup("Group 2",
                    new DoubleSetting() { Name = "Setting2.1", Dimention = "dB", Visible = true },
                    new IntSetting() { Name = "Setting2.2", Dimention = "Sec", Visible = true }),
                new SettingsGroup("Group 3",
                    new DoubleSetting() { Name = "Setting3.1", Dimention = "mV", Visible = true },
                    new IntSetting() { Name = "Setting3.2", Dimention = "Rad", Visible = true }));

            var InstrumentalViewModel = new InstrumentalViewModel("Модуль приборов", "appbar_power", ContextMediator ,new SignalAnalyzer(), new SignalGenerator()); 
            var SettingsViewModel = new SettingsViewModel("Модуль настроек", "appbar_settings", ContextMediator ) {Groups = SettingsGroupsContainer.SettingsGroups };            
            var MeasurementsViewModel = new MeasurementsViewModel("Автоматический режим", "appbar_axis_x", ContextMediator) {SettingsList = SettingsGroupsContainer.SettingsGroups };
            var DataBaseViewModel = new DataBaseViewModel("База данных", "appbar_database", ContextMediator );
            var LogsViewModel = new LogsViewModel("Лог", "appbar_disk", ContextMediator );
            var CalibrationViewModel = new CalibrationViewModel("Модуль калибровки", "appbar_scale", ContextMediator, WizardView);
            var SetupWizard = new SetupWizard(ContextMediator);

            InstrumentalView.DataContext = InstrumentalViewModel;
            SettingsView.DataContext = SettingsViewModel;
            MeasurementsView.DataContext = MeasurementsViewModel;
            DataBaseView.DataContext = DataBaseViewModel;
            LogsView.DataContext = LogsViewModel;
            CalibrationView.DataContext = CalibrationViewModel;
            WizardView.DataContext = SetupWizard;
            ContextMediator
                .AddModuleReference(InstrumentalViewModel)
                .AddModuleReference(SettingsViewModel)
                .AddModuleReference(CalibrationViewModel)
                .AddModuleReference(MeasurementsViewModel)
                .AddModuleReference(DataBaseViewModel)
                .AddModuleReference(LogsViewModel);

            shell
                .AddView(InstrumentalView)
                .AddView(SettingsView)
                .AddView(CalibrationView)
                .AddView(MeasurementsView)
                .AddView(DataBaseView)
                .AddView(LogsView);

            var mainWindow = new MainWindow();
            mainWindow.DataContext = shell;

            mainWindow.Show();
        }
    }
}
