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
using System.Threading.Tasks;
using System.Threading;

namespace ControlsShowcase.ViewModels
{
    // 拝借
    // http://gushwell.ldblog.jp/archives/52273762.html

    public class ProgressBarTabViewModel : ViewModel
    {
        private AnonymousWorker _Worker = new AnonymousWorker();

        #region Progress変更通知プロパティ
        private int _Progress;

        public int Progress
        {
            get
            { return _Progress; }
            set
            { 
                if (_Progress == value)
                    return;
                _Progress = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Status変更通知プロパティ
        private string _Status;

        public string Status
        {
            get
            { return _Status; }
            set
            { 
                if (_Status == value)
                    return;
                _Status = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public void Initialize()
        {
        }

        public void Start()
        {
            Status = "";

            _Worker.RunAsync(p => { Progress = p; }, c =>
           {
               Status = c ? "キャンセル" : "処理完了";
           });
        }

        public void Cancel()
        {
            _Worker.Cancel();
        }
    }

    public class AnonymousWorker
    {
        private readonly BackgroundWorker _BackgoundWorder = new BackgroundWorker();

        private Action<int> _ProgressAction;

        private Action<bool> _CompletedAction;

        private bool _IsCancel;

        public AnonymousWorker()
        {
            _BackgoundWorder.DoWork += _BackgoundWorder_DoWork;
            _BackgoundWorder.ProgressChanged += _BackgoundWorder_ProgressChanged;
            _BackgoundWorder.RunWorkerCompleted += _BackgoundWorder_RunWorkerCompleted;
            _BackgoundWorder.WorkerReportsProgress = true;
        }

        public void RunAsync(Action<int> progressCallback, Action<bool> completedCallback)
        {
            _IsCancel = false;
            _ProgressAction = progressCallback;
            _CompletedAction = completedCallback;
            _BackgoundWorder.RunWorkerAsync();
        }

        public void Cancel()
        {
            _IsCancel = true;
        }

        private void _BackgoundWorder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(_CompletedAction != null)
            {
                _CompletedAction(_IsCancel);
            }
        }

        private void _BackgoundWorder_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(_ProgressAction != null)
            {
                _ProgressAction(e.ProgressPercentage);
            }
        }

        private void _BackgoundWorder_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if(_IsCancel)
                {
                    break;
                }

                _BackgoundWorder.ReportProgress(i + 1);
                Thread.Sleep(50);
            }
        }

        
    }
}
