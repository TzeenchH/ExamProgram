using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Interactivity;
using ExaminationProgram.Interfaces;

namespace ExaminationProgram.Helpers
{
    public class IconBehaviour : Behavior<Rectangle> , IHasIconName
    {
        public string IconName
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("IconName", typeof(string), typeof(IconBehaviour), new FrameworkPropertyMetadata("appbar_settings"));

        protected override void OnAttached()
        {
            base.OnAttached();
            if (IconName == null)
                IconName = "appbar_settings";

            var resourse = Application.Current.FindResource(IconName);
            AssociatedObject.OpacityMask = new VisualBrush()
            {
                Visual = resourse as Canvas,
            };
        }
    }

}
