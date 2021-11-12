using System;
using System.ComponentModel.DataAnnotations;

namespace ListManagement.WebApp.Models
{
    public class Item
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


        /// <summary>
        /// К какой группе относится задача
        /// </summary>
        public int? GroupId { get; set; }


        public int? StatusId { get; set; }
    }
}

