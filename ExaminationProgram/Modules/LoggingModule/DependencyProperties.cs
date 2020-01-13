using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace ExaminationProgram.Modules.LoggingModule
{
    public class DependencyProperties : Selector
    {
        public bool IsMenuClosed
        {
            get { return (bool)GetValue(IsMenuOpenedProperty); }
            set { SetValue(IsMenuOpenedProperty, value); }
        }

        public static readonly DependencyProperty IsMenuOpenedProperty =
            DependencyProperty.Register("IsMenuClosed", typeof(bool), typeof(LoggingWindowViewModel),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (o, e) =>
                {
                }));
    }
}
