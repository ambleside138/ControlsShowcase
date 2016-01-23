using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using ControlsShowcase.Utils;
using System.Windows.Documents;
using System.Diagnostics;
using ControlsShowcase.Controls;

namespace ControlsShowcase.Behaviors
{
    public class GroupHeaderFrozenBehavior : Behavior<ItemsControl>
    {
        private static readonly Dictionary<GroupItem, WeakReference<HeaderAdorner>> _CurrentGroupItem = new Dictionary<GroupItem, WeakReference<HeaderAdorner>>();


        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(GroupHeaderFrozenBehavior), new PropertyMetadata(null));



        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += AssociatedObject_Loaded;
            
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            SetScrollChangedEvent();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();


        }


        private void SetScrollChangedEvent()
        {
            ScrollViewer scrollViewer;

            if(AssociatedObject is ListBox)
            {
                // リストボックス内のScrollViewerを探す
                scrollViewer = AssociatedObject.FindChild<ScrollViewer>();
            }
            else
            {
                // 親方向にScrollViewerを探す
                scrollViewer = AssociatedObject.FindParent<ScrollViewer>();
            }

            if (scrollViewer != null)
            {
                scrollViewer.ScrollChanged += ScrollViewer_ScrollChanged;
            }
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;

            // ScrollViewerの描画サイズ
            var scrollViewerRectangle = new Rect(new Point(0, 0), scrollViewer.RenderSize);

            // ItemsControlのGroupItem
            foreach(var containerItem in AssociatedObject.ItemContainerGenerator.Items)
            {
                // GroupItemコントロールを取得
                var groupItemContainer = AssociatedObject.ItemContainerGenerator.ContainerFromItem(containerItem) as GroupItem;
                if(groupItemContainer==null)
                {
                    Debug.WriteLine("Failed: get groupItemContainer");
                    return;
                }

                // ScrollViewerを基準とした描画位置を計算
                var transform = groupItemContainer.TransformToAncestor(scrollViewer);
                var groupItemRect = transform.TransformBounds(new Rect(new Point(0, 0), groupItemContainer.RenderSize));

                // ScrollViewerとGroupItemの重なり具合を確認
                var intersectRect = Rect.Intersect(scrollViewerRectangle, groupItemRect);

                // ヘッダー固定表示用のAdornerを表示する必要があるかどうか

                var needDisplayAdorner = true;
                needDisplayAdorner &= intersectRect != Rect.Empty;
                needDisplayAdorner &= groupItemRect.Top <= 0;

                // GroupItemのAdornerLayerを取得
                var adornerLayer = AdornerLayer.GetAdornerLayer(groupItemContainer);
                if(adornerLayer==null)
                {
                    Debug.WriteLine("Failed: get adornerLayer of GroupItem");
                    return;
                }

                if(needDisplayAdorner)
                {
                    // if we already have an adorner, update position
                    var headerAdorner = GetAdorner(groupItemContainer);
                    if (headerAdorner != null)
                    {
                        headerAdorner.UpdateLocation(groupItemRect.Top);
                        return;
                    }

                    // else, construct a new one.
                    var adorner = new HeaderAdorner(groupItemContainer)
                    {
                        DataContext = containerItem,
                        HeaderTemplate = HeaderTemplate,
                        Top = Math.Abs(groupItemRect.Top)
                    };
                    adornerLayer.Add(adorner);

                    // save a reference to this element,
                    _CurrentGroupItem.Add(groupItemContainer, new WeakReference<HeaderAdorner>(adorner));
                }
                else
                {
                    // locate and remove the adorner
                    var adorner = GetAdorner(groupItemContainer);
                    if (adorner != null)
                    {
                        adornerLayer.Remove(adorner);
                        _CurrentGroupItem.Remove(groupItemContainer);
                    }
                }
            }

        }


        private HeaderAdorner GetAdorner(GroupItem container)
        {
            if (_CurrentGroupItem.ContainsKey(container))
            {
                HeaderAdorner adorner;
                if (_CurrentGroupItem[container].TryGetTarget(out adorner))
                {
                    return adorner;
                }
            }

            return null;
        }
    }
}
