using System;
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
    public enum InputStatus
    {
        Template,
        FirstPlaceHolder,
        SecondPlaceHolder,
        ThirdPlaceHolder,
    }

    /// <summary>
    /// TemplateInputNavigationTabView.xaml の相互作用ロジック
    /// </summary>
    public partial class TemplateInputNavigationTabView : UserControl
    {
        private InputStatus _InputStatus;

        public TemplateInputNavigationTabView()
        {
            InitializeComponent();

            _InputStatus = Views.InputStatus.Template;
            VisualStateManager.GoToState(this, "SelectTemplate", false);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            switch(_InputStatus)
            {
                case Views.InputStatus.FirstPlaceHolder:
                    VisualStateManager.GoToState(this, "SelectTemplate", true);
                    _InputStatus = Views.InputStatus.Template;
                    break;
                case Views.InputStatus.SecondPlaceHolder:
                    VisualStateManager.GoToState(this, "Select1stPlaceHolder", true);
                    _InputStatus = Views.InputStatus.FirstPlaceHolder;
                    break;
                case Views.InputStatus.ThirdPlaceHolder:
                    VisualStateManager.GoToState(this, "Select2ndPlaceHolder", true);
                    _InputStatus = Views.InputStatus.SecondPlaceHolder;
                    break;
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            switch (_InputStatus)
            {
                case Views.InputStatus.Template:
                    VisualStateManager.GoToState(this, "Select1stPlaceHolder", true);
                    _InputStatus = Views.InputStatus.FirstPlaceHolder;
                    break;

                case Views.InputStatus.FirstPlaceHolder:
                    VisualStateManager.GoToState(this, "Select2ndPlaceHolder", true);
                    _InputStatus = Views.InputStatus.SecondPlaceHolder;
                    break;
                case Views.InputStatus.SecondPlaceHolder:
                    VisualStateManager.GoToState(this, "Select3rdPlaceHolder", true);
                    _InputStatus = Views.InputStatus.ThirdPlaceHolder;
                    break;
                case Views.InputStatus.ThirdPlaceHolder:
                    break;
            }
        }
    }
}
