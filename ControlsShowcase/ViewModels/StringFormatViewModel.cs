using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using ControlsShowcase.Models;

namespace ControlsShowcase.ViewModels
{
    public class StringFormatViewModel : ViewModel
    {

        #region Sample1変更通知プロパティ
        private decimal _Sample1;

        public decimal Sample1
        {
            get
            { return _Sample1; }
            set
            { 
                if (_Sample1 == value)
                    return;
                _Sample1 = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Sample2変更通知プロパティ
        private decimal _Sample2;

        public decimal Sample2
        {
            get
            { return _Sample2; }
            set
            { 
                if (_Sample2 == value)
                    return;
                _Sample2 = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Sample3変更通知プロパティ
        private decimal _Sample3;

        public decimal Sample3
        {
            get
            { return _Sample3; }
            set
            { 
                if (_Sample3 == value)
                    return;
                _Sample3 = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public StringFormatViewModel()
        {
            Sample1 = 1M;/// 1.235556M;
            Sample2 = 3.45M;
        }
    }
}
