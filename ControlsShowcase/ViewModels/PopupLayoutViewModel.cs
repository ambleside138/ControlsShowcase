﻿using System;
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
    public class PopupLayoutViewModel : ViewModel
    {
        private readonly Model _Model = new Model();


        private ReadOnlyDispatcherCollection<StaffViewModel> _Staffs;

        public ReadOnlyDispatcherCollection<StaffViewModel> Staffs
        {
            get
            {
                if (_Staffs == null)
                {
                    _Staffs = ViewModelHelper.CreateReadOnlyDispatcherCollection(
                        _Model.Staffs,
                        m => new StaffViewModel(m),
                        DispatcherHelper.UIDispatcher);
                }

                return _Staffs;
            }

        }

        public PopupLayoutViewModel()
        {
            _Model.AddStaffs("TEST", 5);
        }
    }
}
