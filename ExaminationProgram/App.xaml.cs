﻿using System.Windows;
using ExaminationProgram.Modules.LoggingModule;
using ExaminationProgram.Wizard;
using ExaminationProgram.Instruments;
using ExaminationProgram.Modules.LogsModule;
using ExaminationProgram.Modules.DataBaseModule;
using ExaminationProgram.Modules.SettingsModule;
using ExaminationProgram.Modules.CalibrationModule;
using ExaminationProgram.Modules.InstrumentalModule;
using ExaminationProgram.Modules.MeasurementsModule;
using ExaminationProgram.Modules.SettingsModule.Settings;
using System.Collections.ObjectModel;

namespace ExaminationProgram
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Shell shell = new Shell("АИК");
            var LogWindow = new LogginWindowView();
            var LogWindowViewModel = new LoggingWindowViewModel(shell);
            var InstrumentalView = new InstrumentalView();
            var SettingsView = new SettingsView();
            var MeasurementsView = new MeasurementsView();
            var DataBaseView = new DataBaseView();
            var LogsView = new LogsView();
            var CalibrationView = new CalibrationView();
            var WizardView = new WizardView();
            var ContextMediator = new ContextMediator();
            LogWindow.DataContext = LogWindowViewModel;
            LogWindow.Show();
            //LogWindow




            var SubStep1 = new ExecutableWizardStepBuilder()
                .SetName("SubStep1.1")
                .SetDescription("description for substep 1.1")
                .SetReadOnly(false)
                .SetSelectable(true)
                .AddAction((s, c, o) =>
                {
                    try
                    {

                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    finally
                    {

                    }
                })
                .Build();

            var SubStep2 = new ExecutableWizardStepBuilder()
                .SetName("SubStep1.2")
                .SetDescription("description for substep 1.2")
                .SetReadOnly(false)
                .SetSelectable(true)
                .AddAction((s, c, o) =>
                {
                    try
                    {

                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    finally
                    {

                    }
                })
                .Build();

            var SubSubStep1 = new ExecutableWizardStepBuilder()
                .SetName("SubSubStep1.3.1")
                .SetDescription("description for subsubstep 1.3.1")
                .SetReadOnly(false)
                .SetSelectable(true)
                .AddAction((s, c, o) =>
                {
                    try
                    {

                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    finally
                    {

                    }
                })
                .Build();

            var SubSubStep2 = new ExecutableWizardStepBuilder()
                .SetName("SubSubStep1.3.2")
                .SetDescription("description for subsubstep 1.3.2")
                .SetReadOnly(false)
                .SetSelectable(true)
                .AddAction((s, c, o) =>
                {
                    try
                    {

                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    finally
                    {

                    }
                })
                .Build();

            var GrouppedStep1_3 = new WizardStepGroupBuilder()
                .SetName("SubGruop1.3")
                .SetDescription("description for subgroup 1.3")
                .AddChildren(SubSubStep1)
                .AddChildren(SubSubStep2)
                .Build();

            var GrouppedStep1 = new WizardStepGroupBuilder()
                .SetName("Group1")
                .SetDescription("description for subgroup 1")
                .AddChildren(SubStep1)
                .AddChildren(SubStep2)
                .AddChildren(GrouppedStep1_3)
                .Build();

            var Step2 = new ExecutableWizardStepBuilder()
                .SetName("Step2")
                .SetIconName("Settings")
                .SetDescription("description for step 2")
                .SetReadOnly(false)
                .SetSelectable(true)
                .AddBoundedStep(SubSubStep1)
                .AddBoundedStep(GrouppedStep1)
                .AddAction((s, c, o) =>
                {
                    try
                    {

                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    finally
                    {

                    }
                })
                .Build();

            var SubStep3_1 = new ExecutableWizardStepBuilder()
                .SetName("SubStep3.1")
                .SetDescription("description for substep 3.1")
                .SetReadOnly(false)
                .SetSelectable(true)
                .AddAction((s, c, o) =>
                {
                    try
                    {

                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    finally
                    {

                    }
                })
                .Build();

            var GrouppedStep3 = new WizardStepGroupBuilder()
                .SetName("Group3")
                .SetDescription("description for group 3")
                .AddChildren(SubStep3_1)
                .Build();
            var Step4 = new ExecutableWizardStepBuilder()
                .SetName("Step4")
                .SetIconName("Settings")
                .SetDescription("description for step 2")
                .SetReadOnly(false)
                .SetSelectable(true)
                .AddAction((s, c, o) =>
                {
                    try
                    {

                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    finally
                    {

                    }
                })
                .Last(true)
                .Build();

            var TestData = new TestData();
            var SettingsGroupsContainer = new SettingsGroupsContainer(
                new SettingsGroup("Group 1",
                    new DoubleSetting() { Name = "Setting1.1", Dimention = "Hz", Visible = true },
                    new IntSetting() { Name = "Setting1.2", Dimention = "Ohm", Visible = true }),
                new SettingsGroup("Group 2",
                    new DoubleSetting() { Name = "Setting2.1", Dimention = "dB", Visible = true },
                    new IntSetting() { Name = "Setting2.2", Dimention = "Sec", Visible = true }),
                new SettingsGroup("Group 3",
                    new DoubleSetting() { Name = "Setting3.1", Dimention = "mV", Visible = true },
                    new IntSetting() { Name = "Setting3.2", Dimention = "Rad", Visible = true }));

            var InstrumentalViewModel = new InstrumentalViewModel("Модуль приборов", "appbar_power", ContextMediator, new SignalAnalyzer(), new SignalGenerator());
            var SettingsViewModel = new SettingsViewModel("Модуль настроек", "appbar_settings", ContextMediator, SettingsGroupsContainer.SettingsGroups);
            var MeasurementsViewModel = new MeasurementsViewModel("Автоматический режим", "appbar_axis_x", ContextMediator, TestData) { SettingsList = SettingsGroupsContainer.SettingsGroups };
            var DataBaseViewModel = new DataBaseViewModel("База данных", "appbar_database", ContextMediator);
            var LogsViewModel = new LogsViewModel("Лог", "appbar_disk", ContextMediator);

            var SetupWizard = new SetupWizardBuilder()
                .AddStep(GrouppedStep1)
                .AddStep(Step2)
                .AddStep(GrouppedStep3)
                .AddStep(Step4)
                .ConfigureWizard()
                .Build();

            LogWindow.DataContext = LogWindowViewModel;
            InstrumentalView.DataContext = InstrumentalViewModel;
            SettingsView.DataContext = SettingsViewModel;
            MeasurementsView.DataContext = MeasurementsViewModel;
            DataBaseView.DataContext = DataBaseViewModel;
            LogsView.DataContext = LogsViewModel;
            WizardView.DataContext = SetupWizard;

            var CalibrationViewModel = new CalibrationViewModel("Модуль калибровки", "appbar_scale", ContextMediator, WizardView, SetupWizard);
            CalibrationView.DataContext = CalibrationViewModel;

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


            //var mainWindow = new MainWindow();
            //mainWindow.DataContext = shell;


            
           

        }
    }
}
