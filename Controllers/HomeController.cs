using Microsoft.AspNetCore.Mvc;
using AspFormLab.Services;
using AspFormLab.ViewModels;

namespace AspFormLab.Controllers;

public class HomeController(DataService dataService) : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Select1()
    {
        var vm = new Select1Vm();
        vm.Authors = dataService.GetAllAuthors();
        return View(vm);
    }

    [HttpPost]
    public IActionResult Select1(Select1Vm vm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid model state");
        }

        return Ok(vm.SelectedAuthorId == null
            ? "You didn't select any author" :
            "You selected author with id " + vm.SelectedAuthorId);
    }


    public IActionResult Check1()
    {
        var vm = new Check1Vm();
        vm.Authors = dataService.GetAllAuthors();
        vm.SelectedAuthors = vm.Authors.Select(a => new AuthorCheckboxVm { Id = a.Id, Name = a.Name, IsSelected = false }).ToList();
        return View(vm);
    }

    [HttpPost]
    public IActionResult Check1(Check1Vm vm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid model state");
        }

        return Ok("Selected author ids: " + string.Join(',', vm.SelectedAuthorIds));
    }


    [HttpPost]
    public IActionResult Check1_Alternative(Check1Vm vm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid model state");
        }

        return Ok("Selected author ids: " + string.Join(',', vm.SelectedAuthors.Where(a => a.IsSelected).Select(a => a.Id)));
    }




}
