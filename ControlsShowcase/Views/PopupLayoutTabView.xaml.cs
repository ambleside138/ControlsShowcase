using ControlsShowcase.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlsShowcase.Views
{
    /// <summary>
    /// PopupLayoutTabView.xaml の相互作用ロジック
    /// </summary>
    public partial class PopupLayoutTabView : UserControl
    {
        public PopupLayoutTabView()
        {
            InitializeComponent();
        }

        private void popup_Click(object sender, RoutedEventArgs e)
        {
            preview.IsOpen = true;
        }

        private void StyleButton_Click(object sender, RoutedEventArgs e)
        {
            stylePopup.IsOpen = true;
        }

        private void dragPopup_Click(object sender, RoutedEventArgs e)
        {
            dragPopup.IsOpen = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("### Popup");
            LogicalTreeUtil.PrintLogicalTree(treeTestPopup);
            VisualTreeUtil.PrintVisualTree(treeTestPopup);

            Debug.WriteLine("### PopupContent");
            LogicalTreeUtil.PrintLogicalTree(popupBasePanel);
            VisualTreeUtil.PrintVisualTree(popupBasePanel);

            var popup = LogicalTreeUtil.FindParent<Popup>((Button)sender);
            if(popup != null)
            {
                popup.IsOpen = false;
            }
        }

        private void treeTestPopupButton_Click(object sender, RoutedEventArgs e)
        {
            treeTestPopup.IsOpen = true;
        }

        private void StaffButton_Click(object sender, RoutedEventArgs e)
        {


            var itemscontrol = VisualTreeUtil.FindParent<ItemsControl>((Button)sender);

            var popup = LogicalTreeUtil.FindParent<Popup>(itemscontrol);
            if (popup != null)
            {
                popup.IsOpen = false;
            }
        }



    }
}
