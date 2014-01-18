using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace UI
{
    public static class Switcher
    {
        public static MainWindow window;
 
        public static void Switch(UserControl page)
        {
            window.Navigate(page);
        }
    }
}
