using System;
using System.ComponentModel.DataAnnotations;

namespace ListManagement.WebApp.Models
{
    public class ListItem
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя задачи
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// До которого времени задача должна быть выполнена
        /// (Может отсутствовать)
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

    }
}

