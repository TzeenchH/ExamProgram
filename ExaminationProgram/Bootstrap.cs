using ExaminationProgram.Abstractions;
using ExaminationProgram.Instruments;
using ExaminationProgram.Modules.DataBaseModule;
using ExaminationProgram.Modules.InstrumentalModule;
using ExaminationProgram.Modules.LogsModule;
using ExaminationProgram.Modules.MeasurementsModule;
using ExaminationProgram.Modules.SettingsModule;
using ExaminationProgram.Modules.SettingsModule.Settings;
using ExaminationProgram.Wizard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Autofac;
using System.Threading.Tasks;
using ExaminationProgram.Interfaces;
using ExaminationProgram.Modules.CalibrationModule;
using ExaminationProgram.Modules.LoggingModule;
using MahApps.Metro.Controls;

namespace ExaminationProgram
{
    public class Bootstrap : IBootstrap
    {
        public IShell Initialize()
        {
            var container = ConfigureContainer();
            var shell = container.Resolve<IShell>();
            shell.Container = container;
            var MainWindow = container.Resolve<MainWindow>() as MetroWindow;
            return shell;
        }
            
        
        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>()
                .AsSelf()
                .SingleInstance();
            ConfigureCalibrationModule(builder);
            ConfigureDatabaseModule(builder);
            ConfigureInstrumentalModule(builder);
            ConfigureLoggingWindow(builder);
            ConfigureLogsModule(builder);
            ConfigureMeasurementsModule(builder);
            ConfigureSettingsModule(builder);
            ConfigureWizard(builder);
            return builder.Build();
        }

        private static void ConfigureLoggingWindow(ContainerBuilder builder)
        {
            builder.RegisterType<LogginWindowView>()
                .AsSelf()
                .SingleInstance();
            builder.RegisterType<LoggingWindowViewModel>()
                .AsSelf()
                .SingleInstance();
        }
        private static void ConfigureCalibrationModule(ContainerBuilder builder)
        {
            builder.RegisterType<CalibrationViewModel>()
                .As<IViewModel>();
            builder.RegisterType<CalibrationView>()
                .As<IView>();
        }

        private static void ConfigureDatabaseModule(ContainerBuilder builder)
        {
            builder.RegisterType<DataBaseViewModel>()
                .As<IViewModel>();

            builder.RegisterType<DataBaseView>()
               .As<IView>();               
        }
           

        private static void ConfigureInstrumentalModule(ContainerBuilder builder)
        {
            builder.RegisterType<InstrumentalViewModel>()
                .As<IViewModel>();
            builder.RegisterType<InstrumentalView>()
                .As<IView>();
        }

        private static void ConfigureLogsModule(ContainerBuilder builder)
        {
            builder.RegisterType<LogsViewModel>()
                .As<IViewModel>();
            builder.RegisterType<LogsView>()
                .As<IView>();
        }
        private static void ConfigureMeasurementsModule(ContainerBuilder builder)
        {
            builder.RegisterType<MeasurementsViewModel>()
                .As<IViewModel>();
            builder.RegisterType<MeasurementsView>()
                .As<IView>();
        }
        private static void ConfigureSettingsModule(ContainerBuilder builder)
        {
            builder.RegisterType<SettingsViewModel>()
                .As<IViewModel>();
            builder.RegisterType<SettingsView>()
                .As<IView>();
        }

        private static void ConfigureWizard(ContainerBuilder builder)
        {
            builder.RegisterType<WizardView>()
                .AsSelf()
                .SingleInstance();
            builder.RegisterType<SetupWizard>()
                .AsSelf()
                .SingleInstance();
        }
        
    }
}
