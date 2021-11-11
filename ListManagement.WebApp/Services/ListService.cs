using System;
using ListManagement.WebApp.Models;

namespace ListManagement.WebApp.Services
{
    public class ListService
    {
        public ListService()
        {
        }

        public List<ListItem> GetListItems()
        {
            return new List<ListItem>()
            {
                new ListItem()
                {
                    Id = 1,
                    Name = "Курсач РКСП",
                    Description = "Выполнить курсовую по курсу разработка клиент-серверных приложений",
                    EndDate = DateTime.Parse("2021-11-16")                   
                },
                new ListItem()
                {
                    Id = 2,
                    Name = "Курсач КГ",
                    Description = "Выполнить курсовую по курсу компьютерная графика",
                    EndDate = DateTime.Parse("2021-11-16")
                }
            };
        }


        public ListItem GetItemById(int id)
        {
            var list = GetListItems();
            foreach(var item in list)
            {
                if (item.Id == id)
                    return item;
            }

            return null;
        }

        /// <summary>
        /// Добавление / обновление задачи
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Upsert(int id, string name, string description, DateTime? endDate)
        {
            return true;
        }


        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return true;
        }

    }
}

