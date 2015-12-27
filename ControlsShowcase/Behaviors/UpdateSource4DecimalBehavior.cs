using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace ControlsShowcase.Behaviors
{
    /// <summary>
    /// 小数をテキストボックスにバインドするときに利用するBehavior
    /// </summary>
    public class UpdateSource4DecimalBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.TextChanged += AssociatedObject_TextChanged;
            AssociatedObject.LostKeyboardFocus += AssociatedObject_LostKeyboardFocus;
        }


        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.TextChanged -= AssociatedObject_TextChanged;
            AssociatedObject.LostKeyboardFocus -= AssociatedObject_LostKeyboardFocus;
        }


        private void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 「.」を含むときはソースを更新しない
            if (!string.IsNullOrEmpty(AssociatedObject.Text) && AssociatedObject.Text.Contains("."))
            {
                return;
            }

            // 更新
            var be = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
           
        }

        private void AssociatedObject_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            // 更新
            var be = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();

        }
    }
}
