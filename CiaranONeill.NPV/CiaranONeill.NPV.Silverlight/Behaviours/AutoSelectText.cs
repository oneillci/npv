using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CiaranONeill.NPV.Silverlight.Behaviours
{
    public class AutoSelectText
    {
        public static bool GetAutoSelectText(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoSelectTextProperty);
        }

        public static void SetAutoSelectText(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoSelectTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for AutoSelectText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoSelectTextProperty =
            DependencyProperty.RegisterAttached("AutoSelectText", typeof(bool), typeof(AutoSelectText), new PropertyMetadata(OnAutoSelectTextChanged));

        private static void OnAutoSelectTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //This works because of event bubbling. 
            FrameworkElement frameworkElement = d as FrameworkElement;
            if (frameworkElement != null)
            {
                if ((bool)e.NewValue)
                    frameworkElement.GotFocus += OnGotFocus;
                else
                    frameworkElement.GotFocus -= OnGotFocus;
            }
        }
  
        private static void OnGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = FocusManager.GetFocusedElement() as TextBox;
            textBox.SelectAll();
        }

    }
}
