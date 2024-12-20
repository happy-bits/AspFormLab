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

    public IActionResult Privacy()
    {
        return View();
    }

}
