using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace ControlsShowcase.Behaviors
{
    public class DraggablePopupBehavior : Behavior<Popup>
    {
        private bool _IsMouseDown;
        private Point _OldPoint;
        private double _InitHorizontalOffset;
        private double _InitVerticalOffset;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
            AssociatedObject.Opened += AssociatedObject_Opened;
            AssociatedObject.Closed += AssociatedObject_Closed;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
            AssociatedObject.Opened -= AssociatedObject_Opened;
            AssociatedObject.Closed -= AssociatedObject_Closed;

            base.OnDetaching();
        }

        private void AssociatedObject_Opened(object sender, EventArgs e)
        {
            // 初期表示位置を確保
            _InitHorizontalOffset = AssociatedObject.HorizontalOffset;
            _InitVerticalOffset = AssociatedObject.VerticalOffset;
        }


        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Captureに成功した場合のみ_IsMouseDown = trueとなるようにする
            _IsMouseDown = AssociatedObject.Child.CaptureMouse();
            _OldPoint = AssociatedObject.PointToScreen(e.GetPosition(AssociatedObject));
            
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if(!_IsMouseDown)
            {
                return;
            }

            // 前回位置からの差分を計算
            var currentPoint = AssociatedObject.PointToScreen(e.GetPosition(AssociatedObject));
            var offset = currentPoint - _OldPoint;
            _OldPoint = currentPoint;

            AssociatedObject.HorizontalOffset += offset.X;
            AssociatedObject.VerticalOffset += offset.Y;
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // 後片付け
            _IsMouseDown = false;
            AssociatedObject.Child.ReleaseMouseCapture();
        }

        private void AssociatedObject_Closed(object sender, EventArgs e)
        {
            // 初期位置を元に戻す
            AssociatedObject.HorizontalOffset = _InitHorizontalOffset;
            AssociatedObject.VerticalOffset = _InitVerticalOffset;
        }
    }
}
