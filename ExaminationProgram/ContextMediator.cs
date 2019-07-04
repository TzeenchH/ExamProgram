using ExaminationProgram.Helpers;
using ExaminationProgram.Abstractions;
using ExaminationProgram.Modules.LogsModule;
using ExaminationProgram.Modules.SettingsModule;
using ExaminationProgram.Modules.DataBaseModule;
using ExaminationProgram.Modules.InstrumentalModule;
using ExaminationProgram.Modules.MeasurementsModule;
using System.Collections.Generic;
using System;

namespace ExaminationProgram
{
    public class ContextMediator : ObservableBase
    {
        private IDictionary<Type, BaseViewModel> modulesReferences
        { get; set; } 

        public ContextMediator AddModuleReference<T>(T viewModel)
            where T : BaseViewModel
        {
            //TODO check is module exists
            if (modulesReferences.ContainsKey(typeof(T)))
            {
                throw new Exception("Данный объект уже добавлен");
            }
            modulesReferences.Add(typeof(T), viewModel);
            return this;
        }

        public T GetModule<T>()
            where T : BaseViewModel
            => (T)modulesReferences[typeof(T)];    
        public ContextMediator()
        {
            modulesReferences = new Dictionary<Type, BaseViewModel>();
        }
    }
}
