using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _02._011.Navigation
{
    internal class Navigation //Класс со стат методом для получения и задания текущего фрейма, так как работа через страницы
    {
        public static Frame СurrentFrame { get; set; }
    }
}
