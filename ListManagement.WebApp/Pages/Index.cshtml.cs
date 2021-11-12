using ListManagement.WebApp.Data;
using ListManagement.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListManagement.WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ItemRepository _itemRepository;
    private readonly GroupRepository _groupRepository;
    private readonly StatusRepository _statusRepository;

    public List<Group> Groups { get; set; }
    public List<Item> Items { get; set; }

    public int GroupParameter { get; set; }
    public Dictionary<int, string> Statuses { get; set; }

    public IndexModel(ItemRepository itemRepository, GroupRepository groupRepository, StatusRepository statusRepository)
    {
        _itemRepository = itemRepository;
        _groupRepository = groupRepository;
        _statusRepository = statusRepository;
    }


    public void OnGet(int? group)
    {
        GroupParameter = group ?? -1;
        Groups = _groupRepository.GetAll();

        Statuses = new Dictionary<int, string>();
        var statuses = _statusRepository.GetAll();
        foreach (var status in statuses)
            Statuses.Add(status.Id, status.Name);

        if (group == null || group == -1)
        {
            Items = _itemRepository.GetAll();
            return;
        }

        if (group == 0)
        {
            Items = _itemRepository.GetWithoutGroup();
            return;
        }

        Items = _itemRepository.GetItemsByGroupId(group.Value);
    }
}

