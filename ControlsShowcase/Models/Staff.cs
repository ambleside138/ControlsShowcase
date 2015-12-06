using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace ControlsShowcase.Models
{
    public class Staff : NotificationObject
    {

        #region Id変更通知プロパティ
        private int _Id;

        public int Id
        {
            get
            { return _Id; }
            set
            { 
                if (_Id == value)
                    return;
                _Id = value;
                RaisePropertyChanged();
            }
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

    }
}
