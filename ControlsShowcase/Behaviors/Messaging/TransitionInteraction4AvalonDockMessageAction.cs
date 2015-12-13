using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Interactivity;

using Livet.Messaging;
using Livet.Behaviors.Messaging;
using Xceed.Wpf.AvalonDock.Controls;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace ControlsShowcase.Behaviors.Messaging
{
    //Tはこのアクションがアタッチできる型を表します。
    //この場合はこのアクションはFrameworkElementにアタッチできます。
    public class TransitionInteraction4AvalonDockMessageAction : TransitionInteractionMessageAction
    {

        private static bool IsValidWindowType(Type value)
        {
            if (value != null)
            {
                if (value.IsSubclassOf(typeof(Window)))
                {
                    return value.GetConstructor(Type.EmptyTypes) != null;
                }
            }

            return false;
        }



        protected override void InvokeAction(InteractionMessage message)
        {
            var transitionMessage = message as TransitionMessage;

            if (transitionMessage == null) return;

            Type targetType;

            if (transitionMessage.WindowType != null)
            {
                targetType = transitionMessage.WindowType;
            }
            else
            {
                targetType = WindowType;
            }

            if (!IsValidWindowType(targetType))
            {
                return;
            }

            var defaultConstructor = targetType.GetConstructor(Type.EmptyTypes);

            if (Mode == TransitionMode.UnKnown && transitionMessage.Mode == TransitionMode.UnKnown)
            {
                return;
            }

            var mode = transitionMessage.Mode == TransitionMode.UnKnown ? Mode : transitionMessage.Mode;

            switch (mode)
            {
                case TransitionMode.Normal:
                case TransitionMode.Modal:
                    var targetWindow = (Window)defaultConstructor.Invoke(null);
                    if (transitionMessage.TransitionViewModel != null)
                    {
                        targetWindow.DataContext = transitionMessage.TransitionViewModel;
                    }

                    if (IsOwned)
                    {
                        targetWindow.Owner = GetParentWindow4Avalon(AssociatedObject);
                    }

                    if (mode == TransitionMode.Normal)
                    {
                        targetWindow.Show();
                        transitionMessage.Response = null;
                    }
                    else
                    {
                        transitionMessage.Response = targetWindow.ShowDialog();
                    }

                    break;
                case TransitionMode.NewOrActive:
                    var window = Application.Current.Windows
                        .OfType<Window>()
                        .FirstOrDefault(w => w.GetType() == targetType);

                    if (window == null)
                    {
                        window = (Window)defaultConstructor.Invoke(null);

                        if (transitionMessage.TransitionViewModel != null)
                        {
                            window.DataContext = transitionMessage.TransitionViewModel;
                        }
                        if (IsOwned)
                        {
                            window.Owner = GetParentWindow4Avalon(AssociatedObject);
                        }
                        window.Show();
                        transitionMessage.Response = null;
                    }
                    else
                    {
                        if (transitionMessage.TransitionViewModel != null)
                        {
                            window.DataContext = transitionMessage.TransitionViewModel;
                        }
                        if (IsOwned)
                        {
                            window.Owner = GetParentWindow4Avalon(AssociatedObject);
                        }
                        window.Activate();
                        // 最小化中なら戻す
                        if (window.WindowState == WindowState.Minimized)
                        {
                            window.WindowState = WindowState.Normal;
                        }
                        transitionMessage.Response = null;
                    }

                    break;
            }

        }

        // AvalonDock使用時にFloatingWindowを親にしたい
        private Window GetParentWindow4Avalon(DependencyObject dp)
        {
            if (dp == null)
            {
                return null;
            }

            if (dp is Window)
            {
                return dp as Window;
            }
            else if( dp is LayoutAnchorableControl)
            {
                var model = ((LayoutAnchorableControl)dp).Model as LayoutAnchorable;

                var parentFloatingWindow = model.FindParent<LayoutAnchorableFloatingWindow>();

                if (parentFloatingWindow != null)
                {
                    return model.Root.Manager.FloatingWindows.Single(fwc => fwc.Model == parentFloatingWindow);
                }
                // ドッキング状態の場合はいつも通りGetWindowする
                else
                {
                    return Window.GetWindow(AssociatedObject);
                }
            }


            return GetParentWindow4Avalon(VisualTreeHelper.GetParent(dp));
        }
    }
}
