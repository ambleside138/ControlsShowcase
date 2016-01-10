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
using System.Collections.ObjectModel;

namespace ControlsShowcase.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly Model _Model = new Model();

        private ObservableCollection<Staff> _Staffs;

        public ObservableCollection<Staff> Staffs
        {
            get { return _Staffs; }
        }

        public MainWindowViewModel()
        {
            _Staffs = new ObservableCollection<Staff>(Enumerable.Range(0, 3).Select(i => new Staff { Name = "TEST" + i, Memo = "" }));
            _Staffs.Add(new Staff { Name = "長い名前のサンプル", Memo = "" });
        }

        public void Initialize()
        {


        }
    }
}
