using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Diploma.utils
{
    static class FindParentWindowUtil
    {
        public static Window FindParentWindow(DependencyObject child)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);

            switch (parent)
            {
                //Check if this is the end of the tree
                case null:
                    return null;
                case Window parentWindow:
                    return parentWindow;
                default:
                    //use recursion until it reaches a Window
                    return FindParentWindow(parent);
            }
        }
    }
}
