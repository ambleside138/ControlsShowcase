using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ControlsShowcase.Utils
{
    public static class LogicalTreeUtil
    {
        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            T parent = null;
            var currentParent = LogicalTreeHelper.GetParent(child);

            while (currentParent != null)
            {

                // check the current parent
                if (currentParent is T)
                {
                    parent = (T)currentParent;
                    break;
                }

                // find the next parent
                currentParent = LogicalTreeHelper.GetParent(currentParent);
            }

            return parent;
        }

        public static void PrintLogicalTree(DependencyObject obj)
        {
            Debug.WriteLine("PrintLogicalTree");
            PrintLogicalTree(0, obj);
        }


        // 論理ツリー？を出力する。
        // DependencyObjectの場合は、子要素も再帰的に表示する
        private static void PrintLogicalTree(int level, DependencyObject obj)
        {
            PrintObject(level, obj);
            foreach (var child in LogicalTreeHelper.GetChildren(obj))
            {
                if (child is DependencyObject)
                {
                    PrintLogicalTree(level + 1, (DependencyObject)child);
                }
                else
                {
                    PrintObject(level + 1, child);
                }
            }
        }

        // ToStringの結果をインデントつきで出力
        private static void PrintObject(int level, object obj)
        {
            Debug.WriteLine(new string('\t', level) + obj);
        }

    }
}
