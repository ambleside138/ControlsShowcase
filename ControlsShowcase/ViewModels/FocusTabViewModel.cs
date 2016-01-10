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
    public class FocusTabViewModel : ViewModel
    {
        private ReadOnlyDispatcherCollection<StaffViewModel> _Staffs;

        public ReadOnlyDispatcherCollection<StaffViewModel> Staffs
        {
            get
            {
                if(_Staffs ==null)
                {
                    _Staffs = ViewModelHelper.CreateReadOnlyDispatcherCollection(
                        _Model.Staffs,
                        m => new StaffViewModel(m),
                        DispatcherHelper.UIDispatcher);
                }

                return _Staffs;
            }
        }

        private readonly Model _Model;

        public FocusTabViewModel()
        {
            _Model = new Model();
            
        }

        public void NormalFocusAction()
        {
            Messenger.Raise(new InteractionMessage("FocusToTextBox"));
        }

        public void AddStaff()
        {
            _Model.Staffs.Add(new Staff());

            _Staffs.Last().FocusToName();
        }

        public void AddStaffOnDispatcherBackground()
        {
            _Model.Staffs.Add(new Staff());

            _Staffs.Last().FocusToNameOnDispatcherBackground();
        }
    }
}
