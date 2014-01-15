using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CiaranONeill.NPV.Silverlight.Behaviours
{
    public class TextBoxFilterService
    {
        /// <summary>
        /// Filter Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.RegisterAttached("Filter", typeof(TextBoxFilterType),
            typeof(TextBoxFilterService), new PropertyMetadata(OnFilterChanged));

        /// <summary>
        /// Gets the Filter property. 
        /// </summary>
        public static TextBoxFilterType GetFilter(DependencyObject d)
        {
            return (TextBoxFilterType)d.GetValue(FilterProperty);
        }

        /// <summary>
        /// Sets the Filter property.  
        /// </summary>
        public static void SetFilter(DependencyObject d, TextBoxFilterType value)
        {
            d.SetValue(FilterProperty, value);
        }

        /// <summary>
        /// Handles changes to the Filter property.
        /// </summary>
        /// <param name="d">DependencyObject</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = d as TextBox;
            if (TextBoxFilterType.None != (TextBoxFilterType)e.OldValue)
            {
                textBox.KeyDown -= new KeyEventHandler(textBox_KeyDown);
            }
            if (TextBoxFilterType.None != (TextBoxFilterType)e.NewValue)
            {
                textBox.KeyDown += new KeyEventHandler(textBox_KeyDown);
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the textBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.KeyEventArgs"/> instance containing the event data.</param>
        private static void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            // bypass other keys!
            if (IsValidOtherKey(e.Key)) return;

            TextBoxFilterType filterType = GetFilter((DependencyObject)sender);
            TextBox textBox = sender as TextBox;
            if (null == textBox)
            {
                textBox = e.OriginalSource as TextBox;
            }

            switch (filterType)
            {
                case TextBoxFilterType.PositiveInteger:
                    e.Handled = !IsValidIntegerKey(textBox, e.Key, e.PlatformKeyCode, false);
                    break;
                case TextBoxFilterType.Integer:
                    e.Handled = !IsValidIntegerKey(textBox, e.Key, e.PlatformKeyCode, true);
                    break;
                case TextBoxFilterType.PositiveDecimal:
                    e.Handled = !IsValidDecmialKey(textBox, e.Key, e.PlatformKeyCode, false);
                    break;
                case TextBoxFilterType.Decimal:
                    e.Handled = !IsValidDecmialKey(textBox, e.Key, e.PlatformKeyCode, true);
                    break;
                case TextBoxFilterType.Alpha:
                    e.Handled = !IsValidAlphaKey(e.Key);
                    break;
            }
        }

        /// <summary>
        /// Determines whether the specified key is valid other key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if [is valid other key] [the specified key]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsValidOtherKey(Key key)
        {
            // allow control keys
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                return true;
            }
            // allow
            // Back, Tab, Enter, Shift, Ctrl, Alt, CapsLock, Escape, PageUp, PageDown
            // End, Home, Left, Up, Right, Down, Insert, Delete 
            // except for space!
            // allow all Fx keys
            if (
                (key < Key.D0 && key != Key.Space)
                || (key > Key.Z && key < Key.NumPad0))
            {
                return true;
            }
            // we need to examine all others!
            return false;
        }

        /// <summary>
        /// Determines whether the specified key is valid integer key for the specified text box.
        /// </summary>
        /// <param name="textBox">The text box.</param>
        /// <param name="key">The key.</param>
        /// <param name="platformKeyCode">The platform key code.</param>
        /// <param name="negativeAllowed">if set to true [negative allowed].</param>
        /// <returns>
        /// true if the specified key is valid integer key for the specified text box; otherwise, false.
        /// </returns>
        private static bool IsValidIntegerKey(TextBox textBox, Key key, int platformKeyCode, bool negativeAllowed)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0)
            {
                return false;
            }

            if (Key.D0 <= key && key <= Key.D9)
            {
                return true;
            }

            if (Key.NumPad0 <= key && key <= Key.NumPad9)
            {
                return true;
            }

            if (negativeAllowed && (key == Key.Subtract || (key == Key.Unknown && platformKeyCode == 189)))
            {
                return 0 == textBox.Text.Length;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the specified key is valid decmial key for the specified text box.
        /// </summary>
        /// <param name="textBox">The text box.</param>
        /// <param name="key">The key.</param>
        /// <param name="platformKeyCode">The platform key code.</param>
        /// <param name="negativeAllowed">If set to true [negative allowed].</param>
        /// <returns>
        /// true if the specified key is valid decmial key for the specified text box; otherwise, false.
        /// </returns>
        private static bool IsValidDecmialKey(TextBox textBox, Key key, int platformKeyCode, bool negativeAllowed)
        {
            if (IsValidIntegerKey(textBox, key, platformKeyCode, negativeAllowed))
            {
                return true;
            }
            if (key == Key.Decimal || (key == Key.Unknown && platformKeyCode == 190))
            {
                return !textBox.Text.Contains(".");
            }
            return false;
        }

        /// <summary>
        /// Determines whether the specified key is valid alpha key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// true if the specified key is valid alpha key for the specified text box; otherwise, false.
        /// </returns>
        private static bool IsValidAlphaKey(Key key)
        {
            if (Key.A <= key && key <= Key.Z)
            {
                return true;
            }
            return false;
        }
    }

    public enum TextBoxFilterType
    {
        None,
        PositiveInteger,
        Integer,
        PositiveDecimal,
        Decimal,
        Alpha,
    }
}
