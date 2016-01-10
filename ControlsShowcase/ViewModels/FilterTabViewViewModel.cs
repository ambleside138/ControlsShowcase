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
    public class FilterTabViewViewModel : ViewModel
    {

        #region StaffCollection変更通知プロパティ
        private CollectionSourceViewModel<Staff> _StaffCollection;

        public CollectionSourceViewModel<Staff> StaffCollection
        {
            get
            { return _StaffCollection; }
            set
            { 
                if (_StaffCollection == value)
                    return;
                _StaffCollection = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region NameFilter変更通知プロパティ
        private string _NameFilter;

        public string NameFilter
        {
            get
            { return _NameFilter; }
            set
            { 
                if (_NameFilter == value)
                    return;
                _NameFilter = value;
                RaisePropertyChanged();
                StaffCollection.UpdateFilter();
            }
        }
        #endregion

        #region SelectedName変更通知プロパティ
        private string _SelectedName;

        public string SelectedName
        {
            get
            { return _SelectedName; }
            set
            { 
                if (_SelectedName == value)
                    return;
                _SelectedName = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        public FilterTabViewViewModel()
        {
            StaffCollection = new CollectionSourceViewModel<Staff>(Enumerable.Range(1, 999).Select(i => new Staff { Name = i + "TEST" }), s => Filter(s));
            StaffCollection.View.CurrentChanged += View_CurrentChanged;
        }

        private void View_CurrentChanged(object sender, EventArgs e)
        {
            SelectCommand.RaiseCanExecuteChanged();
        }

        private bool Filter(Staff staff)
        {
            if(String.IsNullOrWhiteSpace(NameFilter))
            {
                return true;
            }

            return staff.Name.StartsWith(NameFilter);
        }



        #region SelectCommand
        private ViewModelCommand _SelectCommand;

        public ViewModelCommand SelectCommand
        {
            get
            {
                if (_SelectCommand == null)
                {
                    _SelectCommand = new ViewModelCommand(Select, CanSelect);
                }
                return _SelectCommand;
            }
        }

        public bool CanSelect()
        {
            return StaffCollection.SelectedItem != null;
        }

        public void Select()
        {
            SelectedName = StaffCollection.SelectedItem.Name;
        }
        #endregion


    }
}
