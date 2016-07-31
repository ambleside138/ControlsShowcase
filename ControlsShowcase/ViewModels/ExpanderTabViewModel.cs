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
    public class ExpanderTabViewModel : ViewModel
    {

        #region CompanyTabs変更通知プロパティ
        private ObservableCollection<Company> _CompanyTabs;

        public ObservableCollection<Company> CompanyTabs
        {
            get
            { return _CompanyTabs; }
            set
            {
                if (_CompanyTabs == value)
                    return;
                _CompanyTabs = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public ExpanderTabViewModel()
        {
            var list = new List<Company>();

            foreach (var i in Enumerable.Range(1, 7))
            {
                var oCompany = new Company
                {
                    Name = "会社" + i,
                    Departments = new ObservableCollection<Department>(),
                };

                var listDept = new List<Department>();
                foreach (var j in Enumerable.Range(1, 8))
                {
                    var oDepartment = new Department
                    {
                        DepartmentId = j,
                        Name = "部署" + j,
                        StaffGroups = new ObservableCollection<StaffGroup>(),
                    };

                    foreach (var k in Enumerable.Range(1, 12))
                    {
                        var oStaffGroup = new StaffGroup
                        {
                            Name = "グループ" + k,
                            Staffs = new ObservableCollection<Staff>(new List<Staff>
                            {
                                new Staff { Name = "スタッフA", Memo = "hogehoge" },
                                new Staff { Name = "スタッフB", Memo = "hugahuga" },
                                new Staff { Name = "スタッフC", Memo = "" },
                            }),
                        };

                        oDepartment.StaffGroups.Add(oStaffGroup);
                    }

                    listDept.Add(oDepartment);
                }

                oCompany.Departments = new ObservableCollection<Department>(listDept);
                list.Add(oCompany);
            }

            _CompanyTabs = new ObservableCollection<Company>(list);
        }
    }

}
