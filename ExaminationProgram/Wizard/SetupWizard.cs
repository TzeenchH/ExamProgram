using System.Windows.Input;
using ExaminationProgram.Helpers;
using System.Collections.ObjectModel;
using System;
using ExaminationProgram.Interfaces;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ExaminationProgram.Wizard
{
    public class SetupWizard : ObservableBase
    {
        private BaseWizardStep selectedStep;
        private ICommand nextStepCommand;
        private ICommand previousStepCommand;

        public static string ExecutedCounts = "1/3";
        private ICommand executeCommand;
        ContextMediator contextMediator;
       
        
        public ObservableCollection<BaseWizardStep> WizardSteps { get; set; }   
        

        XDocument WizardConfigurations;       

        public ICommand NextStepCommand
        {
            get => nextStepCommand;
            set => SetValue(ref nextStepCommand, value);
        }
        public ICommand PreviousStepCommand
        {
            get => previousStepCommand;
            set => SetValue(ref previousStepCommand, value);
        }
        public ICommand ExecuteCommand
        {
            get => executeCommand;
            set => SetValue(ref executeCommand, value);
        }
        public SetupWizard()
        {
            
            WizardConfigurations = new XDocument();
            XElement WizardConfiguration = new XElement("ConfigurationSteps");
            string date = DateTime.Now.ToString("dd.MM.yy HH.mm.ss");
            if (!Directory.Exists("WizardLog"))
                Directory.CreateDirectory("WizardLog");           
            NextStepCommand = new DelegateCommand(() =>
            {
                XElement Step = new XElement("Step");
                XAttribute Name = new XAttribute("name", $"Имя Шага: {SelectedStep.Name}");
                XElement Status = new XElement("status", $"Статус Завершения: {SelectedStep.IsCompleted}");
                XElement Time = new XElement("DateTime", $"Время Выполнения: {date}");
                Step.Add(Name);
                Step.Add(Status);
                Step.Add(Time);
                WizardConfiguration.Add(Step);
                SelectedStep = SelectedStep.NextStep;
            }, () => SelectedStep.NextStep != null);
            PreviousStepCommand = new DelegateCommand(() =>
            {
                
                SelectedStep = SelectedStep.PrevStep;
            }, () => SelectedStep.PrevStep != null);

            ExecuteCommand = new DelegateCommand(()=>
            {                
                try
                {                    
                    (SelectedStep as IExecutable<BaseWizardStep, ContextMediator, object>).ExecuteStep.Invoke(SelectedStep, contextMediator, null);
                    SelectedStep.IsCompleted = !SelectedStep.IsCompleted;                   
                    if (((ExecutableWizardStep)SelectedStep).IsLast)
                    {
                        WizardConfigurations.Add(WizardConfiguration);
                        WizardConfigurations.Save($".\\WizardLog\\SaveConfig{date}.xml");
                    }
                }
                catch (Exception ex)
                {
                    if (ex is NullReferenceException)
                    {
                        SelectedStep.HasError = "действие для данного шага не создано";
                    }
                }
            },()=> SelectedStep is ExecutableWizardStep);
        }
        

        public BaseWizardStep SelectedStep
        {
            get => selectedStep;
            set => SetValue(ref selectedStep, value);
        }

        public static SetupWizardBuilder CreateBuilder()
        {
            return new SetupWizardBuilder();
        }

    }
}
