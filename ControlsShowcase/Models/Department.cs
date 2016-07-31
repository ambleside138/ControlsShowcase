using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Collections.ObjectModel;

namespace ControlsShowcase.Models
{
    public class Department : NotificationObject
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

        #region DepartmentId変更通知プロパティ
        private int _DepartmentId;

        public int DepartmentId
        {
            get
            { return _DepartmentId; }
            set
            { 
                if (_DepartmentId == value)
                    return;
                _DepartmentId = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region StaffGroups変更通知プロパティ
        private ObservableCollection<StaffGroup> _StaffGroups;

        public ObservableCollection<StaffGroup> StaffGroups
        {
            get
            { return _StaffGroups; }
            set
            { 
                if (_StaffGroups == value)
                    return;
                _StaffGroups = value;
                RaisePropertyChanged();
            }
        }
        #endregion

    }
}
