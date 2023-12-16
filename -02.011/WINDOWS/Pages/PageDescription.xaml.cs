using _02._011.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02._011.WINDOWS.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageDescription.xaml
    /// </summary>
    public partial class PageDescription : Page
    {
        public static TasksNotes task {  get; set; }
        public PageDescription(TasksNotes tasksNotes)
        {
            InitializeComponent();
            task = tasksNotes;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.СurrentFrame.Navigate(new PageMenu());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FDescription.Text = task.FullDescription;
        }
    }
}
