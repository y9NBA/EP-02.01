using _02._011.Converter;
using MaterialDesignColors.ColorManipulation;
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
    /// Логика взаимодействия для PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        public PageMenu()
        {
            InitializeComponent();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.СurrentFrame.Navigate(new PageEntry());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TasksNotesTable.Columns.Clear();
            TasksNotesTable.Columns.Add(CreateColumn("Created", "CreateDate"));
            TasksNotesTable.Columns.Add(CreateColumn("ShortName", "ShortName"));
            TasksNotesTable.Columns.Add(CreateColumn("Tags", "Tags"));
            TasksNotesTable.Columns.Add(CreateColumn("PlannedDate", "PlannedDate"));
            TasksNotesTable.Columns.Add(CreateColumn("DaysLeft", "DaysLeft"));
            TasksNotesTable.Columns.Add(CreateColumn("Completion", "DateСompletion"));
            TasksNotesTable.Columns.Add(CreateColumn("Type", "Type.Name"));
        }

        public static DataGridTextColumn CreateColumn(string header, string binding)
        {
            DataGridTextColumn column = new()
            {
                Header = header,
                IsReadOnly = true,
            };
            Binding textBinding = new(binding)
            {
                Converter = new TNConverter()
            };
            column.Binding = textBinding;
            return column;
        }

        private void Today_RB(object sender, RoutedEventArgs e)
        {

        }

        private void Yesterday_RB(object sender, RoutedEventArgs e)
        {

        }

        private void AllDay_RB(object sender, RoutedEventArgs e)
        {

        }

        private void Tsk_RB(object sender, RoutedEventArgs e)
        {

        }

        private void Nt_RB(object sender, RoutedEventArgs e)
        {

        }

        private void Complet_RB(object sender, RoutedEventArgs e)
        {

        }

        private void NComplet_RB(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Discription(object sender, RoutedEventArgs e)
        {

        }

        private void FilterName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tags_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TasksNotesTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
