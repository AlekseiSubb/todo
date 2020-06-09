using System;

namespace todo.Models
{
    public class Work
    {
        public int WorkId { get; set; }
        public string Title { get; set; } // заголовок
        public string Comment { get; set; } // Описание работы
        public DateTime DateCompletion { get; set; } // Срок выполнения
        public bool IsReady { get; set; } // выполнена

        public int WorkTypeId { get; set; } // тип работы из справочника
        public WorkType WorkType { get; set; }
    }
}
