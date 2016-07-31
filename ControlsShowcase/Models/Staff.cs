using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Collections.ObjectModel;

namespace ControlsShowcase.Models
{
    public class Staff : NotificationObject
    {

        private static int _IdGen = 0;

        #region Id変更通知プロパティ
        private int _Id;

        public int Id
        {
            get
            { return _Id; }
        }
        #endregion

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

        #region Memo変更通知プロパティ
        private string _Memo;

        public string Memo
        {
            get
            { return _Memo; }
            set
            { 
                if (_Memo == value)
                    return;
                _Memo = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Age変更通知プロパティ
        private int _Age;

        public int Age
        {
            get
            { return _Age; }
            set
            { 
                if (_Age == value)
                    return;
                _Age = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Department変更通知プロパティ
        private string _Department;

        public string Department
        {
            get
            { return _Department; }
            set
            { 
                if (_Department == value)
                    return;
                _Department = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Comments変更通知プロパティ
        private ObservableCollection<string> _Comments = new ObservableCollection<string>();

        public ObservableCollection<string> Comments
        {
            get
            { return _Comments; }
            set
            { 
                if (_Comments == value)
                    return;
                _Comments = value;
                RaisePropertyChanged();
            }
        }
        #endregion




        public Staff()
        {
            _IdGen++;
            _Id = _IdGen;

            Age = new Random().Next(20, 100);
        }
    }
}
