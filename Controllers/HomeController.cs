using Microsoft.AspNetCore.Mvc;

using Destinations.Data;
using Destinations.Models;

public class HomeController : Controller
{    
    private readonly IViewModelFactory _factory;
    
    public HomeController(IViewModelFactory factory)
    {        
        _factory = factory;
    }
    
    public IActionResult Index()
    {        
        return View(_factory.Create());
    }
}