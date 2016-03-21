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
    public class NavigationPageViewModel : ViewModel
    {
        private readonly Model _Model = new Model();

        #region PageTitle変更通知プロパティ
        private string _PageTitle;

        public string PageTitle
        {
            get
            { return _PageTitle; }
            set
            { 
                if (_PageTitle == value)
                    return;
                _PageTitle = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ButtonText変更通知プロパティ
        private string _ButtonText;

        public string ButtonText
        {
            get
            { return _ButtonText; }
            set
            { 
                if (_ButtonText == value)
                    return;
                _ButtonText = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region Staffs
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
        #endregion

        public NavigationPageViewModel(string title)
        {
            PageTitle = title;
        }


        public void AddStaffs(string deartment, int count)
        {
            foreach (var oStaff in Enumerable.Range(1, count).Select(i => new Staff { Name = "スタッフ" + i }))
            {
                oStaff.Department = deartment;
                _Model.Staffs.Add(oStaff);
            }
        }

        public void SendAnimationTriggerMessege()
        {
            Messenger.Raise(new InteractionMessage("StartSlideInAnimationKey"));
        }

        public void SendSlideOutAnimationTriggerMessege()
        {
            Messenger.Raise(new InteractionMessage("StartSlideOutAnimationKey"));
        }
    }
}
