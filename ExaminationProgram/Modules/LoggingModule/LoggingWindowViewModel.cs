using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using ExaminationProgram.Helpers;
using System.Windows;
using System.Reflection;

namespace ExaminationProgram.Modules.LoggingModule
{
    class LoggingWindowViewModel : ObservableBase
    {
        private string loginName;
        private string password;
        private ICommand autcorizateCommand;
        private bool authorized;
        
        public string LoginName
        {
            get => loginName;
            set => SetValue(ref loginName, value);
        }
        public string Password
        {
            get => password;
            set => SetValue(ref password, value);
        }
       
        public bool Authorized
        {
            get => authorized;
            set => SetValue(ref authorized, value);
        }       
        public  ICommand AutcorizateCommand
        {
            get => autcorizateCommand;
            set => SetValue(ref autcorizateCommand, value);
        }

        public LoggingWindowViewModel( Shell shell)
        {
             AutcorizateCommand = new DelegateCommand(() =>
             {               
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.DataContext = shell;
                    mainWindow.Show();
                    App.Current.Windows[0].Close();
                }
            },
            () => CanLogging()); ;
        }

        private bool CanLogging()
        {

            if (String.IsNullOrEmpty(LoginName) || String.IsNullOrWhiteSpace(LoginName))
                return false;
            else if (String.IsNullOrWhiteSpace(Password) || String.IsNullOrEmpty(Password))
                return false;
            else return true;

        }
        

    }
}
