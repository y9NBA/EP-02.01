using _02._011.Converter;
using _02._011.DataBase.Models;
using _02._011.DataBase;
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
using Microsoft.EntityFrameworkCore;

namespace _02._011.WINDOWS.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        public static int FilterDate { get; set; } //Статические поля для хранения наложенных фильтров
        public static int FilterType { get; set; }
        public static int FilterComplet { get; set; }
        public static int FilterFields { get; set; }
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
            FilterDate = 1;
            UpdateTable(TasksNotesTable);
        }

        private void Yesterday_RB(object sender, RoutedEventArgs e)
        {
            FilterDate = 2;
            UpdateTable(TasksNotesTable);
        }

        private void AllDay_RB(object sender, RoutedEventArgs e)
        {
            FilterDate = 3;
            UpdateTable(TasksNotesTable);
        }

        private void Tsk_RB(object sender, RoutedEventArgs e)
        {
            FilterType = 1;
            UpdateTable(TasksNotesTable);
        }

        private void Nt_RB(object sender, RoutedEventArgs e)
        {
            FilterType = 2;
            UpdateTable(TasksNotesTable);
        }

        private void Complet_RB(object sender, RoutedEventArgs e)
        {
            FilterComplet = 1;
            UpdateTable(TasksNotesTable);
        }

        private void NComplet_RB(object sender, RoutedEventArgs e)
        {
            FilterComplet = 2;
            UpdateTable(TasksNotesTable);
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

        private void Button_Description(object sender, RoutedEventArgs e)
        {
            if (TasksNotesTable.SelectedItem != null)
            {
                PageDescription pageDescription = new((TasksNotes)TasksNotesTable.SelectedItem);
                Navigation.Navigation.СurrentFrame.Navigate(pageDescription);
            }
            else return;
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

        public void UpdateTable(DataGrid TasksNotesTable)
        {
            TasksNotesTable.ItemsSource = null;
            List<TasksNotes> notes = Context.Instance.TaskNotes.Include("Types").ToList();
            if (FilterDate == 1)
            {
                string date = DateTime.Now.ToString("d");
                notes = notes.Where(p => p.CreateDate == date).ToList();
            }
            if (FilterDate == 2)
            {
                string yeasterdayDateStr = DateTime.Now.AddDays(-1).Date.ToString("d");
                notes = notes.Where(p => p.CreateDate == yeasterdayDateStr).ToList();
            }
            if (FilterDate == 3)
            {
                string alldata = DateTime.Now.AddDays(1).Date.ToString("d");
                notes = notes.Where(p => p.CreateDate == alldata).ToList();
            }
            if (FilterType == 1)
            {
                notes = notes.Where(p => p.Types == Context.Instance.Types.ToList()[1]).ToList();
            }
            if (FilterType == 2)
            {
                notes = notes.Where(p => p.Types == Context.Instance.Types.ToList()[0]).ToList();
            }
            if (FilterComplet == 1)
            {
                notes = notes.Where(p => p.Types == Context.Instance.Types.ToList()[1] && p.DateСompletion != "").ToList();
            }
            if (FilterComplet == 2)
            {
                notes = notes.Where(p => p.Types == Context.Instance.Types.ToList()[1] && p.DateСompletion == "").ToList();
            }
            if (FilterFields == 1)
            {
                notes = notes.Where(p => p.ShortName.ToLower().Contains(FilterName.Text.ToLower())).ToList();
            }
            if (FilterFields == 2)
            {
                notes = notes.Where(p => p.Tags.ToLower().Contains(Tags.Text.ToLower())).ToList();
            }

            TasksNotesTable.ItemsSource = notes;
        }
    }
}
