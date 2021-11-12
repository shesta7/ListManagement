using ListManagement.WebApp.Data;
using ListManagement.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListManagement.WebApp.Pages;

public class ItemModel : PageModel
{
   

    /// <summary>
    /// Задача
    /// </summary>
    public Item Item { get; set; }

    /// <summary>
    /// Существует ли задача
    /// </summary>
    public bool IsExist { get; set; }

    private readonly GroupRepository _groupRepository;
    private readonly StatusRepository _statusRepository;
    private readonly ItemRepository _itemRepository;

    public List<Group> Groups { get; set; }
    public List<Status> Statuses { get; set; }
    

    public ItemModel(ItemRepository itemRepository,
                     GroupRepository groupRepository,
                     StatusRepository statusRepository)
    {
        _itemRepository = itemRepository;
        _groupRepository = groupRepository;
        _statusRepository = statusRepository;
    }

    public void OnGet(int? id, int? group)
    {
        if (id == null)
        {
            Item = new Item();
            Item.GroupId = group;
        }
        else
        {
            Item = _itemRepository.GetById(id.Value);
        }

        IsExist = Item != null;
        Groups = _groupRepository.GetAll();
        Statuses = _statusRepository.GetAll();
    }

    public IActionResult OnPostDelete(int id)
    {
        _itemRepository.Delete(id);
        return Redirect($"/");
    }

    public IActionResult OnPostSave(int id, string name, string description, DateTime? endDate, int group, int status)
    {
        var item = new Item()
        {
            Id = id,
            Name = name,
            Description = description,
            EndDate = endDate,
            GroupId = group == 0 ? null : group,
            StatusId = status == 0 ? null : status
        };

        if (id == 0)
        {
            var newid = _itemRepository.Insert(item);
            return Redirect($"/item?id={newid}");
        }

        _itemRepository.Update(item);

        return Redirect($"/item?id={id}");
    }
}


