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
    public class AvalonDockContainerViewModel : ViewModel
    {

        #region ShowChildWindowCommand
        private ViewModelCommand _ShowChildWindowCommand;

        public ViewModelCommand ShowChildWindowCommand
        {
            get
            {
                if (_ShowChildWindowCommand == null)
                {
                    _ShowChildWindowCommand = new ViewModelCommand(ShowChildWindow);
                }
                return _ShowChildWindowCommand;
            }
        }

        public void ShowChildWindow()
        {
            Messenger.Raise(new TransitionMessage("ShowCommand"));
        }
        #endregion

    }
}
