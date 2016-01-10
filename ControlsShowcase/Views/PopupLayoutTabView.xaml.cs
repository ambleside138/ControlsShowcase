﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    }
}