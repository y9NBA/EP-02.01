using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02._011.DataBase.Models
{
    public class TasksNotes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string CreateDate { get; set; } = ""; //Дата создания заметки/таска

        public string ShortName { get; set; } = ""; //Короткое имя

        public string Tags { get; set; } = ""; //Теги

        public string FullDescription { get; set; } //Полное описание заметки/таска

        public string PlannedDate { get; set; } = ""; //План даты выполнения

        public string DaysLeft //Дней оставшихся на выполнении таска
        {
            get
            {
                if (DateTime.TryParse(PlannedDate, out DateTime plannedDate))
                {
                    TimeSpan timeSpan = plannedDate - DateTime.Now;
                    int daysLeft = int.Max(timeSpan.Days, 0);
                    return daysLeft.ToString();
                }
                return "-";
            }
            set
            {

            }
        }
        public string DateСompletion { get; set; } = ""; //Фактическая дата выполнения

        public Types Types { get; set; } //Тип записи

        public TasksNotes() { } //Конструктор класса, нечего сказать -_('v')_-
    }
}
