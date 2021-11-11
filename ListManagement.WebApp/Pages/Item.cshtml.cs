using ListManagement.WebApp.Models;
using ListManagement.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListManagement.WebApp.Pages;

public class ItemModel : PageModel
{
    private readonly ListService _listService;

    /// <summary>
    /// Задача
    /// </summary>
    public ListItem Item { get; set; }

    /// <summary>
    /// Существует ли задача
    /// </summary>
    public bool IsExist { get; set; }

    public ItemModel(ListService listService)
    {
        _listService = listService;
    }

    public void OnGet(int? id)
    {
        if (id == null)
            Item = new ListItem();
        else
        {
            Item = _listService.GetItemById(id.Value);
        }

        IsExist = Item != null;
    }

    public IActionResult OnPostDelete(int id)
    {
        _listService.Delete(id);
        return Redirect($"/");
    }

    public IActionResult OnPostSave(int id, string name, string description, DateTime? endDate)
    {
        _listService.Upsert(id, name, description, endDate);
        return Redirect($"/item?id={id}");
    }
}


