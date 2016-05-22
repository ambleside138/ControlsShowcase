using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace ControlsShowcase.Behaviors
{
    public class ClosePopupOnClickBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Click += AssociatedObject_Click;
        }


        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;

            base.OnDetaching();
        }


        private void AssociatedObject_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Popupを閉じる処理


        }
    }
}
