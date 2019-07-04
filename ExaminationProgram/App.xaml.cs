using System.Windows;
using ExaminationProgram;
using ExaminationProgram.Instruments;
using ExaminationProgram.Modules.LogsModule;
using ExaminationProgram.Modules.DataBaseModule;
using ExaminationProgram.Modules.SettingsModule;
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
            var InstrumentalViewModel = new InstrumentalView();
            var SettingsViewModel = new SettingsView();
            var MeasurementsViewModel = new MeasurementsView();
            var DataBaseViewModel = new DataBaseView();
            var LogsViewModel = new LogsView();

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

            InstrumentalViewModel.DataContext = new InstrumentalViewModel("Модуль приборов", "appbar_power", ContextMediator ,new SignalAnalyzer(), new SignalGenerator()); 
            SettingsViewModel.DataContext = new SettingsViewModel("Модуль настроек", "appbar_settings", ContextMediator ) {Groups = SettingsGroupsContainer.SettingsGroups };            
            MeasurementsViewModel.DataContext = new MeasurementsViewModel("Автоматический режим", "appbar_axis_x", ContextMediator) {SettingsList = SettingsGroupsContainer.SettingsGroups };
            DataBaseViewModel.DataContext = new DataBaseViewModel("База данных", "appbar_database", ContextMediator );
            LogsViewModel.DataContext = new LogsViewModel("Лог", "appbar_disk", ContextMediator );

            shell
                .AddView(InstrumentalViewModel)
                .AddView(SettingsViewModel)
                .AddView(MeasurementsViewModel)
                .AddView(DataBaseViewModel)
                .AddView(LogsViewModel);

            var mainWindow = new MainWindow();
            mainWindow.DataContext = shell;

            mainWindow.Show();
        }
    }
}
