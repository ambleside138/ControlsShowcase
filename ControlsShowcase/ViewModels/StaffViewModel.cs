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
using System.Windows.Threading;

namespace ControlsShowcase.ViewModels
{
    public class StaffViewModel : ViewModel
    {
        private readonly Staff _Model;

        public Staff Model
        {
            get { return _Model; }
        }

        public StaffViewModel(Staff model)
        {
            _Model = model;
        }

        public void FocusToName()
        {
            Messenger.Raise(new InteractionMessage("FocusToName"));
        }

        public void FocusToNameOnDispatcherBackground()
        {
            DispatcherHelper.UIDispatcher.BeginInvoke(new Action(() => Messenger.Raise(new InteractionMessage("FocusToName"))), DispatcherPriority.Background);
        }


    }
}
