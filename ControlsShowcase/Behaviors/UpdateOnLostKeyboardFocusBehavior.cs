using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace ControlsShowcase.Behaviors
{
    public class UpdateOnLostKeyboardFocusBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.LostKeyboardFocus += AssociatedObject_LostKeyboardFocus;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.LostKeyboardFocus -= AssociatedObject_LostKeyboardFocus;
        }

        private void AssociatedObject_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            // 更新
            var be = textBox.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }
    }
}
