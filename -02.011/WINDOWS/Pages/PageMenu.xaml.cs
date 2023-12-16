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
            TaskNoteTable.Columns.Clear();
            TaskNoteTable.Columns.Add(CreateColumn("Created", "CreateDate"));
            TaskNoteTable.Columns.Add(CreateColumn("ShortName", "ShortName"));
            TaskNoteTable.Columns.Add(CreateColumn("Tags", "Tags"));
            TaskNoteTable.Columns.Add(CreateColumn("PlannedDate", "PlannedDate"));
            TaskNoteTable.Columns.Add(CreateColumn("DaysLeft", "DaysLeft"));
            TaskNoteTable.Columns.Add(CreateColumn("Completion", "DateСompletion"));
            TaskNoteTable.Columns.Add(CreateColumn("Type", "Type.Name"));
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
    }
}
