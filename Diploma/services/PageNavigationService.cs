using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Diploma.utils;

namespace Diploma.services
{
    static class PageNavigationService
    {
        public static void Navigate(Window window, Page page)
        {
            ((MainWindow) window).mainFrame.Content = page;
        }
    }
}
