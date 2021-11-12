using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListManagement.WebApp.Data;
using ListManagement.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListManagement.WebApp.Pages
{
    public class GroupModel : PageModel
    {
        private readonly GroupRepository _groupRepository;

        public GroupModel(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public List<Group> Groups { get; set; }
        public Group CurrentGroup { get; set; }

        /// <summary>
        /// Состояние страницы
        /// 0 - выводится список групп
        /// 1 - добавление/редактирование группы
        /// 2 - группа не найдена
        /// </summary>
        public int State = 0; 

        public void OnGet(int? id, bool? edit)
        {
            if (id == null && edit == null) {
                Groups = _groupRepository.GetAll();
                State = 0;
                return;
            }
            State = 1;
            if (edit == true && id == null)
            {
                CurrentGroup = new Group();
                return;
            }

            if (edit == true && id != null)
            {
                CurrentGroup = _groupRepository.GetById(id.Value);
                if(CurrentGroup == null)
                    State = 2;
                return;
            }

        }

        public IActionResult OnPostDelete(int id)
        {
            _groupRepository.Delete(id);
            return Redirect($"/group");
        }

        public IActionResult OnPostSave(int id, string name, string description, DateTime? endDate)
        {
            var group = new Group()
            {
                Id = id,
                Name = name
            };

            if (id == 0)
            {
                var newId = _groupRepository.Insert(group);
                return Redirect($"/group");
            }
            _groupRepository.Update(group);
            return Redirect($"/group");
        }
    }
}
