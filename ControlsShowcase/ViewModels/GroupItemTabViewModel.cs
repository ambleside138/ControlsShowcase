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
    public class GroupItemTabViewModel : ViewModel
    {
        private readonly Model _Model = new Model();

        private ReadOnlyDispatcherCollection<StaffViewModel> _Staffs;

        public ReadOnlyDispatcherCollection<StaffViewModel> Staffs
        {
            get
            {
                if(_Staffs==null)
                {
                    _Staffs = ViewModelHelper.CreateReadOnlyDispatcherCollection(
                        _Model.Staffs,
                        m => new StaffViewModel(m),
                        DispatcherHelper.UIDispatcher);
                }

                return _Staffs;
            }

        }

        public GroupItemTabViewModel()
        {
            AddStaffs("管理部", 4);
            AddStaffs("営業部", 10);
            AddStaffs("開発部", 8);
            
        }

        private void AddStaffs(string deartment, int count)
        {
            foreach (var oStaff in Enumerable.Range(1, count).Select(i => new Staff { Name = "スタッフ" + i }))
            {
                oStaff.Department = deartment;
                _Model.Staffs.Add(oStaff);
            }
        }

    }
}
