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
using System.Windows.Data;
using Livet.EventListeners.WeakEvents;

namespace ControlsShowcase.ViewModels
{
    public class CollectionSourceViewModel<T> : ViewModel
    {

        #region CollectionSource変更通知プロパティ
        private ObservableCollection<T> _CollectionSource;

        public ObservableCollection<T> CollectionSource
        {
            get
            { return _CollectionSource; }

            private set
            { 
                if (_CollectionSource == value)
                    return;
                _CollectionSource = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public ICollectionView View { get; private set; }


        public CollectionSourceViewModel(IEnumerable<T> source, Func<T,bool> filter)
        {
            CollectionSource = new ObservableCollection<T>(source);

            // Viewの作成
            View = CollectionViewSource.GetDefaultView(CollectionSource);
            View.Filter = x => filter((T)x);
        }

        public void UpdateFilter()
        {
            View.Refresh();
        }

        public T SelectedItem
        {
            get { return (T)View.CurrentItem; }
        }


    }
}
