﻿using ExaminationProgram.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExaminationProgram.Modules.LogsModule
{
    /// <summary>
    /// Логика взаимодействия для LogsView.xaml
    /// </summary>
    public partial class LogsView : UserControl, IView
    {
        public LogsView()
        {
            InitializeComponent();
        }
        public IViewModel ViewModel { get; set; }
        public void ModuleAccesed(AccessTypes access)
        {
            switch (access)
            {
                case AccessTypes.Administrator:
                    this.Visibility = Visibility.Visible;
                    break;
                case AccessTypes.User:
                    this.Visibility = Visibility.Visible;
                    break;
                case AccessTypes.Watcher:
                    this.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}
