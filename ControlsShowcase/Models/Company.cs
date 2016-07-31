using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Collections.ObjectModel;

namespace ControlsShowcase.Models
{
    public class Company : NotificationObject
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

        #region Adress変更通知プロパティ
        private string _Adress;

        public string Adress
        {
            get
            { return _Adress; }
            set
            { 
                if (_Adress == value)
                    return;
                _Adress = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Departments変更通知プロパティ
        private ObservableCollection<Department> _Departments = new ObservableCollection<Department>();

        public ObservableCollection<Department> Departments
        {
            get
            { return _Departments; }
            set
            { 
                if (_Departments == value)
                    return;
                _Departments = value;
                RaisePropertyChanged();
            }
        }
        #endregion


    }
}
