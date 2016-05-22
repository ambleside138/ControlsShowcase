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


        public void AddStaffs(string deartment, int count)
        {
            foreach (var oStaff in Enumerable.Range(1, count).Select(i => new Staff { Name = "スタッフ" + i }))
            {
                oStaff.Department = deartment;
                Staffs.Add(oStaff);
            }
        }
    } 
}
