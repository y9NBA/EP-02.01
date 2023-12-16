using _02._011.DataBase;
using _02._011.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для PageAddtasksNotes.xaml
    /// </summary>
    public partial class PageAddTaskNote : Page
    {
        public static TasksNotes tasksNotes {  get; set; }
        public PageAddTaskNote(TasksNotes task)
        {
            InitializeComponent();
            tasksNotes = task;
        }

        private void Task_Note_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Task_Note.SelectedItem != null)
            {
                if ((Types)Task_Note.SelectedItem == Context.Instance.Types.ToList()[0])
                {
                    Data.IsEnabled = false;
                    Comp.IsEnabled = false;
                    Data.SelectedDate = DateTime.Now;
                    Comp.IsChecked = false;
                }
                else
                {
                    Data.IsEnabled = true;
                    Comp.IsEnabled = true;
                }
            }
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            bool correct = true;
            string createDate = tasksNotes.CreateDate;
            string SName = "";
            string tags = "";
            string Description = "";
            string Date = "";
            string daysLeft = "";
            string dateСompletion = "";
            Types type = (Types)Task_Note.SelectedItem;
            if (createDate.Trim() == "")
            {
                createDate = DateTime.Now.ToString("d");
            }
            if (Name.Text.Trim() == "" ||
               tgs.Text.Trim() == "" ||
               Descr.Text.Trim() == "")
            {
                correct = false;
            }
            else
            {
                SName = Name.Text;
                tags = tgs.Text;
                Description = Descr.Text;
            }
            if (type == null)
            {
                correct = false;
            }
            else
            {
                Types currentType = (Types)Task_Note.SelectedItem;
                if (currentType == Context.Instance.Types.ToList()[0])
                {
                    daysLeft = "-";
                    Date = "-";
                    dateСompletion = "-";
                }
                else
                {
                    if (Data.SelectedDate.ToString().Trim() == "")
                    {
                        correct = false;
                    }
                    else
                    {
                        if (Data.SelectedDate < DateTime.Now.Date)
                        {
                            MessageBox.Show("Планируемая дата меньше текущей даты", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        Date = ((DateTime)Data.SelectedDate).ToString("d");
                    }
                    dateСompletion = (bool)Comp.IsChecked ? DateTime.Now.ToString("d") : "";
                }
            }
            if (correct)
            {
                tasksNotes.CreateDate = createDate;
                tasksNotes.ShortName = SName;
                tasksNotes.Tags = tags;
                tasksNotes.FullDescription = Description;
                tasksNotes.PlannedDate = Date;
                tasksNotes.DaysLeft = tasksNotes.DaysLeft;
                tasksNotes.DateСompletion = dateСompletion;
                tasksNotes.Types = type;
                Context.Instance.SaveChanges();
                MessageBox.Show("U'll be transferred to PageMenu", "Successfully!", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigation.Navigation.СurrentFrame.Navigate(new PageMenu());
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.СurrentFrame.Navigate(new PageMenu());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Task_Note.ItemsSource = Context.Instance.Types.ToList();
            Name.Text = tasksNotes.ShortName;
            tgs.Text = tasksNotes.Tags;
            Descr.Text = tasksNotes.FullDescription;
            Data.Text = tasksNotes.PlannedDate;
            Task_Note.SelectedItem = tasksNotes.Types;
            Comp.IsChecked = tasksNotes.DateСompletion == "" ? false : true;
        }
    }
}
