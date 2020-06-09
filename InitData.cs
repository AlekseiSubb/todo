using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo.Models;

namespace todo
{
    public class InitData
    {
        public static void Initialize(TodoContext context)
        {
            if (!context.WorkTypes.Any())
            {
                context.WorkTypes.AddRange(
                new WorkType
                {
                    Discription = "Тестовая"
                },
                new WorkType
                {
                    Discription = "Работа"
                },
                new WorkType
                {
                    Discription = "Дела по дому"
                },
                new WorkType
                {
                    Discription = "Спорт"
                },
                new WorkType
                {
                    Discription = "Отдых с друзьями"
                }
                );

                context.SaveChanges();
            }


            if (!context.Works.Any())
            {
                context.Works.Add(
                new Work
                {
                    Title = "Работа 1",
                    Comment = "Тестовая задача",
                    WorkTypeId = 1,
                    DateCompletion = new DateTime(2020, 6, 27, 12, 00, 00),
                    IsReady = false
                });
                context.SaveChanges();
            }
         }
    }
}
