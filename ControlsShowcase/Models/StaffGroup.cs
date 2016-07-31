using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Collections.ObjectModel;

namespace ControlsShowcase.Models
{
    public class StaffGroup : NotificationObject
    {

        #region Name変更通知プロパティ
        private string _Name;

        public string Name
        {
            get
            { return _Name; }
            set
            { 
                if (_Name == value)
                    return;
                _Name = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Staffs変更通知プロパティ
        private ObservableCollection<Staff> _Staffs;

        public ObservableCollection<Staff> Staffs
        {
            get
            { return _Staffs; }
            set
            { 
                if (_Staffs == value)
                    return;
                _Staffs = value;
                RaisePropertyChanged();
            }
        }
        #endregion

    }
}
