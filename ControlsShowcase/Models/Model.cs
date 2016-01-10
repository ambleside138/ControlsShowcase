using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Collections.ObjectModel;

namespace ControlsShowcase.Models
{
    public class Model : NotificationObject
    {
        private readonly ObservableCollection<Staff> _Staffs = new ObservableCollection<Staff>();

        public ObservableCollection<Staff>  Staffs
        {
            get { return _Staffs; }
        }

    } 
}
