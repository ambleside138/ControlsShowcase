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
    public class NavigateAnimationTabViewModel : ViewModel
    {
        private readonly NavigationPageViewModel _Page1;
        private readonly NavigationPageViewModel _Page2;

        #region Content変更通知プロパティ
        private NavigationPageViewModel _Content;

        public NavigationPageViewModel Content
        {
            get
            { return _Content; }
            set
            { 
                if (_Content == value)
                    return;
                _Content = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Page1Command
        private ViewModelCommand _Page1Command;

        public ViewModelCommand Page1Command
        {
            get
            {
                if (_Page1Command == null)
                {
                    _Page1Command = new ViewModelCommand(Page1);
                }
                return _Page1Command;
            }
        }

        public void Page1()
        {
            Content = _Page1;
            _Page1.SendAnimationTriggerMessege();
        }
        #endregion

        #region Page2Command
        private ViewModelCommand _Page2Command;

        public ViewModelCommand Page2Command
        {
            get
            {
                if (_Page2Command == null)
                {
                    _Page2Command = new ViewModelCommand(Page2);
                }
                return _Page2Command;
            }
        }

        public void Page2()
        {
            Content = _Page2;
            _Page2.SendAnimationTriggerMessege();
        }
        #endregion

        public NavigateAnimationTabViewModel()
        {
            _Page1 = new NavigationPageViewModel("This is Page1");
            _Page1.AddStaffs("zimu", 20);

            _Page2 = new NavigationPageViewModel("### PAGE 2 ###");
            _Page2.AddStaffs("dev", 5);

            Content = _Page1;
        }

        public void Initialize()
        {
        }
    }
}
